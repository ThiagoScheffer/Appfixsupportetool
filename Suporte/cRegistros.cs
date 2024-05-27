using System;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Suporte
{
    static class CRegistros
    {

        //MAIN VARS
        private static string adobever = "";
        static readonly RegistryKey CentralKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\CentraldeSuporte");
        private static readonly RegistryKey OneDrive = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\OneDrive");
        private const string RegLmPolicies = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";//Local

        //2023
        //static readonly RegistryKey RegSoftAdobe = Registry.LocalMachine.GetValue(@"SOFTWARE\Adobe");
        private const string RegSoftAdobe = @"SOFTWARE\Adobe";//LOCAL



        private static readonly string TaskUsername = "Suporte_" + cUtils.GetCurrentUserName().Replace(" ","");
        public static void SetnewStartupMethod()
        {
            //Schtasks /Create /TN SuporteStart /RU Lab /RL HIGHEST /SC ONLOGON /TR "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Maintenance\Suporte.exe"
            StartupRemover();

            //Tasks Control
            if (Directory.Exists(@"C:\Windows\System32\Tasks")) GrantAccess(@"C:\Windows\System32\Tasks");
            string username = Environment.UserName;
            if (!File.Exists(@"C:\Windows\System32\Tasks\" + TaskUsername))
            cUtils.StartWithArgs("C:\\Windows\\System32\\Schtasks.exe", " /Create /TN " + TaskUsername + " /RU \"" + username + "\" /RL HIGHEST /SC ONLOGON /TR \"\\\"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Maintenance\\Suporte.exe\\\"");

        }


        
        //VERIFICA TERMOS ACEITOS
        public static void TermosdeGarantia()
        {
            if (CentralKey.GetValue("Termos") != null) return;
            using (Garantia frmgarantia = new Garantia())
            {
                frmgarantia.ShowDialog();
            }
        }

  

        #region WRITERS
        //REGISTRA TODAS AS CHAVES PRIMARIAS PARA O FUNCIONAMENTO DO APLICATIVO EDITOR

        public static string LoadAdobeInfoFromReg(string value)
        {
                try
                {   //VERSION DEFAULT -> carregar no inicio
                    if (value == "premierever")
                    {
                        using (
                            RegistryKey dataKey =
                                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Adobe\Premiere Pro\CurrentVersion\"))
                        {
                            if (dataKey != null)
                            {
                                adobever = (string)dataKey.GetValue(@"");
                                return (string) dataKey.GetValue(@"");
                            }
                            return null;
                        }
                    }

                if (value == "mediacache")
                {
                    if (adobever == null) return null;

                    using (RegistryKey dataKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Adobe\Common " + adobever + "\\Media Cache")) 
                    
                    {
                        if (dataKey != null)
                        {
                            return (string)dataKey.GetValue(@"FolderPath")+ "\\Media Cache Files";
                        }
                        return null;
                    }
                }

                if (value == "premierepath")
                {
                    using (
                        RegistryKey dataKey =
                            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Adobe Premiere Pro.exe\"))
                    {
                        if (dataKey != null)
                        {
                            return (string)dataKey.GetValue(@"Path");
                        }
                        return null;
                    }
                }

                if (value == "lightroompath")
                {
                    using (
                        RegistryKey dataKey =
                            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\Adobe.AdobeLightroom\"))
                    {
                        if (dataKey != null)
                        {
                            return (string)dataKey.GetValue(@"DefaultIcon").ToString().Replace("Lightroom.exe","");
                        }
                        return null;
                    }
                }

                if (value == "photoshoppath")
                {
                    using (
                        RegistryKey dataKey =
                            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\adbps\DefaultIcon\"))
                    {
                        if (dataKey != null)
                        {
                            return (string)dataKey.GetValue(@"").ToString().Replace("Photoshop.exe,2", "");
                        }
                        return null;
                    }
                }
            }
                catch (Exception)
                {
                    //MessageBox.Show(e.ToString());
                    return null;
                }

            return null;
        }


        public static void WriteFirstTimeCentralDef()
        {
            //SE FOR !NULL = JA FORAM FEITAS AS ALTERAÇOES ENTAO IGNORAR
            if (CentralKey.GetValue("Administrativo") != null) return;
            CentralKey.SetValue("Administrativo", "False");
            CentralKey.SetValue("Tecnico", "True");//facilitar alteraçoes 1x

            if (CentralKey.GetValue("ScreenPosition") != null)//3089 Remover
            {
                CentralKey.SetValue("WindowPosition", "rightcorner");
                CentralKey.DeleteValue("ScreenPosition");
            }

            if (CentralKey.GetValue("WindowPosition") == null)
                CentralKey.SetValue("WindowPosition", "rightcorner", RegistryValueKind.String);

            if (CentralKey.GetValue("SendEmailAlert") == null)
                CentralKey.SetValue("SendEmailAlert", "False", RegistryValueKind.String);
           
           //SETA AS PERMISSOES NECESSARIAS PARA O FUNCIONAMENTO
            SetFullKeyAccess();

            //Editor Gravar 1 Vez Variaveis
            if(Program.PPInstalled || Program.LTInstalled)
            cEditor.WriteAllValuestoRegistry();

            //Tasks Control
            if (Directory.Exists(@"C:\Windows\System32\Tasks")) GrantAccess(@"C:\Windows\System32\Tasks");

            if (!File.Exists(@"C:\Windows\System32\Tasks\" + TaskUsername))
                cUtils.StartWithArgs("C:\\Windows\\System32\\Schtasks.exe", " /Create /TN " + TaskUsername + " /RU \"" + Environment.UserName + "\" /RL HIGHEST /SC ONLOGON /TR \"\\\"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Maintenance\\Suporte.exe\\\"");
        }

        public static void WriteUseStaticCacheDir(bool value)
        {
            CentralKey.SetValue("UseStaticCache", value, RegistryValueKind.String);
        }
        public static void WriteFirstTimeEditorKeys()
        {
            //PP Fix
            if (CentralKey == null) return;
            if (CentralKey.GetValue("PPDefFile") == null)
                CentralKey.SetValue("PPDefFile", "");

            if (CentralKey.GetValue("PPFolderVer") == null)
                CentralKey.SetValue("PPFolderVer", "");

            if (CentralKey.GetValue("PPPreviewDir") == null)
                CentralKey.SetValue("PPPreviewDir", "");

            if (CentralKey.GetValue("PPMediaCacheDir") == null)
            {
                CentralKey.SetValue("PPMediaCacheDir", "");
                CentralKey.SetValue("PPMediaCacheDB", "");
            }
        }

        public static void WriteSerialKey(string key)
        {
           // if (centralKey.GetValue("SerialKey") != null) return;
            CentralKey.SetValue("SerialKey", "");
            CentralKey.SetValue("SerialKey", key, RegistryValueKind.String);
            CentralKey.Flush();
        }

        public static void WriteLockModeStatus()
        {
            // if (centralKey.GetValue("SerialKey") != null) return;
            CentralKey.SetValue("System", "");
            CentralKey.SetValue("System", "Locked");
        }

        public static bool GetSystemLockStatus()
        {
            if(CentralKey != null && CentralKey.GetValue("System") == null)
                CentralKey.SetValue("System", "Unlocked");
            
            return CentralKey.GetValue("System").ToString() == "Locked";
        }

        public static void WriteUnLockModeStatus()
        {
            // if (centralKey.GetValue("SerialKey") != null) return;
            CentralKey.SetValue("System", "UnLocked");
        }
        public static void RemoveSerialKey()
        {
            CentralKey.SetValue("SerialKey", "");
        }


        public static void WriteAgendaPath(string path)
        {
            if(CentralKey.GetValue("AgendaPath") == null)
            {
                CentralKey.SetValue("AgendaPath", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Eventos.xml");
            }
            else
            {
                CentralKey.SetValue("AgendaPath",path);
            }
        }
        #endregion

        #region GETSET
        //Envia um aviso de trojan para a fix, uso exclusivo de PC contabilidade.Segurança
        public static string GetSetEmailAlert
        {
            get
            {
                try
                {
                    if(CentralKey.GetValue("SendEmailAlert") == null)
                    CentralKey.SetValue("SendEmailAlert", "False");

                    return CentralKey.GetValue("SendEmailAlert").ToString();
                }
                catch (Exception)
                {
                    //MessageBox.Show(e.ToString());
                    return null;
                }
            }
            set
            {
                CentralKey.SetValue("SendEmailAlert",value);
            }
        }

        //Aviso para o cliente de que passou 2 Meses e é aconselhavel a revisao do PC
        public static string GetSetDataRetornoRevisao
        {
            get
            {
                try
                {
                    if (CentralKey.GetValue("AvisoRevisao") == null)
                        CentralKey.SetValue("AvisoRevisao", "False");//se for falso não havera msg de aviso

                    return CentralKey.GetValue("AvisoRevisao").ToString();
                }
                catch (Exception)
                {
                    //MessageBox.Show(e.ToString());
                    return null;
                }
            }
            set { CentralKey.SetValue("AvisoRevisao", value == "False" ? "False" : value); }
        }

        //Windows Defender
        public static string GetSetWinDef
        {
            //0 = Enable
            get
            {
                try
                {
                    using (RegistryKey dataKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender"))
                    {
                        if (dataKey != null && dataKey.GetValue("DisableAntiSpyware") == null)
                            dataKey.SetValue("DisableAntiSpyware",1);//SE nao existir a chave criar e setar desativado

                        if (dataKey != null && dataKey.GetValue("DisableAntiSpyware") != null)
                            return dataKey.GetValue("DisableAntiSpyware").ToString();
     
                        return null;
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(e.ToString());
                    return null;
                }
            }
            set
            {
                using (RegistryKey dataKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender"))
                {
                    if (dataKey != null)
                        dataKey.SetValue("DisableAntiSpyware", value, RegistryValueKind.DWord);
                }
            }
        }
        public static string GetSetUac
        {
            get
            {
                try
                {
                    using (RegistryKey dataKey = Registry.LocalMachine.OpenSubKey(RegLmPolicies))
                    {
                        if (dataKey != null && dataKey.GetValue("EnableVirtualization") != null)
                            return dataKey.GetValue("EnableVirtualization").ToString();
                        //Retorna o valor ativo 1 = ativo 0 - desativado
                        return null;
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(e.ToString());
                    return null;
                }
            }
            set
            {
                using (RegistryKey dataKey = Registry.LocalMachine.CreateSubKey(RegLmPolicies))
                {
                    if (dataKey != null && dataKey.GetValue("EnableVirtualization") != null)
                        dataKey.SetValue("EnableVirtualization", value,RegistryValueKind.DWord);
                }
            }
    }

        public static string GetSetSmartscreen
        {
            get
            {
                using (RegistryKey dataKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer"))
                {
                    if (dataKey != null && dataKey.GetValue("SmartScreenEnabled") != null)
                        return dataKey.GetValue("SmartScreenEnabled").ToString();//Retorna o valor ativo = On ou Off
                    return null;
                }
            }
            set
            {
                try
                {
                    using (RegistryKey dataKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer"))
                    {
                        if (dataKey != null && dataKey.GetValue("SmartScreenEnabled") != null)
                            dataKey.SetValue("SmartScreenEnabled", value, RegistryValueKind.String);
                    }
                }
                catch (Exception)
                {

                   // MessageBox.Show(e.ToString());
                }

            }
        }

        public static string GetSetUsbReader
        {
            get
            {
                using (RegistryKey dataKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\USBSTOR"))
                {
                    if (dataKey != null && dataKey.GetValue("Start") != null)
                        return dataKey.GetValue("Start").ToString();//Retorna o valor ativo = 3 normal - 4 desabilitado
                    return null;
                }
            }
            set
            {
                using (RegistryKey dataKey = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\USBSTOR"))
                {
                    if (dataKey != null && dataKey.GetValue("Start") != null)
                        dataKey.SetValue("Start", value,RegistryValueKind.DWord);
                }
            }
        }

        public static string GetSetHibernation
        {
            //HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power
            get
            {
                using (RegistryKey dataKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Power"))
                {
                    if (dataKey != null && dataKey.GetValue("HibernateEnabled") != null)
                        return dataKey.GetValue("HibernateEnabled").ToString();//Retorna o valor ativo = 1 normal - 0 desabilitado
                    return null;
                }
            }
            set
            {
                using (RegistryKey dataKey = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Power"))
                {
                    if (dataKey != null && dataKey.GetValue("HibernateEnabled") != null)
                        dataKey.SetValue("HibernateEnabled", value, RegistryValueKind.DWord);
                }
            }
        }
           
        public static string GetSetFirewall
        {
            //HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\SharedAccess\Defaults\FirewallPolicy\StandardProfile 
            get
            {
                using (RegistryKey dataKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Services\SharedAccess\Defaults\FirewallPolicy\StandardProfile"))
                {
                    if (dataKey != null && dataKey.GetValue("EnableFirewall") != null)
                        return dataKey.GetValue("EnableFirewall").ToString();//Retorna o valor ativo = 1 normal - 0 desabilitado
                    return null;
                }
            }
            set
            {
                using (RegistryKey dataKey = Registry.LocalMachine.CreateSubKey(@"SYSTEM\ControlSet001\Services\SharedAccess\Defaults\FirewallPolicy\StandardProfile"))
                {
                    if (dataKey != null && dataKey.GetValue("EnableFirewall") != null)
                        dataKey.SetValue("EnableFirewall", value, RegistryValueKind.DWord);
                }
            }
        }
		
        #endregion

        #region SET VALUES
        private static void SetFullKeyAccess()
        {
            using (RegistryKey allowed = Registry.LocalMachine.OpenSubKey(RegLmPolicies, true))
            {
                if (allowed.GetValue(cUtils.UserDomainName) != null)
                {
                    if (allowed.GetValue(cUtils.UserDomainName).ToString() == cUtils.UserDomainName)
                        return;
                }
                else
                {
                    allowed.SetValue(cUtils.UserDomainName, cUtils.UserDomainName, RegistryValueKind.String);
                    allowed.Close();
                }
            }
            if (Directory.Exists(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Maintenance"))
                GrantAccess(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Maintenance");

            GrantRegistryAccess(@"SOFTWARE\CentraldeSuporte", "local");
            GrantRegistryAccess(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "local");
            GrantRegistryAccess(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", "local");
            GrantRegistryAccess(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "local");
            GrantRegistryAccess(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", "local");
            GrantRegistryAccess(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "local");

            GrantRegistryAccess(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "user");
            GrantRegistryAccess(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", "user");
            GrantRegistryAccess(@"Software\Microsoft\Windows\CurrentVersion\Run", "user");

            //Lock Unlock Ativação
            if (Directory.Exists(@"C:\Program Files (x86)\Photodex\ProShow Producer"))
                GrantAccess(@"C:\Program Files (x86)\Photodex\ProShow Producer");

            if (Directory.Exists(@"C:\ProgramData\Corel"))
                GrantAccess(@"C:\ProgramData\Corel");

            if (Directory.Exists(@"C:\ProgramData\Adobe"))
                GrantAccess(@"C:\ProgramData\Adobe");
            //Tasks Control
            if (Directory.Exists(@"C:\Windows\System32\Tasks"))
                GrantAccess(@"C:\Windows\System32\Tasks");
                GrantAccess(@"C:\Windows\System32\spool\PRINTERS");
                GrantAccess(@"C:\Windows\System32\spool\SERVERS");
        }

        public static string WindowLocation
        {
            get
            {
                if (CentralKey.GetValue("WindowPosition") == null)
                    CentralKey.SetValue("WindowPosition", "rightcorner");

                if (CentralKey.GetValue("WindowPosition").ToString() == "uppercorner")
                    return "1";
                if (CentralKey.GetValue("WindowPosition").ToString() == "center")
                    return "2";
                return "0";
            }
            set { CentralKey.SetValue("WindowPosition", value); }
        }

        public static bool Administrativo
        {
            get
            {
                if (CentralKey.GetValue("Administrativo") != null && CentralKey.GetValue("Administrativo").ToString() == "1")
                    CentralKey.SetValue("Administrativo", "True");

                return CentralKey.GetValue("Administrativo") != null && CentralKey.GetValue("Administrativo").ToString() == "True";
            }
            set { CentralKey.SetValue("Administrativo", value); }
        }

        public static bool Tecnico
        {
            get { return CentralKey.GetValue("Tecnico") != null && CentralKey.GetValue("Tecnico").ToString() == "True"; }
            set { CentralKey.SetValue("Tecnico", value); }
        }

        public static void SetDataValidade(string inicial, string final)
        {
            using (RegistryKey dataKey = Registry.LocalMachine.OpenSubKey(RegLmPolicies, true))
            {
                dataKey.SetValue("TrialStart", inicial);
                dataKey.SetValue("TrialEnd", final);
            }
        }

        public static void SetDiaPrazo(int inicio, int fim)
        {
            CentralKey.SetValue("PrazoInicial", inicio);
            CentralKey.SetValue("PrazoFinal", fim);
        }
    #endregion
        
        #region GET VALUES

        public static string GetOneDriveFolder()
        {
            return OneDrive.GetValue("UserFolder") == null ? " " : OneDrive.GetValue("UserFolder").ToString();
        }
        public static string GetLtCatFile()
        {
            return CentralKey.GetValue("LTCatFile") == null ? " " : CentralKey.GetValue("LTCatFile").ToString();
        }

        public static string GetLtDefFile()
        {
            return CentralKey.GetValue("LTDefFile") == null ? " " : CentralKey.GetValue("LTDefFile").ToString();
        }

        //public string GetCurrentCulture()
        //{
        //    return System.Threading.Thread.CurrentThread.CurrentCulture.Name;
        //}

        public static bool ValidateSerialKey(string key)
        {
            return CentralKey != null && (CentralKey.GetValue("SerialKey") != null && CentralKey.GetValue("SerialKey").ToString() == key);
        }

        //ESTE É O CADASTRO DO CLIENTE PARA PAGAMENTOS
        public static string GetCliente()
        {
            return CentralKey.GetValue("Cliente") == null ? "Não Cadastrado" : CentralKey.GetValue("Cliente").ToString();
        }
        //CADASTRA O CLIENTE E O USUARIO NO APLICATIVO
        public static void WriteRegisterPc(string cliente, string usuario)
        {
            CentralKey.SetValue("Cliente", cliente);//<- Empresa ou cliente
            CentralKey.SetValue("Computador", usuario);//<- Usuario do PC
            MessageBox.Show(@"Sistema Cadastrado.");
        }

        //ESTE É O NOME DE ATIVAÇAO UNICO DO PC
        public static string GetComputerName()
        {

            //REMOVER NA VERSAO 50
            if (CentralKey.GetValue("Usuario") != null)//Remove antigo Usuario e cria chave correta
            {
                CentralKey.SetValue("Computador", CentralKey.GetValue("Usuario").ToString());
                CentralKey.DeleteValue("Usuario");
            }
            return CentralKey.GetValue("Computador") == null ? "Não Cadastrado" : CentralKey.GetValue("Computador").ToString();
        }
        
        public static Tuple<string, string> GetDataValidade()
        {
            using (RegistryKey dataKey = Registry.LocalMachine.OpenSubKey(RegLmPolicies))
            {
                if (dataKey != null && dataKey.GetValue("TrialStart") != null)
                    return new Tuple<string, string>(dataKey.GetValue("TrialStart").ToString(), dataKey.GetValue("TrialEnd").ToString());
            }
            return new Tuple<string, string>("00/00/0000", "00/00/0000");
        }

        public static Tuple<int, int> GetDiaPrazo()
        {
            if (CentralKey.GetValue("PrazoInicial") != null)
                return new Tuple<int, int>(Convert.ToInt32(CentralKey.GetValue("PrazoInicial")), Convert.ToInt32(CentralKey.GetValue("PrazoFinal")));
            return new Tuple<int, int>(1,7);
        }

        public static string GetAgendaPath()
        {
            //1x = null ou emp
            if (CentralKey.GetValue("AgendaPath") == null)
            {
                CentralKey.SetValue("AgendaPath", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Eventos.xml");
                return CentralKey.GetValue("AgendaPath").ToString();
            }
            return CentralKey.GetValue("AgendaPath").ToString();
        }
        #endregion

        #region REMOVE CENTRAL
        public static void StartupRemover()
        {
            try
            {
                //HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run
                RegistryKey regStartup86 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                RegistryKey regStartup64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", true);
                RegistryKey regStartupUser = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

                if (regStartupUser.GetValue("Suporte") != null)
                    regStartupUser.DeleteValue("Suporte");

                //remove STARTUP
                if (regStartup64 != null)
                {
                    if (regStartup64.GetValue("Suporte") != null)
                        regStartup64.DeleteValue("Suporte");

                    if (regStartup86 != null && regStartup86.GetValue("Suporte") != null)
                        regStartup86.DeleteValue("Suporte");
                }

                if (regStartup64 != null) regStartup64.Close();
                if (regStartup86 != null) regStartup86.Close();
                regStartupUser.Close();
            }
            catch (Exception)
            {
                
            }

        }

        public static void RemoveMainRegFolder()
        {
            using (RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\CentraldeSuporte", true))
            {
                if(regKeyAppRoot != null)
                    Registry.LocalMachine.DeleteSubKeyTree(@"SOFTWARE\CentraldeSuporte", true);
            }
        }

        public static void RemovePermKey()
        {
            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System
            using (RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(RegLmPolicies, true))
            {
                if (regKeyAppRoot != null && regKeyAppRoot.GetValue(cUtils.UserDomainName) != null)
                    regKeyAppRoot.DeleteValue(cUtils.UserDomainName, true);
            }

            try
            {
                using (RegistryKey allowed = Registry.LocalMachine.OpenSubKey(RegLmPolicies, true))
                {
                    if (allowed.GetValue(cUtils.UserDomainName) != null)
                    {
                        if (allowed.GetValue(cUtils.UserDomainName).ToString() == cUtils.UserDomainName)
                            allowed.DeleteValue(cUtils.UserDomainName);
                    }
                }
            }
            catch(Exception)
            {}

        }

        public static void RemoveTrialKeys()
        {
            using (var regTrial = Registry.LocalMachine.OpenSubKey(RegLmPolicies, true))
            {
                using (var regWarning = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true))
                {
                    if (regWarning != null)
                    {
                        regWarning.SetValue("LegalNoticeCaption","");
                        regWarning.SetValue("LegalNoticeText", "");
                    }
                }
                //Se n existe Trial criar...
                if (regTrial != null && regTrial.GetValue("TrialStart") != null)
                {
                    regTrial.DeleteValue("TrialStart");
                    regTrial.DeleteValue("TrialEnd");
                }
            }
        }
        #endregion

        #region Master ADM SET

        private static void GrantRegistryAccess(string chave,string local)
        {
            if (local == "user")
            {
                try
                {
                    using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(chave, true))
                    {
                        RegistrySecurity rs = new RegistrySecurity();
                        rs.AddAccessRule(new RegistryAccessRule("Todos", RegistryRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        if (rk != null) rk.SetAccessControl(rs);
                        if (rk != null) rk.Dispose();
                    }
                }
                catch (Exception)
                {

                   // MessageBox.Show(e.ToString() + "\n" + chave);
                    using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(chave, true))
                    {
                        RegistrySecurity rs = new RegistrySecurity();
                        rs.AddAccessRule(new RegistryAccessRule("Everyone", RegistryRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        if (rk != null) rk.SetAccessControl(rs);
                        if (rk != null) rk.Dispose();
                    }

                }

            }
            else
            {
                try
                {
                    using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(chave, true))
                    {
                        RegistrySecurity rs = new RegistrySecurity();
                        rs.AddAccessRule(new RegistryAccessRule("Todos", RegistryRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        if (rk != null) rk.SetAccessControl(rs);
                        if (rk != null) rk.Dispose();
                    }
                }
                catch (Exception)
                {

                   // MessageBox.Show(e.ToString() + "\n" + chave);
                    using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(chave, true))
                    {
                        RegistrySecurity rs = new RegistrySecurity();
                        rs.AddAccessRule(new RegistryAccessRule("Everyone", RegistryRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        if (rk != null) rk.SetAccessControl(rs);
                        if (rk != null) rk.Dispose();
                    }

                }

            }
        }

        //TODO ADD Remover regra antiga antes de por a nova
        public static void GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();

            try
            {
                dSecurity.AddAccessRule(new FileSystemAccessRule("Todos", FileSystemRights.FullControl,
                InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                PropagationFlags.None, AccessControlType.Allow));
                dInfo.SetAccessControl(dSecurity);
            }
            catch (Exception)
            {
                dSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl,
                InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                PropagationFlags.None, AccessControlType.Allow));
                dInfo.SetAccessControl(dSecurity);
            }

        }

        #endregion


    }
}
