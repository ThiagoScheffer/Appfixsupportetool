using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace Suporte
{

    /// <summary>
    /// cscript //H:CScript
    /// </summary>
    public sealed partial class frmAdministrador : Form
    {
        static readonly XmlDocument Doc = new XmlDocument();
        private string FileToDownload;
        private bool _doRegClean = false;
        private bool _forcedExit = false;
        readonly bool _isAdmin = IsAdministrator(); //<-- set to allow Delete
        private string fileflag = "";
        public frmAdministrador()
        {
            InitializeComponent();
        }


        //POR NO UTILS
        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            if (identity != null)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            return false;
        }

        //Atualiza componentes do Painel
        private void LoadControlsDefaults()
        {
            tbxCliente.Text = CRegistros.GetCliente();
            tbxUsuario.Text = CRegistros.GetComputerName();
            //Painel Sistema
            try
            {
                if (CRegistros.GetSetUac == "1")
                    chkbxUAC.CheckState = CheckState.Checked; //Habilitado se ativo

                if (CRegistros.GetSetHibernation == "1")
                    chkbxHibern.CheckState = CheckState.Checked;

                if (CRegistros.GetSetSmartscreen == "On")
                    chkbxSmartscreen.CheckState = CheckState.Checked;

                if (CRegistros.GetSetEmailAlert == "True")
                    chkbxSendEmailAlert.CheckState = CheckState.Checked;

                if (CRegistros.GetSetUsbReader == "3")
                    chkbxUSBReader.CheckState = CheckState.Checked; //3 Ativo Permitido

                if (CRegistros.Administrativo)
                    chkbxSetAdm.CheckState = CheckState.Checked;

                if (CRegistros.Tecnico)
                    chkbxsetOwner.CheckState = CheckState.Checked;

                if (CRegistros.GetSetDataRetornoRevisao != "False")
                    chkbxAvisoRevisao.CheckState = CheckState.Checked;
                
                if (CRegistros.GetSetWinDef == "0")//0 enable
                    chkbxWinDef.CheckState = CheckState.Checked;

                //cbxWindowsPos.SelectedItem = CRegistros.WindowLocation;

            }
            catch (Exception)
            {
            }

            tbxDataInicial.Text = CRegistros.GetDataValidade().Item1; //inicial
            tbxDataFinal.Text = CRegistros.GetDataValidade().Item2; //final
            tbxDataPrazoInicio.Text = CRegistros.GetDiaPrazo().Item1.ToString();
            tbxDataPrazoFim.Text = CRegistros.GetDiaPrazo().Item2.ToString();

            if(IsAdministrator())
                tConsole.Text = "Olá Administrador!\n\r";

            tConsole.Focus();
        }
        private void frmAdmCadastrar_Load(object sender, EventArgs e)
        {
            LoadControlsDefaults();

            // Loading from a XML
            if (!File.Exists(Program.UpdateDir + "\\VirusDatabase.xml"))
                return;
            try
            {
                Doc.Load(Program.UpdateDir + "\\VirusDatabase.xml");
            }
            catch (Exception)
            {
                tConsole.Text += "Erro ao acessar o VDB.";
            }
        }

        private void frmAdministrador_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_forcedExit) return;
            Program.Quit = true;
        }

        #region Botoes

        //INICAR PROCESSO COM ARGUMENTOS
        private void StartWithArgs(string processStart, string args)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo { FileName = processStart, Arguments = args };
            Process.Start(startInfo);
        }
        private void btnSalvarCad_Click(object sender, EventArgs e)
        {
            CRegistros.WriteRegisterPc(tbxCliente.Text, tbxUsuario.Text);
        }

        private void chkbxSetAdm_CheckedChanged(object sender, EventArgs e)
        {
            SetAdministrativo();
        }

        private void SetAdministrativo()
        {
            if (chkbxSetAdm.CheckState == CheckState.Checked)
                CRegistros.Administrativo = true;
            else
                CRegistros.Administrativo = false;
        }
        private void chkbxsetOwner_CheckedChanged(object sender, EventArgs e)
        {
            SetTecnico();
        }

        private void SetTecnico()
        {
            if (chkbxsetOwner.CheckState == CheckState.Checked)
                CRegistros.Tecnico = true;
            else
                CRegistros.Tecnico = false;
        }

        private void btnForceQuit_Click(object sender, EventArgs e)
        {
            tConsole.Text = "Sayonara!";
            Program.Quit = true;
            cUtils.DoExit();
        }

        //UPDATER - Verifica se existe o updater ! cria ele e executa;
        private void StartUpdater()
        {
            cUtils.StartAsAdmin(Program.UpdateDir + "\\suporteupdater.exe");
        }

        private void btnForceUp_Click(object sender, EventArgs e)
        {
            StartUpdater();
            tConsole.Text = "Atualização Iniciada...";
        }

        private void btnSalvarDatas_Click(object sender, EventArgs e)
        {
            CRegistros.SetDataValidade(tbxDataInicial.Text, tbxDataFinal.Text);
            tConsole.Text = "Registro Salvo!";
        }

        private void btnSalvarPrazos_Click(object sender, EventArgs e)
        {
            CRegistros.SetDiaPrazo(Convert.ToInt32(tbxDataPrazoInicio.Text), Convert.ToInt32(tbxDataPrazoFim.Text));
            tConsole.Text = "Registros do Prazo Salvos!";
        }
        private void tbnLoadThreats_Click(object sender, EventArgs e)
        {
            LoadCheckList();
            cIntegridade.StartSystemCheck();
        }


        private void btnForceAtiv_Click(object sender, EventArgs e)
        {
            _forcedExit = true;
            tConsole.Text += "\nIniciando Ativação";
            cAtivacao.CriarChaveAtivada();
            tConsole.Text += "\nAtivação Finalizada";
            cUtils.DoRestart();
        }

        private void btnRestAdm_Click(object sender, EventArgs e)
        {
           cUtils.DoRestart();
        }

        private void btnUpdateSuporter_Click(object sender, EventArgs e)
        {
            cUtils.UpdaterRebuild();
        }

        private void btnUSBRepair_Click(object sender, EventArgs e)
        {
            frmUSBRepair frmUsb = new frmUSBRepair();
            frmUsb.ShowDialog();
        }

        private void btnRemovePermKey_Click(object sender, EventArgs e)
        {
            CRegistros.RemovePermKey();
           // frmAdministrador.RemoverData();
            tConsole.Text += "\n\rRegistro de Permissão Resetado.";
        }

        private void btnCleanRegTraces_Click(object sender, EventArgs e)
        {
            if (!_isAdmin)
            {
                tConsole.Text = "Acesso restrito -> inicie o modo Administrador";
                return;
            }

            _doRegClean = true;
            MalwareScanner();
            RogueScanner();
            AdwareScanner();
            tConsole.Text += "\rChaves Removidas!";
            _doRegClean = false;
        }

        private void btnLimparSpooler_Click(object sender, EventArgs e)
        {
            cUtils.CleanPrinter();
        }

        private void btnTempCommands_Click(object sender, EventArgs e)
        {
            CRegistros.SetnewStartupMethod();
        }

        private void tbnRepararRede_Click(object sender, EventArgs e)
        {
            tConsole.Text += "\n";
            tConsole.Text += "Iniciando processo de reparo...\n";
            Process.Start("CMD.exe", "/release");
            Thread.Sleep(2000);
            Process.Start("CMD.exe", "/renew");
            tConsole.Text += "Renovando IP\n";
            Thread.Sleep(1000);
            Process.Start("CMD.exe", "/flushdns");
            Thread.Sleep(1000);
            Process.Start("CMD.exe", "/registerdns");
            Thread.Sleep(2000);
            tConsole.Text += "Renovando DNS\n";
            //P2
            tConsole.Text += "Resetando TCP\n";
            Process.Start("nbtstat", "-rr");
            Thread.Sleep(2000);
            Process.Start("netsh", "int ip reset all");
            Thread.Sleep(2000);
            tConsole.Text += "Resetando Socket\n";
            Process.Start("netsh", "winsock reset");
            Thread.Sleep(3000);
            tConsole.Text += "Concluído. reinicie o PC.";

        }

        private void btnWinformal_Click(object sender, EventArgs e)
        {   //Atualiza o sistema e alteraçoes do HD -> SSD
            //WinSAT.exe formal
            tConsole.Text += @"Detectando tipo de armazenagem do sistema...";
            Process.Start("WinSAT.exe", "formal");
            tConsole.Text += @"Sistema atualizado.";
        }


        private void ckbxUAC_CheckedChanged(object sender, EventArgs e)
        {
            CRegistros.GetSetUac = chkbxUAC.CheckState == CheckState.Checked ? "1" : "0";
        }

        private void chkbxSmartscreen_CheckedChanged(object sender, EventArgs e)
        {
            CRegistros.GetSetSmartscreen = chkbxSmartscreen.CheckState == CheckState.Checked ? "On" : "Off";
        }

        private void chkbxUSBReader_CheckedChanged(object sender, EventArgs e)
        {
            CRegistros.GetSetUsbReader = chkbxUSBReader.CheckState == CheckState.Checked ? "3" : "4";
        }

        private void chkbxHibern_CheckedChanged(object sender, EventArgs e)
        {
            CRegistros.GetSetHibernation = chkbxHibern.CheckState == CheckState.Checked ? "1" : "0";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * Centro 0
                TopRight 1
                BottRigh 2
             */
            if (cbxWindowsPos.SelectedIndex == 0)
            {
                CRegistros.WindowLocation = "center";
            }
            if (cbxWindowsPos.SelectedIndex == 1)
            {
                CRegistros.WindowLocation = "uppercorner";
            }
            if (cbxWindowsPos.SelectedIndex == 2)
            {
                CRegistros.WindowLocation = "rightcorner";
            }
        }
        private void chkbxSendEmailAlert_CheckedChanged(object sender, EventArgs e)
        {
            CRegistros.GetSetEmailAlert = chkbxSendEmailAlert.CheckState == CheckState.Checked ? "True" : "False";
        }

        private void chkbxAvisoRevisao_CheckedChanged(object sender, EventArgs e)
        {
            CRegistros.GetSetDataRetornoRevisao = chkbxAvisoRevisao.CheckState == CheckState.Checked ? DateTime.Now.Date.ToShortDateString() : "False";
        }
        private void chkbxWinDef_CheckedChanged(object sender, EventArgs e)
        {
            CRegistros.GetSetWinDef = chkbxWinDef.CheckState == CheckState.Checked ? "0" : "1";
        }
        private void btnUpdateCachesDirs_Click(object sender, EventArgs e)
        {
            cEditor.WriteAllValuestoRegistry();
            tConsole.Text += @"Registros Atualizados.";
        }
        private void btnJRT_Click(object sender, EventArgs e)
        {
            StartJRT();
        }
        private void btnLockUnlock_Click(object sender, EventArgs e)
        {
            bool Lockstatus = CRegistros.GetSystemLockStatus();
            if (Lockstatus) //Status de travado
            {
                cAtivacao.EnablePanelControl();
                cAtivacao.UnLockAppsFiles();
            }
            else
            {
                cAtivacao.DisablePanelControl();
                cAtivacao.LockAppsFiles();
            }
            tConsole.Text += "\n" + Lockstatus;
        }
        #endregion

        #region SCANNER
        private void LoadCheckList()
        {
            tConsole.Clear();
            tConsole.Text += "--------------------------Iniciado--------------------------------\r";

            _doRegClean = false;

            RogueScanner();
            AdwareScanner();
            MalwareScanner();

            tConsole.Text += "\r--------------------------Finalizado-------------------------------";
        }
        private void RogueScanner()
        {

            XmlNodeList LMNodes = Doc.SelectNodes("DBVirus/Rogue/hlmk/key");//Adwares LocalM

            foreach (XmlNode node in LMNodes)
            {
                if (Registry.LocalMachine.OpenSubKey(node.InnerText, _isAdmin) != null)
                {
                    tConsole.Text += node.InnerText + "\n";
                    if (_doRegClean)
                    {
                        try
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.LocalMachine.DeleteSubKey(node.InnerText);

                        }
                        catch (Exception)
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.LocalMachine.DeleteSubKeyTree(node.InnerText);
                        }
                    }
                }
            }

            XmlNodeList cuserNodes = Doc.SelectNodes("DBVirus/Rogue/hcuk/key");//Adwares Currentuser
            foreach (XmlNode node in cuserNodes)
            {
                if (Registry.CurrentUser.OpenSubKey(node.InnerText, _isAdmin) != null)
                {
                    tConsole.Text += node.InnerText + "\n";
                    if (_doRegClean)
                    {
                        try
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.CurrentUser.DeleteSubKey(node.InnerText);

                        }
                        catch (Exception)
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.CurrentUser.DeleteSubKeyTree(node.InnerText);
                        }
                    }
                }
            }
        }
        private void MalwareScanner()
        {
            XmlNodeList LMNodes = Doc.SelectNodes("DBVirus/Malware/hlmk/key");//Adwares LocalM
            foreach (XmlNode node in LMNodes)
            {
                if (Registry.LocalMachine.OpenSubKey(node.InnerText, _isAdmin) != null)
                {
                    tConsole.Text += node.InnerText + "\n";
                    if (_doRegClean)
                    {
                        try
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.LocalMachine.DeleteSubKey(node.InnerText);

                        }
                        catch (Exception)
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.LocalMachine.DeleteSubKeyTree(node.InnerText);
                        }
                    }
                }
            }

            XmlNodeList cuserNodes = Doc.SelectNodes("DBVirus/Malware/hcuk/key");//Adwares Currentuser
            foreach (XmlNode node in cuserNodes)
            {
                if (Registry.CurrentUser.OpenSubKey(node.InnerText, _isAdmin) != null)
                {
                    tConsole.Text += node.InnerText + "\n";
                    if (_doRegClean)
                    {
                        try
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.CurrentUser.DeleteSubKey(node.InnerText);

                        }
                        catch (Exception)
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.CurrentUser.DeleteSubKeyTree(node.InnerText);
                        }
                    }
                }
            }
        }
        private void AdwareScanner()
        {
            XmlNodeList LMNodes = Doc.SelectNodes("DBVirus/Adware/hlmk/key");//Adwares LocalM
            foreach (XmlNode node in LMNodes)
            {
                if (Registry.LocalMachine.OpenSubKey(node.InnerText, _isAdmin) != null)
                {
                    tConsole.Text += node.InnerText + "\n";
                    if (_doRegClean)
                    {
                        try
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.LocalMachine.DeleteSubKey(node.InnerText);

                        }
                        catch (Exception)
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.LocalMachine.DeleteSubKeyTree(node.InnerText);
                        }
                    }
                }
            }

            XmlNodeList cuserNodes = Doc.SelectNodes("DBVirus/Adware/hcuk/key");//Adwares Currentuser
            foreach (XmlNode node in cuserNodes)
            {
                if (Registry.CurrentUser.OpenSubKey(node.InnerText, _isAdmin) != null)
                {
                    tConsole.Text += node.InnerText + "\n";
                    if (_doRegClean)
                    {
                        try
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.CurrentUser.DeleteSubKey(node.InnerText);

                        }
                        catch (Exception)
                        {
                            tConsole.Text += "\r" + node.InnerText + " <- Removido";
                            Registry.CurrentUser.DeleteSubKeyTree(node.InnerText);
                        }
                    }
                }
            }
        }
        #endregion

        #region Download
        private void DownloadApplication()
        {
            if (!cUtils.ConnectionAvailable())
            {
                tConsole.Text = "\nFalha ao conectar no servidor";
                return;
            }
              
            try
            {
                
                try
                {
                    if (!Directory.Exists(Program.UpdateDir))
                        Directory.CreateDirectory(Program.UpdateDir);
                }
                catch (Exception)
                {
                    return;
                }

                using (WebClient webDownup = new WebClient())
                {
                    switch (fileflag)
                    {
                        case "AdwCleaner":
                        webDownup.DownloadFileAsync(new Uri(FileToDownload), @"C:\ProgramData\SuporteUpdater\AdwCleaner.exe");
                            break;
                        case "Malwarebytes":
                            webDownup.DownloadFileAsync(new Uri(FileToDownload), @"C:\ProgramData\SuporteUpdater\mbam-setup.exe");
                            break;
                        case "Combofix":
                            webDownup.DownloadFileAsync(new Uri(FileToDownload), @"C:\ProgramData\SuporteUpdater\ComboFix.exe");
                            break;
                        case "CCleaner":
                            webDownup.DownloadFileAsync(new Uri(FileToDownload), @"C:\ProgramData\SuporteUpdater\ccsetup.exe");
                            break;
                        case "Hijackthis":
                            webDownup.DownloadFileAsync(new Uri(FileToDownload), @"C:\ProgramData\SuporteUpdater\HijackThis.exe");
                            break;
                        case "JRT":
                            webDownup.DownloadFileAsync(new Uri(FileToDownload), @"C:\ProgramData\SuporteUpdater\JRT.exe");
                            break;
                    }

                    webDownup.DownloadFileCompleted += WebDownupOnDownloadFileCompleted;
                }
            }
            catch (WebException)
            {
            }
        }

        private void WebDownupOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            tConsole.Text += "\nDownload Concluído";
            tConsole.Text += "\nIniciando aplicativo...";
            if (fileflag == "AdwCleaner")
            {
                Process.Start(@"C:\ProgramData\SuporteUpdater\AdwCleaner.exe");
            }

            if (fileflag == "Malwarebytes")
            {
                Process.Start(@"C:\ProgramData\SuporteUpdater\mbam-setup.exe");
            }
            if (fileflag == "Combofix")
            {
                Process.Start(@"C:\ProgramData\SuporteUpdater\ComboFix.exe");
            }
            if (fileflag == "CCleaner")
            {
                Process.Start(@"C:\ProgramData\SuporteUpdater\ccsetup.exe");
            }
            if (fileflag == "Hijackthis")
            {
                Process.Start(@"C:\ProgramData\SuporteUpdater\HijackThis.exe");
            }
            if (fileflag == "JRT")
            {
                Process.Start(@"C:\ProgramData\SuporteUpdater\JRT.exe");
            }
            FileToDownload = "";
            fileflag = "";
        }

        #endregion

        #region read Log
        private void ReadADWCleanerLog()
        {
            if (!Directory.Exists(@"C:\AdwCleaner"))
                return;

            const string path = @"C:\AdwCleaner";
            var dir = new DirectoryInfo(path);
            string filepath = null;
            var LastWrite = DateTime.Now;

            foreach (var file in dir.GetFiles())
            {
                if (file.CreationTime < LastWrite)
                {
                    filepath = file.FullName;
                }
            }

            tConsole.Clear();
            if (filepath != null) tConsole.LoadFile(filepath, RichTextBoxStreamType.PlainText);
        }

        private void ReadMalwarebytesLog()
        {
            //Carrega o ultimo log do malwarebytes
            if (!Directory.Exists(@"C:\ProgramData\Malwarebytes\Malwarebytes Anti-Malware\Logs"))
                return;

            string path = @"C:\ProgramData\Malwarebytes\Malwarebytes Anti-Malware\Logs";
            var dir = new DirectoryInfo(path);
            string filepath = null;
            var LastWrite = DateTime.Now;

            foreach (var file in dir.GetFiles())
            {
                if (file.CreationTime < LastWrite)
                {
                    filepath = file.FullName;
                }
            }

            tConsole.Clear();
            if (filepath != null) tConsole.LoadFile(filepath, RichTextBoxStreamType.PlainText);
        }
        private void ReadCombofixLog()
        {
            //C:\Users\EncryptorX\AppData\Roaming\Malwarebytes\Malwarebytes' Anti-Malware\Logs
            if (!File.Exists(@"C:\Combofix.txt"))
                return;

            //const string path = @"C:\Combofix.txt";
            //var dir = new DirectoryInfo(path);
            string filepath = @"C:\Combofix.txt";
            tConsole.Clear();
            tConsole.LoadFile(filepath, RichTextBoxStreamType.PlainText);
        }

        private void btnAdwcLog_Click(object sender, EventArgs e)
        {
            ReadADWCleanerLog();
        }
        private void btnMalwareLog_Click(object sender, EventArgs e)
        {
            ReadMalwarebytesLog();//Nao esta correto!
        }
        private void btnCombLog_Click(object sender, EventArgs e)
        {
            ReadCombofixLog();
        }
        #endregion

        #region Aplicativos

        private void StartAdwcleaner()
        {
            if (File.Exists(@"C:\ProgramData\SuporteUpdater\AdwCleaner.exe"))
            {
                File.Delete(@"C:\ProgramData\SuporteUpdater\AdwCleaner.exe");
                tConsole.Text = "Atualizando...";
                tConsole.Text += "\nIniciando Download... Aguarde.";
                //FileToDownload = "https://onedrive.live.com/download?cid=A24F44861BB6D250&resid=A24F44861BB6D250%21371&authkey=ALv4oIYKZI6bK0o";
                FileToDownload = "https://adwcleaner.malwarebytes.com/adwcleaner?channel=release";
                DownloadApplication();
            }
            else
            {
                tConsole.Text += "\nIniciando Download... Aguarde.";
                FileToDownload = "https://adwcleaner.malwarebytes.com/adwcleaner?channel=release";
                DownloadApplication();
            }
        }

        private void StartMalwareBytes()
        {
            //C:\Program Files (x86)\Malwarebytes Anti-Malware
            if (!File.Exists(@"C:\Program Files (x86)\Malwarebytes Anti-Malware\mbam.exe"))
            {
                if (!File.Exists(@"C:\ProgramData\SuporteUpdater\MBSetup.exe"))
                {
                    tConsole.Text = "Arquivo não existe...";
                    tConsole.Text += "\nIniciando Download...";
                    FileToDownload = "https://www.malwarebytes.com/api/downloads/mb-windows?filename=MBSetup.exe";
                    DownloadApplication();
                }
                else
                {
                    Process.Start(@"C:\ProgramData\SuporteUpdater\MBSetup.exe");
                }

            }
            else
                try
                {
                    Process.Start(@"C:\Program Files (x86)\Malwarebytes Anti-Malware\mbam.exe");
                }
                catch (Exception)
                {
                    tConsole.Text = "Erro: Verificar Existencia do arquivo Mbam";

                }
        }

        private void StartJRT()
        {
            if (File.Exists(@"C:\ProgramData\SuporteUpdater\JRT.exe"))
            {
                File.Delete(@"C:\ProgramData\SuporteUpdater\JRT.exe");
                tConsole.Text = "Atualizando...";
                tConsole.Text += "\nIniciando Download... Aguarde.";
                FileToDownload = "http://thisisudax.org/downloads/JRT.exe";
                fileflag = "JRT";
                DownloadApplication();
            }
            else
            {
                tConsole.Text += "\nIniciando Download... Aguarde.";
                FileToDownload = "http://thisisudax.org/downloads/JRT.exe";
                DownloadApplication();
            }
        }
        private void StartHijackThis()
        {
            if (!File.Exists(@"C:\ProgramData\SuporteUpdater\HijackThis.exe"))
            {
                if (!File.Exists(@"C:\ProgramData\SuporteUpdater\HijackThis.exe"))
                {
                    tConsole.Text = "Arquivo não existe...";
                    tConsole.Text += "\nIniciando Download...";
                    FileToDownload = "http://ufpr.dl.sourceforge.net/project/hjt/2.0.5%20beta/HijackThis.exe";
                    DownloadApplication();
                }
                else
                {
                    Process.Start(@"C:\ProgramData\SuporteUpdater\HijackThis.exe");
                }

            }
            else
                try
                {
                    Process.Start(@"C:\ProgramData\SuporteUpdater\HijackThis.exe");
                }
                catch (Exception)
                {
                    tConsole.Text = "Erro: Verificar Existencia do arquivo HJT";

                }
        }
        private void StartAutoruns()
        {
            if (File.Exists(@"C:\ProgramData\SuporteUpdater\Autoruns.zip"))
            {
                File.Delete(@"C:\ProgramData\SuporteUpdater\Autoruns.zip");
                tConsole.Text = "Atualizando...";
                tConsole.Text += "\nAtenção - Detectado o uso de ferramenta avançada.";
                tConsole.Text += "\nIniciando Download...";
                FileToDownload = "http://download.sysinternals.com/files/Autoruns.zip";
                DownloadApplication();
            }
            else
                try
                {
                    tConsole.Text += "\nIniciando Download...";
                    FileToDownload = "http://download.sysinternals.com/files/Autoruns.zip";
                    DownloadApplication();
                }
                catch (Exception)
                {
                    tConsole.Text = "Erro: Verificar Existencia do arquivo ComboFix";

                }
        }

        private void StartCCleaner()
        {
            if (!File.Exists(@"C:\Program Files\CCleaner\CCleaner64.exe") || !File.Exists(@"C:\Program Files\CCleaner\CCleaner.exe"))
            {
                tConsole.Text += "Iniciando o download - CCleaner";
                FileToDownload = "https://bits.avcdn.net/productfamily_CCLEANER/insttype_FREE/platform_WIN_PIR/installertype_ONLINE/build_RELEASE/cookie_mmm_ccl_012_999_a7i_m";
                DownloadApplication();
            }
            else
            {
                try
                {
                    Process.Start(@"C:\Program Files\CCleaner\CCleaner64.exe");
                }
                catch (Exception)
                {
                    Process.Start(@"C:\Program Files\CCleaner\CCleaner.exe");
                }

            }
        }
        private void btnAdwCleaner_Click(object sender, EventArgs e)
        {
            fileflag = "AdwCleaner";
            StartAdwcleaner();
        }

        private void btnMalwareBytes_Click(object sender, EventArgs e)
        {
            fileflag = "MalwareBytes";
            StartMalwareBytes();

        }
        private void btnCCleaner_Click(object sender, EventArgs e)
        {
            fileflag = "CCleaner";
            StartCCleaner();
        }
        private void btnComboFix_Click(object sender, EventArgs e)
        {
            fileflag = "Autoruns";
            StartAutoruns();

        }

        private void btnHijackthis_Click(object sender, EventArgs e)
        {
            fileflag = "HijackThis";
            StartHijackThis();
        }
        #endregion

        #region Remover BTN

        private static void RecursiveDelete(DirectoryInfo baseDir)
        {
            if (!baseDir.Exists)
                return;

            foreach (var dir in baseDir.EnumerateDirectories())
            {
                try
                {
                   // tConsole.Text += "\n\rDel> " + dir;
                    RecursiveDelete(dir);
                }
                catch (Exception)
                {
                }
               
            }

            try
            {
                baseDir.Delete(true);
            }
            catch (Exception)
            {
            }
            
        }

        private static void RemoverData()
        {
            // MessageBox.Show("Dentro do Remover");
            var folder1 = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            var folder2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            try
            {
                if (Directory.Exists(folder1))
                {
                     DirectoryInfo directory = new DirectoryInfo(folder1);
                    // foreach (FileInfo file in directory.GetFiles()) file.Delete();
                    // foreach (Directory dirs in directory.GetDirectories()) dirs.Delete();
                    // Directory.Delete(Program.UpdateDir, true);
                   RecursiveDelete(directory);
                }

                if (Directory.Exists(folder2))
                {
                    DirectoryInfo directory2 = new DirectoryInfo(folder2);
                    // foreach (FileInfo file in directory.GetFiles()) file.Delete();
                    // foreach (Directory dirs in directory.GetDirectories()) dirs.Delete();
                    // Directory.Delete(Program.UpdateDir, true);
                    RecursiveDelete(directory2);
                }

            }
            catch (Exception)
            {
                // MessageBox.Show(exception.ToString());
            }

        }

        private void RemoverAplicativo()
        {
            // MessageBox.Show("Dentro do Remover");
            try
            {
                MarktoDelete();
                CRegistros.RemoveTrialKeys();
                CRegistros.RemovePermKey();
              
                cAtivacao.UnlockTaskManager();
                cAtivacao.EnablePanelControl();

                cAtivacao.UnLockAppsFiles();
                tConsole.Text += "\nRegistros de ativação resetados.";
                CRegistros.StartupRemover();
                tConsole.Text += "\nRegistros de inicialização deletados.";
               
                CRegistros.RemoveMainRegFolder();//LAST

                tConsole.Text += "\nRegistros principais deletados.";

                if (Directory.Exists(Program.UpdateDir))
                {
                    DirectoryInfo directory = new DirectoryInfo(Program.UpdateDir);
                    foreach (FileInfo file in directory.GetFiles()) file.Delete();
                    Directory.Delete(Program.UpdateDir, true);
                    tConsole.Text += "\nDiretórios deletados.";
                }

                tConsole.Text += "\nAplicativo configurado para ser deletado no próximo boot.";

            }
            catch (Exception e )
            {
                tConsole.Text += @"Erro <------------- \n" + e.ToString();
            }

        }
        private void btnRemoverSup_Click(object sender, EventArgs e)
        {
            DialogResult removerApliResult = MessageBox.Show("Remover a Central?", "Remoção da Central", MessageBoxButtons.OKCancel);
            if (removerApliResult == DialogResult.Cancel)
                return;

            tConsole.Clear();
            tConsole.Text = "Atenção: Iniciando remoção completa do aplicativo!";
            RemoverAplicativo(); 
            _forcedExit = true;
        }
        internal enum MoveFileFlags
        {
           // MOVEFILE_REPLACE_EXISTING = 1,
           // MOVEFILE_COPY_ALLOWED = 2,
            MOVEFILE_DELAY_UNTIL_REBOOT = 4,
           // MOVEFILE_WRITE_THROUGH = 8
        }

        //DELETE AFTER REBOOT
        [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "MoveFileEx")]
        internal static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName,
        MoveFileFlags dwFlags);
        private static void MarktoDelete()
        {
            MoveFileEx(Program.ApplicationExe, null, MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT);
            string TaskUsername = "Suporte_" + cUtils.GetCurrentUserName();

            if (File.Exists(@"C:\Windows\System32\Tasks\" + TaskUsername))
                MoveFileEx(@"C:\Windows\System32\Tasks\" + TaskUsername, null, MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT);

            // if (Directory.Exists(Program.UpdateDir))
            //   MoveFileEx(Program.UpdateDir, null, MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT);
        }

        private void btnForceAtvCheck_Click(object sender, EventArgs e)
        {
            tConsole.Clear();
            tConsole.Text = "\nReinicando a verificação da Ativação";
            //cAtivacao.Iniciar();
            tConsole.Text += "\nAtivado => " + cAtivacao.GetAtivStatus();
            tConsole.Text += "\nVerificação terminada";
        }

        #endregion

        #region Console

        List<string> normaList = new List<string>
        {
            "olá","ola","oi","tchau","oii","sim","nao","n","não","s","ok","bye","bobo","coco","puto",
        };
        List<string> execList = new List<string>
        {
            "exec","executar","iniciar","start","get",
        };

        private void FindinLineaString()
        {
            // string tosearch = search.ToLower();
            string[] tLineStrings = tConsole.Lines;
            foreach (var line in tLineStrings)
            {

                if (line.Equals("help") || line.Equals("Help"))
                {
                    tConsole.Clear();
                    tConsole.Text += "Mostrando CMDs\n";
                    tConsole.Text += "\nclear;cls;limpar";
                    tConsole.Text += "\nquit;exit;sair;close";
                    tConsole.Text += "\nexecutar;exec;set;iniciar;force;forçar;forcequit";
                    tConsole.Text += "\nget adobe; get taskstart";
                    break;
                }

                if (line.Equals("GetInfo", StringComparison.OrdinalIgnoreCase) || line.Equals("Get Info", StringComparison.OrdinalIgnoreCase))
                {
                    tConsole.Clear();
                    tConsole.Text += "Mostrando Informações\n";
                    tConsole.Text += "\nAppPath: " + Program.ApplicationExe;
                    tConsole.Text += "\nDebug: " + Program.Debug;
                    tConsole.Text += "\nLT: " + Program.LTInstalled;
                    tConsole.Text += "\nPP: " + Program.PPInstalled;
                    tConsole.Text += "\nPP LT: " + Program.PPandLT;
                    tConsole.Text += "\nPhostoshopExePath: " + cEditor.GetPhostoshopExePath();
                    tConsole.Text += "\nPremiereProExePath: " + cEditor.GetPremiereProExePath();
                    tConsole.Text += "\nLightRoomExePath: " + cEditor.GetLightRoomExePath();
                    tConsole.Text += "\nMediaCacheDir: " + cEditor.GetMediaCacheDir();
                    tConsole.Text += "\nAdministrador: " + IsAdministrator();
                    tConsole.Text += "\nAviso de Revisao: " + CRegistros.GetSetDataRetornoRevisao;
                    tConsole.Text += "\nAviso de Virus Email: " + CRegistros.GetSetEmailAlert;
                    break;
                }
                //cVars
                if (line.Equals("clear") || line.Equals("cls") || line.Equals("limpar"))
                {
                    tConsole.Clear();
                    break;
                }
                if (line.Equals("scan"))
                {
                    tConsole.Clear();
                    tConsole.Text += @"Iniciando Scan de integridade...\n";
                    cIntegridade.StartSystemCheck();
                    tConsole.Text += "\nFinalizado";
                    break;
                }

                if (line.Equals("forcequit"))
                {
                    Application.Exit();
                    break;
                }
                if (line.Equals("quit", StringComparison.OrdinalIgnoreCase) || line.Equals("exit", StringComparison.OrdinalIgnoreCase) || line.Equals("sair", StringComparison.OrdinalIgnoreCase) || line.Equals("close", StringComparison.OrdinalIgnoreCase))
                {
                    Close();
                    break;
                }
                if (normaList.Contains(line))//Normal words
                {
                    tConsole.Clear();
                    tConsole.Text += "\nComando Inválido: Você é algum retardado ?";
                }
                if (execList.Any(line.Contains))// Execs cvars
                {
                    if (line.Equals("taskstart"))
                    {
                        string commandstart = "Schtasks.exe /Create /TN TaskUsername  /RU \" Environment.UserName /RL HIGHEST /SC ONLOGON /TR \"\\\"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Maintenance\\Suporte.exe\\\"";
                        //Schtasks /Create /TN SuporteStart /RU Lab /RL HIGHEST /SC ONLOGON /TR "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Maintenance\Suporte.exe"
                        tConsole.Text += commandstart;
                        break;
                    }
                    if (line.Contains("combofix"))//combofix
                    {
                        StartAutoruns();
                        break;
                    }
                    if (line.Contains("malwarebytes"))//combofix
                    {
                        StartMalwareBytes();
                        break;
                    }
                    if (line.Contains("adwcleaner"))//combofix
                    {
                        StartAdwcleaner();
                        break;
                    }
                    if (line.Contains("hijack"))//combofix
                    {
                        StartHijackThis();
                        break;
                    }
                    if (line.Contains("cachedir"))
                    {
                        tConsole.Text += cEditor.GetMediaCacheDir();
                        break;
                    }
                    if (line.Contains("ativação") || line.Contains("ativar"))//Forçar ativação
                    {
                        tConsole.Text += "\nforçando ativação aguarde...";
                        cAtivacao.SetFullActivated();
                        tConsole.Text += "\nPronto !";
                        break;
                    }
                    if (line.Contains("update"))//Forçar ativação
                    {
                        tConsole.Text += "\nforçando update aguarde...";
                        StartUpdater();
                        tConsole.Text += "\nPronto !";
                        break;
                    }
                    if (line.Contains("administrativo"))//Forçar ativação
                    {
                        tConsole.Text += "\nSetando este PC como Administrativo...";
                        SetAdministrativo();
                        if (CRegistros.Administrativo)
                            chkbxSetAdm.CheckState = CheckState.Checked;
                        tConsole.Text += "\nPronto !";
                        Refresh();
                        break;
                    }
                    if (line.Contains("admin"))//Forçar ativação
                    {
                        tConsole.Text += "\nSetando este PC como Administrador...";
                        SetTecnico();
                        if (CRegistros.Tecnico)
                            chkbxsetOwner.CheckState = CheckState.Checked;
                        tConsole.Text += "\nPronto !";
                        Refresh();
                        break;
                    }
                    if (line.Contains("lockstatus"))//status dos apps
                    {
                        tConsole.Text += "\nStatus dos Apps: "+ CRegistros.GetSystemLockStatus();
                        Refresh();
                        break;
                    }
                }

            }
            //tConsole.Clear();
        }
        private void ExecFromConsole()
        {
            FindinLineaString();
        }

        private void tConsole_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ExecFromConsole();
            }
        }
        #endregion

        #region ToolStripBTN

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StartWithArgs(@"C:\Windows\regedit.exe", null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            StartWithArgs(@"eventvwr.msc", "/s");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            StartWithArgs(@"msconfig.exe", null);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            StartWithArgs(@"gpedit.msc", null);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            StartWithArgs(@"compmgmt.msc", "/s");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            StartWithArgs(@"services.msc", null);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            StartWithArgs(@"WF.msc", null);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            StartWithArgs(@"Netplwiz.exe", null);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            StartWithArgs(@"rstrui.exe", null);
        }
        private void gerenciadorDeDiscosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"c:\\windows\\System32\\diskmgmt.msc");
        }

        private void adaptadoresDeRedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cUtils.StartWithArgs(@"c:\\windows\\System32\\control.exe", "Ncpa.cpl");
        }

        private void controleDeDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cUtils.StartWithArgs(@"c:\\windows\\System32\\printui.exe", "/s /t2");

        }
        #endregion

        #region SERVERCOMMANDS

        //SERVER COMMANDS - REMOTE UNINSTALL
        public static void ReadServerCommands()
        {
            if (!cUtils.ConnectionAvailable()) return;

            // frmValidar fvalidar = (frmValidar)Application.OpenForms["frmValidar"];
            if (!File.Exists(Program.UpdateDir + "\\SuporteCommands.xml")) { return; }
            //xmlDOCREADER
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                using (Stream s = File.OpenRead(Program.UpdateDir + "\\SuporteCommands.xml"))
                {
                    xmldoc.Load(s);

                    ReadGetInfo(xmldoc); //GETINFO

                    ReadServerCommands(xmldoc);
                }
            }
            catch (Exception)//supress error on downloaded not accessible
            {
            }
        }

        private static void ReadServerCommands(XmlDocument xdoc)
        {
            /*
            *       Modelo dentro do XML
            *      <GETINFO><GETINFO><Command>Cauan</Command></GETINFO></GETINFO>
            * 		<Cauan_Queiroz_Kehl><Editor><Command>UpdateSuporter</Command></Editor></Cauan_Queiroz_Kehl>
            */

            try
            {
                var pcname = CRegistros.GetComputerName(); //<- Nome do Computador/Usuario cadastrado - Usado para Chave
                var clientname = CRegistros.GetCliente(); //<- Nome da empresa ou cliente   CASESENSITIVE
                xdoc.Load(Program.UpdateDir + "\\SuporteCommands.xml");
                XmlNode node = xdoc.SelectSingleNode("SuportCommand/" + clientname.Replace(' ', '_') + "/" + pcname.Replace(' ', '_')); //Node principal+nome do cliente
                if (node == null) return;
                var selectSingleNode = node.SelectSingleNode("Command");

                if (selectSingleNode != null && selectSingleNode.InnerText == "Remove")//Desinstalar o Aplicativo.
                {
                    RemoverAplicativo();
                    cUtils.LogEmailSend("TaskCommandRemove -> " + "Atualizado com sucesso.");
                }

                if (selectSingleNode != null && selectSingleNode.InnerText == "RemoveDelete")//Desinstalar o Aplicativo.
                {
                    RemoverData();
                    cUtils.LogEmailSend("TaskCommandRemove -> " + "Removido Data!.");
                }

                //Suspender cliente nao com tempo de atraso ou sem pagar.
                if (selectSingleNode != null && selectSingleNode.InnerText == "BlockAll")
                {
                    cAtivacao.DisablePanelControl();
                    cAtivacao.LockAppsFiles();
                }
                if (selectSingleNode != null && selectSingleNode.InnerText == "UnBlockAll")
                {
                    cAtivacao.EnablePanelControl();
                    cAtivacao.UnLockAppsFiles();
                }
                //Desativar aplicativo - sistema entra em modo trial
                if (selectSingleNode != null && selectSingleNode.InnerText == "DeActivate")
                {
                    CRegistros.RemoveSerialKey();
                    //cUtils.DoRestart(); - setar restart depois q fazer o update de todos updaters
                }
                //Rebuild o suporte quando necessario
                if (selectSingleNode != null && selectSingleNode.InnerText == "UpdateSuporter")
                {
                    const string updaterExe = @"C:\ProgramData\SuporteUpdater\suporteupdater.exe";
                    if (File.Exists(updaterExe))
                    {
                        FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(updaterExe);
                        if (fvi.ProductVersion == "1.0.4.0")
                            cUtils.UpdaterRebuild();
                        else
                        {
                            return;
                        }
                        cUtils.LogEmailSend("TaskCommandUpdater -> " + "Atualizado com sucesso.");
                    }
                }
                //Força metodo novo de inicializaçao do aplicativo
                if (selectSingleNode != null && selectSingleNode.InnerText == "NewStartup")//Atualiza Metodo de inicializar o app
                {
                    try
                    {
                        CRegistros.SetnewStartupMethod();
                        cUtils.LogEmailSend("TaskCommandUpdateStart -> " + "Atualizado com sucesso.");
                    }
                    catch (Exception exception)
                    {
                        cUtils.LogEmailSend("TaskCommandNewStartup -> " + exception.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                cUtils.LogEmailSend("ServerCommands:> " + exception);
            }
            finally
            {
                try
                {
                    if (File.Exists(Program.UpdateDir + "\\SuporteCommands.xml"))
                        File.Delete(Program.UpdateDir + "\\SuporteCommands.xml");
                }
                catch (Exception)
                {
                }
            }
        }

        private static void ReadGetInfo(XmlDocument xdoc)
        {
            /*
            *       Modelo dentro do XML
            *      <GETINFO><GETINFO><Command>Cauan</Command></GETINFO></GETINFO>
            * 		<Cauan_Queiroz_Kehl><Editor><Command>UpdateSuporter</Command></Editor></Cauan_Queiroz_Kehl>
            */

            var clientname = CRegistros.GetCliente(); //<- Nome da empresa ou cliente   CASESENSITIVE
            // XmlDocument xmldoc = new XmlDocument();

            try //TMPORARIO!
            {
                //   xmldoc.Load(Program.UpdateDir + "\\SuporteCommands.xml");

                XmlNode node = xdoc.SelectSingleNode("SuportCommand/" + "GETINFO" + "/" + "GETINFO"); //Node especial
                if (node == null) return;
                var selectSingleNode = node.SelectSingleNode("Command");
                if (selectSingleNode != null && clientname.Contains(selectSingleNode.InnerText))
                {
                    try
                    {
                        cUtils.LogEmailSend("TaskCommandGetInfo -> " + "Username: [" + cUtils.GetCurrentUserName() +
                                            "] PC: [" + CRegistros.GetComputerName() + "] Cliente: [" +
                                            CRegistros.GetCliente() + "] UpdaterVer: [" + cUtils.GetUpdaterVersion() +
                                            "] IsAdmin: " + IsAdministrator());
                    }
                    catch (Exception exception)
                    {
                        cUtils.LogEmailSend("TaskCommandNewStartup -> " + exception.ToString());
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        //CheckedChanged event occurs when the value of the Checked property changes. 
        //The CheckStateChanged event occurs when the value of the CheckState property changes.
    }
}
