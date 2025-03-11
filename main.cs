using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

public class DllInstaller : Form
{
    private ComboBox comboBox;
    private Button installButton;
    private Label statusLabel;

    public DllInstaller()
    {
        this.Text = "PolarisDLL";
        this.Width = 400;
        this.Height = 200;
        this.StartPosition = FormStartPosition.CenterScreen;

        Label label = new Label();
        label.Text = "Select a DLL library to install:";
        label.Left = 20;
        label.Top = 20;
        label.Width = 300;
        this.Controls.Add(label);

        comboBox = new ComboBox();
        comboBox.Left = 20;
        comboBox.Top = 50;
        comboBox.Width = 200;
        comboBox.Items.AddRange(new string[] { "DirectX 9", "DirectX 11", "DirectX 12", "VCRedist", "XNA", "Windows Kernel" });
        this.Controls.Add(comboBox);

        installButton = new Button();
        installButton.Text = "Install";
        installButton.Left = 230;
        installButton.Top = 50;
        installButton.Width = 100;
        installButton.Click += new EventHandler(InstallDll);
        this.Controls.Add(installButton);

        statusLabel = new Label();
        statusLabel.Text = "";
        statusLabel.Left = 20;
        statusLabel.Top = 90;
        statusLabel.Width = 350;
        this.Controls.Add(statusLabel);

        // Fix SSL/TLS issues
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
    }

    private void InstallDll(object sender, EventArgs e)
    {
        if (comboBox.SelectedIndex == -1)
        {
            MessageBox.Show("Select a download option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string[] urls =
        {
            "https://zephyrgddp.github.io/PolarisDLL/dlls/dx9.zip",
            "https://zephyrgddp.github.io/PolarisDLL/dlls/dx11.zip",
            "https://zephyrgddp.github.io/PolarisDLL/dlls/dx12.zip",
            "https://zephyrgddp.github.io/PolarisDLL/dlls/vcredist.zip",
            "https://zephyrgddp.github.io/PolarisDLL/dlls/msxna.zip",
            "https://zephyrgddp.github.io/PolarisDLL/dlls/windowskernel.zip"
        };
        
        string[] filenames = { "DirectX9.zip", "DirectX11.zip", "DirectX12.zip", "VCRedist.zip", "XNA.zip", "WindowsKernel.zip" };

        string selectedUrl = urls[comboBox.SelectedIndex];
        string selectedFilename = filenames[comboBox.SelectedIndex];
        string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", selectedFilename);

        using (WebClient client = new WebClient())
        {
            statusLabel.Text = "Downloading...";
            try
            {
                client.DownloadFile(new Uri(selectedUrl), selectedFilename);
                File.Move(selectedFilename, downloadsPath);
                statusLabel.Text = selectedFilename + " has been installed to Downloads.";
                MessageBox.Show("Installation complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Installation failed.";
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