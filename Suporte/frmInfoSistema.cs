using System;
using System.IO;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;

namespace Suporte
{
    public partial class frmInfoSistema : Form
    {

        private readonly ManagementObjectSearcher _oSname = new ManagementObjectSearcher("select * from win32_operatingsystem");
        private readonly ManagementObjectSearcher _gpuinfo = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");

        private readonly ManagementObjectSearcher _process = new ManagementObjectSearcher("select Name from win32_processor");

        public frmInfoSistema()
        {
            InitializeComponent();
        }

        private void GetTotalHDDSize() //TODO A implementar
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name != "")
                {
                    if (drive.VolumeLabel == "")
                    {
                        listView1.Items.Add("[C: " + drive.TotalFreeSpace / (1024 * 1024 * 1024) + " GB] " + "Total: " + drive.TotalSize / (1024 * 1024 * 1024) + " GB");
                    }
                    else
                    {
                        listView1.Items.Add("["+drive.VolumeLabel + ": " + drive.TotalFreeSpace / (1024 * 1024 * 1024) + " GB] " + "Total: " + drive.TotalSize / (1024 * 1024 * 1024) + " GB");    
                    }
                }
            }
        }

        private void GetSystemInfo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            foreach (var o in searcher.Get())
            {
                var mo = (ManagementObject) o;
                PropertyData currentBitsPerPixel = mo.Properties["CurrentBitsPerPixel"];
                PropertyData description = mo.Properties["Description"];
                if (currentBitsPerPixel.Value != null)
                    tbxVGA.Text = description.Value.ToString();
            }

            foreach (ManagementObject os in _oSname.Get())
            {
                tbxWinVer.Text = os["Caption"].ToString();
                tbxMemo.Text = (Int32.Parse(os["TotalVisibleMemorySize"].ToString())/1024) + " MB";
                //ostype = os["Caption"].ToString() != "Microsoft Windows XP Professional"
                //             ? os["OSArchitecture"].ToString()
                //             : "32-Bit";
                //servicepack = os["ServicePackMajorVersion"].ToString();
                tbxDataServico.Text = ManagementDateTimeConverter.ToDateTime(os["InstallDate"].ToString()).ToString();
                break;
            }
            foreach (var proc in _process.Get())
            {
                tbxProcess.Text = proc["Name"].ToString();
            }

        }

        private void frmInfoSistema_Load(object sender, EventArgs e)
        {
            GetTotalHDDSize();
            GetSystemInfo();
            GetDefaultBrowserVersion();
        }

        private void GetDefaultBrowserVersion()
        {
            try
            {
                RegistryKey mozillaKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Mozilla\Mozilla Firefox");
                tbxMozVer.Text = mozillaKey != null ? mozillaKey.GetValue("CurrentVersion").ToString().Split('.')[0] : @"-";

                var registryKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Internet Explorer");
                if (registryKey != null)
                {
                    var ieVersion = registryKey.GetValue("svcUpdateVersion");
                    tbxIEver.Text = !string.IsNullOrEmpty(ieVersion.ToString()) ? ieVersion.ToString().Split('.')[0] : @"-";
                }

                var openSubKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Google Chrome");
                if (openSubKey != null)
                {
                    var ChromeVersion = openSubKey.GetValue("DisplayVersion");
                    tbxChrVer.Text = !string.IsNullOrEmpty(ChromeVersion.ToString()) ? ChromeVersion.ToString().Split('.')[0] : @"-";
                }

                var OperaVersion = cUtils.GetFileVersion(@"C:\Program Files (x86)\Opera\launcher.exe");
                tbxOpVer.Text = !string.IsNullOrEmpty(OperaVersion) ? OperaVersion.Split('.')[0] : @"-";

                if (File.Exists(@"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdge.exe"))
                {
                    label8.Text = @"Versão do Edge";
                    tbxIEver.Text = cUtils.GetProductVersion(@"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdge.exe").Split('.')[0];
                    //tbxOpVer.Text = !string.IsNullOrEmpty(OperaVersion) ? OperaVersion.Split('.')[0] : @"-";
                }

                //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Google\Update
                //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Mozilla\Mozilla Firefox CurrentVersion
                //"C:\Program Files (x86)\Opera\launcher.exe"
            }
            catch (Exception)
            {
                
            }
            
        }
    }
}
