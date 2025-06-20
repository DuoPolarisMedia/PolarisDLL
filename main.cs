using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Net.Security;
using System.IO.Compression;

public class DllInstaller : Form
{
    private ComboBox comboBox;
    private Button installButton;
    private Label statusLabel;

    // ---- NEW: download metadata is now class‑level so it's easy to extend ----
    private readonly string[] _urls =
    {
        "https://zephyrgddp.github.io/PolarisDLL/dlls/dx9.zip",          // DirectX 9
        "https://zephyrgddp.github.io/PolarisDLL/dlls/dx11.zip",         // DirectX 11
        "https://zephyrgddp.github.io/PolarisDLL/dlls/dx12.zip",         // DirectX 12
        "https://zephyrgddp.github.io/PolarisDLL/dlls/vcredist.zip",     // VCRedist
        "https://zephyrgddp.github.io/PolarisDLL/dlls/msxna.zip",        // XNA
        "https://zephyrgddp.github.io/PolarisDLL/dlls/windowskernel.zip",// Windows Kernel
        // NOTE ► Change the version below if you need a different .NET release.
        "https://dotnetcli.azureedge.net/dotnet/Runtime/8.0.5/dotnet-runtime-8.0.5-win-x64.zip" // .NET 8 Runtime (x64)
    };

    private readonly string[] _filenames =
    {
        "DirectX9.zip",
        "DirectX11.zip",
        "DirectX12.zip",
        "VCRedist.zip",
        "XNA.zip",
        "WindowsKernel.zip",
        "DotNetRuntime8.zip"
    };

    //              DirectX 9 … WindowsKernel  .NET   → extract ZIP ?
    private readonly bool[] _needsExtraction = { false,   false,      false,  false, false, false,     true };

    public DllInstaller()
    {
        Text = "PolarisDLL";
        Width = 420;
        Height = 220;
        StartPosition = FormStartPosition.CenterScreen;

        Label label = new Label
        {
            Text = "Select a library to install:",
            Left = 20,
            Top = 20,
            Width = 300
        };
        Controls.Add(label);

        comboBox = new ComboBox
        {
            Left = 20,
            Top = 50,
            Width = 240,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        comboBox.Items.AddRange(new string[]
        {
            "DirectX 9",
            "DirectX 11",
            "DirectX 12",
            "VCRedist",
            "XNA",
            "Windows Kernel",
            ".NET Runtime 8 (x64)"   // NEW OPTION
        });
        Controls.Add(comboBox);

        installButton = new Button
        {
            Text = "Install",
            Left = 270,
            Top = 50,
            Width = 100
        };
        installButton.Click += InstallSelectedPackage;
        Controls.Add(installButton);

        statusLabel = new Label
        {
            Text = string.Empty,
            Left = 20,
            Top = 90,
            Width = 380
        };
        Controls.Add(statusLabel);

        // Allow TLS 1.2 and ignore cert problems (GitHub release / Azure Edge)
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        System.Net.ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
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

        using (WebClient client = new WebClient())
        {
            try
            {
                statusLabel.Text = "Downloading…";
                client.DownloadFile(url, downloadPath);
                statusLabel.Text = $"{fileName} downloaded.";

                if (extract)
                {
                    // For .NET Runtime we auto‑extract to a sub‑folder.
                    string extractDir = Path.Combine(downloadsDir, "DotNetRuntime8-x64");
                    Directory.CreateDirectory(extractDir);

                    statusLabel.Text = "Extracting runtime…";
                    ZipFile.ExtractToDirectory(downloadPath, extractDir, overwriteFiles: true);

                    // Optional: clean up ZIP after extracting.
                    File.Delete(downloadPath);

                    statusLabel.Text = $".NET 8 runtime extracted to {extractDir}.";
                    MessageBox.Show(".NET Runtime installation complete!\nAdd the \"dotnet\" folder to PATH or use it directly.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"{fileName} has been saved to Downloads.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Installation failed.";
                MessageBox.Show("Download failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new DllInstaller());
    }
}
