using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Drawing;


public class DllInstaller : Form
{
    private ComboBox comboBox;
    private Button installButton;
    private Label statusLabel;

    private readonly string[] _urls =
    {
        "https://zephyrtm.github.io/PolarisDLL/dlls/dx9.zip",
        "https://zephyrtm.github.io/PolarisDLL/dlls/dx11.zip",
        "https://zephyrtm.github.io/PolarisDLL/dlls/dx12.zip",
        "https://zephyrtm.github.io/PolarisDLL/dlls/vcredist.zip",
        "https://zephyrtm.github.io/PolarisDLL/dlls/msxna.zip",
        "https://zephyrtm.github.io/PolarisDLL/dlls/windowskernel.zip",
        "https://dotnetcli.azureedge.net/dotnet/Runtime/9.0.6/dotnet-runtime-9.0.6-win-x64.zip"
    };

    private readonly string[] _filenames =
    {
        "DirectX9.zip",
        "DirectX11.zip",
        "DirectX12.zip",
        "VCRedist.zip",
        "XNA.zip",
        "WindowsKernel.zip",
        "DotNetRuntime9.zip"
    };

    private readonly bool[] _needsExtraction = { false, false, false, false, false, false, true };

    public DllInstaller()
    {
        Text = "PolarisDLL";
        Width = 420;
        Height = 220;
        StartPosition = FormStartPosition.CenterScreen;

        // Set a custom icon for the window
        try
        {
            Icon = new Icon("icon.ico");
        }
        catch
        {
            Icon = SystemIcons.Application;
        }


        Label label = new Label();
        label.Text = "Select a library to install:";
        label.Left = 20;
        label.Top = 20;
        label.Width = 300;
        Controls.Add(label);

        comboBox = new ComboBox();
        comboBox.Left = 20;
        comboBox.Top = 50;
        comboBox.Width = 240;
        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox.Items.AddRange(new string[]
        {
            "DirectX 9",
            "DirectX 11",
            "DirectX 12",
            "VCRedist",
            "XNA",
            "Windows Kernel",
            ".NET Runtime 9.0"
        });
        Controls.Add(comboBox);

        installButton = new Button();
        installButton.Text = "Install";
        installButton.Left = 270;
        installButton.Top = 50;
        installButton.Width = 100;
        installButton.Click += InstallSelectedPackage;
        Controls.Add(installButton);

        statusLabel = new Label();
        statusLabel.Text = string.Empty;
        statusLabel.Left = 20;
        statusLabel.Top = 90;
        statusLabel.Width = 380;
        Controls.Add(statusLabel);

        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
    }

    private void InstallSelectedPackage(object sender, EventArgs e)
    {
        int index = comboBox.SelectedIndex;
        if (index == -1)
        {
            MessageBox.Show("Select a download option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string url = _urls[index];
        string fileName = _filenames[index];
        bool extract = _needsExtraction[index];

        string downloadsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        string downloadPath = Path.Combine(downloadsDir, fileName);

        statusLabel.Text = "Downloading...";
        installButton.Enabled = false;

        WebClient client = new WebClient();
        client.DownloadFileCompleted += delegate(object s, System.ComponentModel.AsyncCompletedEventArgs args)
        {
            installButton.Enabled = true;
            if (args.Error != null)
            {
                statusLabel.Text = "Installation failed.";
                MessageBox.Show("Download failed: " + args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            statusLabel.Text = fileName + " downloaded.";

            if (extract)
            {
                string extractDir = Path.Combine(downloadsDir, "DotnetRuntime9.0");
                try
                {
                    ExtractWithShell(downloadPath, extractDir);
                    statusLabel.Text = ".NET 9 runtime extracted to " + extractDir + ".";
                    MessageBox.Show(".NET Runtime extraction complete.\nUse the 'dotnet' folder inside it.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Extraction failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(fileName + " has been saved to Downloads.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        };

        client.DownloadFileAsync(new Uri(url), downloadPath);
    }

    private static void ExtractWithShell(string zipPath, string extractFolder)
    {
        if (!Directory.Exists(extractFolder))
        {
            Directory.CreateDirectory(extractFolder);
        }

        Type shellType = Type.GetTypeFromProgID("Shell.Application");
        object shellObject = Activator.CreateInstance(shellType);
        dynamic shell = shellObject;
        dynamic source = shell.NameSpace(zipPath);
        dynamic destination = shell.NameSpace(extractFolder);

        const int CopyHereFlags = 4;

        foreach (var item in source.Items())
        {
            destination.CopyHere(item, CopyHereFlags);
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new DllInstaller());
    }
}