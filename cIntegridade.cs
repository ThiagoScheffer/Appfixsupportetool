using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace Suporte
{
    internal static class cIntegridade
    {
        private static int _infectado;
        private static int _dangerCount;
        static readonly XmlDocument Doc = new XmlDocument();
        //6,23 KB (6.384 bytes)
        static string xmlfile = Program.UpdateDir + "\\VirusDatabase.xml";
        public static void StartSystemCheck()
        {
            if (!cUtils.ConnectionAvailable()) return;

            _dangerCount = 0;
            _infectado = 0;
            
            // Loading from a XML
            if (!File.Exists(xmlfile))
                return;

            //string xmlFile = Program.UpdateDir + "\\VirusDatabase.xml";
            try
            {
                // using (var xmlFile = new FileStream(Program.UpdateDir + "\\VirusDatabase.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
                // {
                //CheckFileSize(xmlfile);

               // MessageBox.Show(CheckFileSize(xmlfile).ToString());

                //se for menor que este valor significa que o arquivo esta incompleto
                if(CheckFileSize(xmlfile) >= 6384)
                Doc.Load(xmlfile);
                // }
            }
            catch (Exception exception)
            {
                cUtils.LogEmailSend("VirusDatabase Load cIntegridade: " + exception.ToString());
                return;
            }

            //Kill strange apps
            ClearApps();

            //Toolbars - browser hijacker
            _dangerCount = AdwareScanner();
            _dangerCount = MalwareScanner();
            _dangerCount = RogueScanner();
            _dangerCount = VbsKiller();
            
            
            IntegridadeSistema();

        }

        private static long CheckFileSize(string filepath)
        {
            if (!File.Exists(filepath))
                return 0;
            long value = 0;
            FileInfo fileInfo = new FileInfo(filepath);
            value = fileInfo.Length ;/// (1024 * 1024)
            return value;
        }
        private static int VbsKiller()
        {
            //Process.GetProcessesByName("wscript.exe");
            Process[] processlist = Process.GetProcessesByName("wscript");
            foreach (Process p in processlist)
            {
                //IntPtr pwindow = p.MainWindowHandle;
                if (p.MainModule.FileName.Contains("wscript"))
                {
                    _infectado = 3;

                    p.Kill();
                }
                break;
            }
            //Stat DELETEMODE
            return _infectado;
        }

        //Iniciado pelo MainForm
        private static void IntegridadeSistema()
        {
            if (Program.Debug)
                return;
            //Executavel do Aplicativo
            try
            {
                if (!File.Exists(Program.ApplicationExe))
                {
                    File.Copy(Application.ExecutablePath, Program.ApplicationExe);
                }
            }
            catch (Exception){}


            //Instanciar Alerta
            frmPaineldeAlerta frmPaineldeAlerta = new frmPaineldeAlerta();

            //Aviso de perigo no PC - usar em PC com financeiro//3094
            if(CRegistros.GetSetEmailAlert == "True" && _dangerCount == 3)
                cUtils.SendEmailAsync("Alerta de Trojan!");

            if(!Program.Editor)
            {
                frmUsuario fMain = (frmUsuario) Application.OpenForms["frmUsuario"];
                if (fMain == null)
                    return;
                if (_dangerCount != 0)
                {
                    fMain.tbxInfo.Text = @"Atenção";
                    fMain.tbxInfo.BackColor = Color.Orange;

                    //DangerGauger
                    // fMain.trackStatus.Value = _dangerCount;
                    if (_dangerCount == 1)
                    {
                        fMain.chkbxAlterado.CheckState = CheckState.Checked;
                        fMain.tbxAvisos.Text = @"Adware Detectado";
                        frmPaineldeAlerta.ShowDialog();
                    }
                    if (_dangerCount == 2)
                    {
                        fMain.chkbxDanificado.CheckState = CheckState.Checked;
                        fMain.chkbxDanificado.ForeColor = Color.DarkRed;
                        fMain.tbxAvisos.Text = @"Malware Detectado";
                        frmPaineldeAlerta.ShowDialog();
                    }
                    if (_dangerCount == 3)
                    {
                        fMain.chkbxComprometido.CheckState = CheckState.Checked;
                        fMain.chkbxComprometido.ForeColor = Color.DarkRed;
                        fMain.tbxAvisos.Text = @"Trojan/Rogue Detectado";
                        frmPaineldeAlerta.ShowDialog();
                    }
                    fMain.notifyIcon.ShowBalloonTip(5, "AVISO DE SEGURANÇA",
                        "Verifique a Central de Suporte.",
                        ToolTipIcon.Info);
                }
                else
                {
                    fMain.tbxInfo.Text = @"Tudo OK";
                    fMain.tbxInfo.BackColor = Color.White;
                }

            }
            if(Program.Editor)
            {
                frmEditor fMain = (frmEditor) Application.OpenForms["frmEditor"];
                if (fMain == null)
                    return;
                if (_dangerCount != 0)
                {
                    fMain.tbxInfo.Text = @"Atenção";
                    fMain.tbxInfo.BackColor = Color.Orange;

                    //DangerGauger
                    fMain.trackStatus.Value = _dangerCount;
                    if (_dangerCount == 1)
                    {
                        fMain.chkbxAlterado.CheckState = CheckState.Checked;
                        fMain.tbxAvisos.Text = @"Adware Detectado";
                    }
                    if (_dangerCount == 2)
                    {
                        fMain.chkbxDanificado.CheckState = CheckState.Checked;
                        fMain.chkbxDanificado.ForeColor = Color.DarkRed;
                        fMain.tbxAvisos.Text = @"Malware Detectado";
                        frmPaineldeAlerta.ShowDialog();
                    }
                    if (_dangerCount == 3)
                    {
                        fMain.chkbxComprometido.CheckState = CheckState.Checked;
                        fMain.chkbxComprometido.ForeColor = Color.DarkRed;
                        fMain.tbxAvisos.Text = @"Trojan/Rogue Detectado";
                        frmPaineldeAlerta.ShowDialog();
                    }
                    fMain.notifyIcon.ShowBalloonTip(5, "AVISO DE SEGURANÇA",
                        "Verifique a Central de Suporte.",
                        ToolTipIcon.Info);
                }
                else
                {
                    fMain.tbxInfo.Text = @"Tudo OK";
                    fMain.tbxInfo.BackColor = Color.White;
                }
            }

            //DETECTADO VIRUS USB -> PARAR PROCESSO
            if (VbsKiller() != 0) return;
            {
                RogueStartupRemover();
            }
        }

        private static void ClearApps()
        {

            try
            {
                if (File.Exists(@"C:\Program Files (x86)\ObjectRescue Pro\ObjectRescuePro.exe"))
                {
                    File.Delete(@"C:\Program Files (x86)\ObjectRescue Pro\ObjectRescuePro.exe");
                }

                if (File.Exists(@"C:\Program Files (x86)\RescuePRO\RescuePRO.exe"))
                {
                    File.Delete(@"C:\Program Files (x86)\RescuePRO\RescuePRO.exe");
                }
                ////TODO Add Opção para executar ou nao o fix
                //if (File.Exists(@"C:\Program Files (x86)\Photodex\ProShow Producer\proshow.phd"))
                //{
                //    File.Delete(@"C:\Program Files (x86)\Photodex\ProShow Producer\proshow.phd");
                //}
                ////C:\Program Files (x86)\Photodex\ProShow Producer
                //if (File.Exists(@"C:\Program Files (x86)\Photodex\ProShow Producer\proshow.cfg"))
                //{
                //    File.Delete(@"C:\Program Files (x86)\Photodex\ProShow Producer\proshow.cfg");
                //}

            }
            catch{}
        }
        private static void RogueStartupRemover()
        {
            RegistryKey RegStartup86 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            RegistryKey RegStartup64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", true);
            RegistryKey RegStartupUSER =Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            string rogueWscript1 = "bcbqejcess";
            
            //remove STARTUP
            try
            { 
                 File.Delete(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\bcbqejcess.vbs");
            }
            catch(Exception)
            {}

            try
            {
                if (RegStartup64 != null)
                {
                    if (RegStartup64.GetValue(rogueWscript1) != null)
                        RegStartup64.DeleteValue(rogueWscript1);
                }
                if (RegStartup86 != null)
                    RegStartup86.DeleteValue(rogueWscript1);

                if (RegStartupUSER != null)
                    RegStartupUSER.DeleteValue(rogueWscript1);
            }
            catch (Exception)
            {

            }
            if (RegStartup64 != null) RegStartup64.Close();
            if (RegStartup86 != null) RegStartup86.Close();
        }

        private static int RogueScanner()
        {
            XmlNodeList LMNodes = Doc.SelectNodes("DBVirus/Rogue/hlmk/key");//Adwares LocalM
            foreach (XmlNode node in LMNodes)
            {
                if (Registry.LocalMachine.OpenSubKey(node.InnerText) != null)
                    _infectado = 3;
            }

            XmlNodeList cuserNodes = Doc.SelectNodes("DBVirus/Rogue/hcuk/key");//Adwares Currentuser
            foreach (XmlNode node in cuserNodes)
            {
                if (Registry.CurrentUser.OpenSubKey(node.InnerText) != null)
                    _infectado = 3;
            }

            return _infectado;
        }
        private static int MalwareScanner()
        {
            XmlNodeList LMNodes = Doc.SelectNodes("DBVirus/Malware/hlmk/key");//Adwares LocalM
            foreach (XmlNode node in LMNodes)
            {
                if (Registry.LocalMachine.OpenSubKey(node.InnerText) != null)
                    _infectado = 2;
            }

            XmlNodeList cuserNodes = Doc.SelectNodes("DBVirus/Malware/hcuk/key");//Adwares Currentuser
            foreach (XmlNode node in cuserNodes)
            {
                if (Registry.CurrentUser.OpenSubKey(node.InnerText) != null)
                    _infectado = 2;
            }
            return _infectado;
        }
        private static int AdwareScanner()
        {
            XmlNodeList LMNodes = Doc.SelectNodes("DBVirus/Adware/hlmk/key");//Adwares LocalM
            foreach (XmlNode node in LMNodes)
            {
                if (Registry.LocalMachine.OpenSubKey(node.InnerText) != null)
                    _infectado = 1;
            }

            XmlNodeList cuserNodes = Doc.SelectNodes("DBVirus/Adware/hcuk/key");//Adwares Currentuser
            foreach (XmlNode node in cuserNodes)
            {
                if (Registry.CurrentUser.OpenSubKey(node.InnerText) != null)
                    _infectado = 1;
            }
            
            //Arquivos Perigosos adw
            if (File.Exists(@"C:\Documents and Settings\All Users\Application Data\WPM\wprotectmanager.exe"))
                _infectado = 1;

            return _infectado;
        }
    }

}

