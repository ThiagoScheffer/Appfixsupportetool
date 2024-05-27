using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
//object test = Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\VisualStudio\\10.0", "FullScreen", null);
namespace Suporte
{
    class cEditor
    {
        private static long _dirPreviewCacheSize;
        private static long _dirMediaCacheSize;
        private static string _cacheSizeLabel,_previewSizeLabel;
        private static readonly bool IsPremiereCc = Directory.Exists(CRegistros.LoadAdobeInfoFromReg("premierepath"));
        private static readonly string PpDefaultProjectDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Adobe\Premiere Pro\";
        private static readonly string Roamingdir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string Programdir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        private static string _switch;
        private static readonly string Programx86 = Environment.GetEnvironmentVariable("PROGRAMFILES(X86)") ?? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        static readonly string TempXml = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Adobe\Premiere Pro\tempdef.xml";

        //nao pode ser Static um Opensubkey(precisa ser instanciado) apenas o Create.
        static readonly RegistryKey WriteToRegistryKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\CentraldeSuporte");
        //private static string MediaCacheDirFiles;
        private static readonly BackgroundWorker Worker = new BackgroundWorker();

        private static string premierever = CRegistros.LoadAdobeInfoFromReg("premierever");

        public static void WriteAllValuestoRegistry()
        {
            //FORCE SET CACHES TO DEFAULT HERE
            if (Program.LTInstalled)
            {
                WriteLightRoomDefFilePath();
                WriteLightRoomCatFilePath();
            }
            if (!Program.PPInstalled) return;
            WritePremiereDefFilePath();
            WriteAdobePremiereDirVersion();
            WritePremierePreviewDir();
            //WritePremiereMediaCacheDir();//3086 -> Grava no Suporte os diretorios
        }


        #region Premiere Pro
        //GRAVA NO REGISTRO DO PREMIERE OS CACHES <- SE FOR EXECUTADO DENTRO DO [ADMINISTRADOR] ENTAO OS REGISTROS SERAO CARREGADO APENAS POR AQUI
        //SERA DEFINIDO MANUALMENTE - PELO PAINEL ADM
        public static void WritetoDefaultCacheKeys()
        {
            //C:\Users\EncryptorX\AppData\Roaming\Adobe\Common\Media Cache
            if (WriteToRegistryKey.GetValue("UseStaticCache") == null)
            return;

            //Usar o Cache statico?
            if (WriteToRegistryKey.GetValue("UseStaticCache").ToString() == "False")
                return;
            
            if (string.IsNullOrEmpty(WriteToRegistryKey.GetValue("PPMediaCacheDir").ToString()))//1408
                return;
            //--------------------------------------------------------------------------------------//
            WriteMediaCacheDirtoCommonKey(WriteToRegistryKey.GetValue("PPMediaCacheDir").ToString().Replace(@"\Media Cache Files",""));//2906
        }

        //Grava no registro um diretorio especificado pelo aplicativo
        public static void WriteMediaCacheDirtoCommonKey(string path)
        {
            RegistryKey regAdobeCacheDir;

            if ((Registry.CurrentUser.OpenSubKey(@"Software\Adobe\Common "+ premierever + "\\Media Cache")) != null)// CC 2018
            {
                regAdobeCacheDir = Registry.CurrentUser.OpenSubKey(@"Software\Adobe\Common " + premierever + "\\Media Cache", true);
                regAdobeCacheDir.SetValue("FolderPath", path);// Este que contem os arquivos grandes
                regAdobeCacheDir.SetValue("DatabasePath", path);
                return;
            }

           
        }
        //write to reg mainapp suporte
        private static void WritePremiereDefFilePath()
        {
            try
            {
                string prefsfile = string.Empty;
                string prefsrestoredir = string.Empty;
                if (IsPremiereCc)
                {   //Profile-usuario
                    string username = Environment.UserName;

                    if (File.Exists(PpDefaultProjectDir + "\\"+premierever+ "\\profile-" + username + @"\Adobe Premiere Pro Prefs"))
                    {
                        prefsfile = PpDefaultProjectDir + "\\" + premierever + "\\profile-" + username + @"\Adobe Premiere Pro Prefs";
                    }
                    else
                    {
                        cUtils.LogEmailSend("WritePremiereDefFilePath error no PPdef found");
                    }
                   
                    
                    //MessageBox.Show("Def> "+prefsfile);
                    //MessageBox.Show("ProfDir> "+PpDefaultProjectDir);
                    WriteToRegistryKey.SetValue("PPDefFile", prefsfile);
                }

                //se nao for possivel localizar - algo errado nas definiçoes - iniciar restaurar.
                if (string.IsNullOrEmpty(prefsfile))
                {
                    try
                    {
                        //C:\Users\Studio\AppData\Roaming\Adobe\Premiere Pro
                        string DefFileBak = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                            @"\Adobe\Premiere Pro\BackupDef.bak";
                        if (!File.Exists(DefFileBak)) return;
                        File.Copy(DefFileBak, prefsrestoredir + "Adobe Premiere Pro Prefs", true);
                        WritePremiereDefFilePath();
                        return;
                    }
                    catch
                    {
                        cUtils.LogEmailSend("WritePremiereDefFilePath corrupted def file restoring");
                    }
                }

                WriteToRegistryKey.SetValue("PPDefFile", prefsfile);

                //Create a Backup 1º time
                try
                {
                    //C:\Users\Studio\AppData\Roaming\Adobe\Premiere Pro
                    string DefFileBak = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                        @"\Adobe\Premiere Pro\BackupDef.bak";
                    if (!File.Exists(DefFileBak))
                        File.Copy(prefsfile, DefFileBak, true);
                }
                catch
                {
                    cUtils.LogEmailSend("WritePremiereDefFilePath ppdef Backup created");
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.ToString());
            }
        }

        public static void WritePremiereStaticMediaCacheDir()
        {
            //C:\Users\EncryptorX\AppData\Roaming\Adobe\Common\Media Cache
            string mediaCacheDir = "";
            string mediaCacheDb = "";
            RegistryKey regAdobeCacheDir;

            if ((Registry.CurrentUser.OpenSubKey(@"Software\Adobe\Common "+premierever+"\\Media Cache")) != null)
            {
                regAdobeCacheDir = Registry.CurrentUser.OpenSubKey(@"Software\Adobe\Common " + premierever + "\\Media Cache");
                mediaCacheDir = regAdobeCacheDir.GetValue("FolderPath").ToString();// Este que contem os arquivos grandes
                mediaCacheDb = regAdobeCacheDir.GetValue("DatabasePath").ToString();
                WriteToRegistryKey.SetValue("PPMediaCacheDir", mediaCacheDir);
                WriteToRegistryKey.SetValue("PPMediaCacheDB", mediaCacheDb);
            }
        }

        private static void WriteAdobePremiereDirVersion() //-> \xx.0\ Grava no registro a Versao da Pasta
        {
            string premiereVersion = CRegistros.LoadAdobeInfoFromReg("premierever");
            if (WriteToRegistryKey != null) WriteToRegistryKey.SetValue("PPFolderVer", premiereVersion);
        }
        //PREVIEW DIR
        private static void WritePremierePreviewDir()
        {
            //Grava informaçoes do diretorio Preview no registro.
            //C:\Users\EncryptorX\Documents\Adobe\Premiere Pro\7.0\Adobe Premiere Pro Preview Files

            string PPDefFile = WriteToRegistryKey.GetValue("PPDefFile").ToString();//Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\CentraldeSuporte", "PPDefFile", null).ToString();
            string PPFolderVer = WriteToRegistryKey.GetValue("PPFolderVer").ToString();//Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\CentraldeSuporte", "PPFolderVer", null).ToString();

            //PARTE1
            try
            {
                //RepairFileXMLIfExist - se exite um arquivo temp, algo ocorreu errado na ultima atualizaçao do arquivo.
                if (File.Exists(TempXml) && File.Exists(PPDefFile))
                {
                    File.Delete(PPDefFile);
                    File.Move(TempXml, PPDefFile);
                }
                else//Criar um Arquivo Temporário
                    if (File.Exists(PPDefFile) && !File.Exists(TempXml))
                        File.Move(PPDefFile, TempXml);

                //Se nao foi criado o arquivo TEMP ignorar e retornar.
                if (!File.Exists(TempXml))
                {
                    ResetPPDeffile(PPDefFile);
                    return;
                }
            }
            catch (Exception ex)
            {
                cUtils.LogEmailSend("WritePremierePreviewDir Move Temp ->"+ ex);
                return;
            }

            //PARTE 2
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(TempXml);
                XmlNode node = document.SelectSingleNode("PremiereData/Preferences/Properties");

                //Erro no nó - desfazer e resetar
                if (node == null)
                {
                    ResetPPDeffile(PPDefFile);
                    return;
                }

                //Localiza previews dir pelos ultimos projetos.
                XmlNode selectSingleNode = node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstVideoPreviewFolder");

                //Erro no nó - desfazer e resetar
                if (selectSingleNode != null && string.IsNullOrEmpty(selectSingleNode.ToString()))
                {
                    ResetPPDeffile(PPDefFile);
                    return;
                }

                string prevDir = selectSingleNode.InnerText;
               // string ppPreviewDir = PpDefaultProjectDir + PPFolderVer + pprevifoldername;

                //if (!Directory.Exists(ppPreviewDir)) return;

                //se for padrao
                if (prevDir == "MyDocuments" || prevDir == "SameAsProject")
                {
                    //encontrar projeto
                    //\\?\F:\xxxxx\Documents\Adobe\Premiere Pro\23.0\Sem título.prproj
                    string newdirprev = Path.GetDirectoryName(node.SelectSingleNode("./BE.Prefs.MRU.Document.0").InnerText.Remove(0, 4)) + @"\Adobe Premiere Pro Video Previews";

                    //F:\EncryptorX\Documents\Adobe\Premiere Pro\23.0\
                    WriteToRegistryKey.SetValue("PPPreviewDir", newdirprev); //Grava
                }
                else
                {
                    // alterado
                    WriteToRegistryKey.SetValue("PPPreviewDir", prevDir); //Grava
                }
            }
            catch (Exception e)
            {
                ResetPPDeffile(PPDefFile);
                cUtils.LogSend("WritePremierePreviewDir -> " + e);
            }
            finally
            {
                ResetPPDeffile(PPDefFile);
            }
        }

        private static void ResetPPDeffile(string definitionfile)
        {
            //Existe ambos - deletar o temp e manter o original
            if (File.Exists(TempXml) && File.Exists(definitionfile))
            {
                File.Delete(TempXml);
                return;
            }

            //existe apenas o temp
            if (File.Exists(TempXml) && !File.Exists(definitionfile))
            File.Move(TempXml, definitionfile);
        }

        #endregion
        
        #region LightRoom

        public static string GetLightRoomExePath()
        {
            //HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Adobe.AdobeLightroom
            using (RegistryKey registry = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\Adobe.AdobeLightroom", false))
            {
                string ltfilepath = "";
                if (registry != null) ltfilepath = registry.GetValue("DefaultIcon").ToString();
                return !string.IsNullOrEmpty(ltfilepath) ? ltfilepath : null;
            }
        }

        private static void WriteLightRoomDefFilePath()
        {
            string prefsfile = null;
            //if (Directory.Exists(_roamingdir + @"\Adobe\Lightroom\Preferences"))
            //Lightroom Classic CC 7 Preferences
            if (File.Exists(Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom Classic CC 8 Preferences.agprefs"))
                prefsfile = Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom Classic CC 8 Preferences.agprefs";
            if (File.Exists(Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom Classic CC 7 Preferences.agprefs"))
                prefsfile = Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom Classic CC 7 Preferences.agprefs";
            if (File.Exists(Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom 6 Preferences.agprefs"))
                prefsfile = Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom 6 Preferences.agprefs";
            if (File.Exists(Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom 5 Preferences.agprefs"))
                prefsfile = Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom 5 Preferences.agprefs";
            if (File.Exists(Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom 4 Preferences.agprefs"))
                prefsfile = Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom 4 Preferences.agprefs";
            if (File.Exists(Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom 3 Preferences.agprefs"))
                prefsfile = Roamingdir + @"\Adobe\Lightroom\Preferences\Lightroom 3 Preferences.agprefs";

            if (prefsfile != null) if (WriteToRegistryKey != null) WriteToRegistryKey.SetValue("LTDefFile", prefsfile);

            //Create a Backup 1º time
            try
            {
                string PrefFileOld = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Adobe\Lightroom\OldPrefsFile.old";
                if (!File.Exists(PrefFileOld))
                    File.Copy(prefsfile, PrefFileOld, true);
            }
            catch { }


        }

        private static void WriteLightRoomCatFilePath()
        {
            string LTFile = null;
            string LTCatPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\\Lightroom\\";
            if (File.Exists(LTCatPath + @"Lightroom 4 Catalog.lrcat"))
                LTFile = LTCatPath + @"Lightroom 4 Catalog.lrcat";
            if (File.Exists(LTCatPath + @"Lightroom 5 Catalog.lrcat"))
                LTFile = LTCatPath + @"Lightroom 5 Catalog.lrcat";
            if (File.Exists(LTCatPath + @"Lightroom 6 Catalog.lrcat"))
                LTFile = LTCatPath + @"Lightroom 6 Catalog.lrcat";

            if (File.Exists(LTCatPath + @"Lightroom Catalog.lrcat"))
                LTFile = LTCatPath + @"Lightroom Catalog.lrcat";

            if (LTFile == null) return;
            if (WriteToRegistryKey != null) WriteToRegistryKey.SetValue("LTCatFile", LTFile);
        }
        public static string GetLightroomDefFile()
        {
            return WriteToRegistryKey.GetValue("LTDefFile").ToString();
        }
        #endregion

        #region Photoshop
        public static string GetPhostoshopExePath()
        {
            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Photoshop.exe

            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Adobe Premiere Pro.exe
           /* using (RegistryKey registry = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Photoshop.exe", false))
            {
                string psfilepath = "";
                if (registry != null) psfilepath = registry.GetValue("Path").ToString() + "Photoshop.exe";
                return !string.IsNullOrEmpty(psfilepath) ? psfilepath : null;
            }*/

            return CRegistros.LoadAdobeInfoFromReg("photoshoppath") + "Photoshop.exe";//2023

        }
        /*
         *   using (RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(RegPolicies, true))
            {
                if (regKeyAppRoot != null && regKeyAppRoot.GetValue(UserDomainName) != null)
                    regKeyAppRoot.DeleteValue(UserDomainName, true);
            }
         */
        #endregion

        #region GetSizes Func

        private static long GetFileSize(string filepath)
        {
            if (!File.Exists(filepath))
                return 0;

            FileInfo fileInfo = new FileInfo(filepath);
            return fileInfo.Length / (1024 * 1024); // Size in MB
        }
        private static long GetDirSize(string sourceDir)
        {
            long sizeInBytes = DirectorySize(sourceDir, true);
            long sizeInMB = sizeInBytes / (1024 * 1024);

            if (_switch == "Preview")
                _previewSizeLabel = sizeInMB < 1024 ? " MB Usados " : " GB Usados ";
            else
                _cacheSizeLabel = sizeInMB < 1024 ? " MB Usados " : " GB Usados ";

            return sizeInMB < 1024 ? sizeInMB : sizeInMB / 1024;
        }
        private static long DirectorySize(string sourceDir, bool recurse)
        {
            if (string.IsNullOrEmpty(sourceDir) || !Directory.Exists(sourceDir))
                return 0;

            long size = 0;
            string[] fileEntries = Directory.GetFiles(sourceDir);

            foreach (string fileName in fileEntries)
            {
                Interlocked.Add(ref size, (new FileInfo(fileName)).Length);
            }

            if (recurse)
            {
                string[] subdirEntries = Directory.GetDirectories(sourceDir);

                Parallel.ForEach(subdirEntries, (subdirEntry) =>
                {
                    if ((File.GetAttributes(subdirEntry) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                    {
                        Interlocked.Add(ref size, DirectorySize(subdirEntry, true));
                    }
                });
            }

            return size;
        }

        #endregion

        #region Worker Thread

        //INICIAR ATUALIZAR INFO DA MAIN
        public static void StartWorker()
        {
            if (!Program.Editor)
                return;

            if (Worker.IsBusy)
                return;
            Worker.RunWorkerAsync();
            Worker.DoWork += WorkerOnDoWork;
            Worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            
        }

        //EXPOR O RESULTADO AQUI ------- Ajustar Valore Controlado no REgistro: 100/x
        private static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                frmEditor fMain = (frmEditor) Application.OpenForms["frmEditor"];
                if (fMain == null) return;

            if (Program.LTInstalled)
            {
                long SizeCat = GetFileSize(CRegistros.GetLtCatFile());
                fMain.tbxCatSize.Text = SizeCat.ToString()+" Mb";

                if (SizeCat > 500)
                    fMain.tbxCatStatus.Text = @"Otimizar Catálogo !";

                string FilterBackup = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LTFiltersBackup";
                
                if (Directory.Exists(FilterBackup))
                    fMain.tbxPresBak.Text = @"Criado: " + Directory.GetCreationTime(FilterBackup).ToShortDateString();
            }
            if (Program.PPInstalled)
            {
                // DirCacheSize = GetDirSize(@"C:\Program Files");
                fMain.tbxPMediaCache.Text = ""; //Resetar para atualizar
                fMain.tbxPPreviewCache.Text = ""; //Resetar para atualizar
                fMain.tbxPMediaCache.Text = _dirMediaCacheSize.ToString(CultureInfo.InvariantCulture) + _cacheSizeLabel;
                fMain.tbxPPreviewCache.Text = _dirPreviewCacheSize.ToString(CultureInfo.InvariantCulture) +
                                              _previewSizeLabel;


                fMain.barPMediaCache.Value = _dirMediaCacheSize <= 1 ? 0 : Convert.ToInt32(100/(Convert.ToDouble(_dirMediaCacheSize)));

                fMain.barPPreviewCache.Value = _dirPreviewCacheSize <= 1 ? 0 : Convert.ToInt32(100/(Convert.ToDouble(_dirPreviewCacheSize)));
            }

            fMain.Refresh();
            fMain.Validate(true);
            
        }

        public static double GetTotalHDDSize(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive.TotalSize / (1024 * 1024 * 1024);
                }
            }
            return -1;
        }
        //Alimentar as VAR AQUI
        private static void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            //Carregar Preview Size
            string ppPreviewDir = WriteToRegistryKey.GetValue("PPPreviewDir").ToString();//Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\CentraldeSuporte", "PPPreviewDir", null).ToString();
            string ppMediacacheDir = GetMediaCacheDir();
            if (!string.IsNullOrEmpty(ppPreviewDir))
            {
                if (!Directory.Exists(ppPreviewDir) && !string.IsNullOrEmpty(ppPreviewDir))
                    Directory.CreateDirectory(ppPreviewDir);
                _switch = "Preview"; //<- Ativa a leitura do label correto
                _dirPreviewCacheSize = GetDirSize(ppPreviewDir);
            }

            //Carregar MediaCache Size -criar pasta caso tenha sido deletada.
            if (!Directory.Exists(ppMediacacheDir) && !string.IsNullOrEmpty(ppMediacacheDir))
                Directory.CreateDirectory(ppMediacacheDir);

            _switch = "Cache";
            _dirMediaCacheSize = GetDirSize(ppMediacacheDir);
            //worker.CancelAsync();
        }

        #endregion

        #region GET FUNCTIONS

        public static Tuple<string, string, string> GetPremiereVersion()
        {
            string ProductVersion = null;
            string PremiereName = null;
            string CSVerinfo = null;
            string premiereexepath = GetPremiereProExePath();
            if (File.Exists(premiereexepath))
            {
                ProductVersion = FileVersionInfo.GetVersionInfo(premiereexepath)
                                   .ProductVersion;
                PremiereName = "Adobe Premiere Pro CC";
                CSVerinfo = "Adobe Creative Cloud";
            }
            
            return new Tuple<string, string, string>(PremiereName, ProductVersion, CSVerinfo);
        }
        public static string GetPremiereProExePath()
        {
            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Adobe Premiere Pro.exe
            using (RegistryKey registry = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Adobe Premiere Pro.exe", false))
            {
                string ppfilepath = "";
                if (registry != null) ppfilepath = registry.GetValue("Path").ToString() + "Adobe Premiere Pro.exe";
                return !string.IsNullOrEmpty(ppfilepath) ? ppfilepath : null;
            }
        }
        public static string GetPremiereDefFile()
        {
            return WriteToRegistryKey.GetValue("PPDefFile").ToString();
        }
        public static string GetMediaCacheDir()
        {

            if (WriteToRegistryKey.GetValue("UseStaticCache") != null)
            {
               // if (WriteToRegistryKey.GetValue("UseStaticCache").ToString() == "True") ;//SE 1 Auto setar os caches

                if (WriteToRegistryKey.GetValue("PPMediaCacheDir") != null && WriteToRegistryKey.GetValue("PPMediaCacheDir").ToString() != "")
                return WriteToRegistryKey.GetValue("PPMediaCacheDir").ToString();
            }

            return CRegistros.LoadAdobeInfoFromReg("mediacache");
    
        }
        #endregion

        #region Clean Functions

        public static void CleanPremiereCaches()
        {
            //Verifica se o premiere nao esta aberto
            string pTitle = cUtils.GetDesktopWindowsTitles("Adobe Premiere Pro");
            //MessageBox.Show(pTitle);
            if (pTitle != null && pTitle == "Adobe Premiere Pro")
            {
                MessageBox.Show(@"Feche o premiere antes de executar a tarefa.");
                return;
            }

            DialogResult LimparCaches = MessageBox.Show("Excluir todo o Cache agora ?", "LIMPEZA DE CACHES",
                                                        MessageBoxButtons.OKCancel);
            if (LimparCaches == DialogResult.Cancel)
                return;

            MessageBox.Show(@"Aguarde um momento...");
            string delcache1 = GetMediaCacheDir();//Cache Files
            string delcache2 = GetMediaCacheDir().Replace("Media Cache Files", "Media Cache");//Cache Database

            if (Directory.Exists(delcache1))
            Directory.Delete(delcache1, true);
            if (Directory.Exists(delcache2))
            Directory.Delete(delcache2, true);

            StartWorker();
            MessageBox.Show("Os Caches foram apagados!");
          }

        public static void CleanPreviewFolder()//Inicia Limpeza PREVIEW
        {
            //C:\Users\EncryptorX\AppData\Roaming\Adobe\Premiere Pro\6.0\Adobe Premiere Pro Prefs
            string PPDefFile = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\CentraldeSuporte", "PPDefFile", null).ToString();
            string PPPreviewDir = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\CentraldeSuporte", "PPPreviewDir", null).ToString();

            DialogResult LimparPreview = MessageBox.Show("Excluir todos os Previews agora ?", "LIMPEZA DO PREVIEW",
                                            MessageBoxButtons.OKCancel);
            if (LimparPreview == DialogResult.Cancel)
                return;

            string delDir = string.Empty;
            string Tempdir1 = null;
            string Tempdir2 = null;
            string Tempdir3 = null;
            string Tempdir4 = null;
            string Tempdir5 = null;
            string Tempdir0 = null;

            if (!File.Exists(PPDefFile))//no PP installed
                return;

            //FIX 3017
            //RepairFileXMLIfExist
            if (File.Exists(TempXml) && File.Exists(PPDefFile))
            {
                File.Delete(PPDefFile);
                File.Move(TempXml, PPDefFile);
            }
            //Criar um Arquivo Temporário
            if (File.Exists(PPDefFile))
                File.Move(PPDefFile, TempXml);

            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(TempXml);
            }
            catch (Exception error)
            {
                cUtils.LogSend(error.ToString());
                return;
            }

            XmlNode node = document.SelectSingleNode("PremiereData/Preferences/Properties");
            //Localiza previews dir pelos ultimos projetos.
            if (node != null)
            {
                delDir = node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstVideoPreviewFolder").InnerText;
                //\\?\G:\My Documents\Adobe\Premiere Pro\6.0\Proj1.prproj
                if (node.SelectSingleNode("./BE.Prefs.MRU.Document.0") != null)
                    Tempdir0 =
                        Path.GetDirectoryName(node.SelectSingleNode("./BE.Prefs.MRU.Document.0")
                                                  .InnerText.Remove(0, 4));
                if (node.SelectSingleNode("./BE.Prefs.MRU.Document.1") != null)
                    Tempdir1 =
                        Path.GetDirectoryName(node.SelectSingleNode("./BE.Prefs.MRU.Document.1")
                                                  .InnerText.Remove(0, 4));
                if (node.SelectSingleNode("./BE.Prefs.MRU.Document.2") != null)
                    Tempdir2 =
                        Path.GetDirectoryName(node.SelectSingleNode("./BE.Prefs.MRU.Document.2")
                                                  .InnerText.Remove(0, 4));
                if (node.SelectSingleNode("./BE.Prefs.MRU.Document.3") != null)
                    Tempdir3 =
                        Path.GetDirectoryName(node.SelectSingleNode("./BE.Prefs.MRU.Document.3")
                                                  .InnerText.Remove(0, 4));
                if (node.SelectSingleNode("./BE.Prefs.MRU.Document.4") != null)
                    Tempdir4 =
                        Path.GetDirectoryName(node.SelectSingleNode("./BE.Prefs.MRU.Document.4")
                                                  .InnerText.Remove(0, 4));
                if (node.SelectSingleNode("./BE.Prefs.MRU.Document.5") != null)
                    Tempdir5 =
                        Path.GetDirectoryName(node.SelectSingleNode("./BE.Prefs.MRU.Document.5")
                                                  .InnerText.Remove(0, 4));
            }
            //Restaura Definiçoes
            if (File.Exists(TempXml))
                File.Move(TempXml, PPDefFile);


            if (delDir == "MyDocuments" || delDir == "SameAsProject")//Diretorio Padrao do PP
            {

                if (!Directory.Exists(PPPreviewDir)) return;
                if (Directory.Exists(PPPreviewDir))
                    Directory.Delete(PPPreviewDir, true);

                StartWorker();
                return;
            }

            string pprevifoldername = @"\Adobe Premiere Pro Video Previews";
            //Iniciar Deletar
            if (Directory.Exists(delDir + pprevifoldername))
                Directory.Delete(delDir + pprevifoldername, true);
            //Temp Possible Preview Dir from RecentProj
            if (Directory.Exists(Tempdir0 + pprevifoldername))
                Directory.Delete(Tempdir0 + pprevifoldername, true);
            if (Directory.Exists(Tempdir1 + pprevifoldername))
                Directory.Delete(Tempdir1 + pprevifoldername, true);
            if (Directory.Exists(Tempdir2 + pprevifoldername))
                Directory.Delete(Tempdir2 + pprevifoldername, true);
            if (Directory.Exists(Tempdir3 + pprevifoldername))
                Directory.Delete(Tempdir3 + pprevifoldername, true);
            if (Directory.Exists(Tempdir4 + pprevifoldername))
                Directory.Delete(Tempdir4 + pprevifoldername, true);
            if (Directory.Exists(Tempdir5 + pprevifoldername))
                Directory.Delete(Tempdir5 + pprevifoldername, true);
           
            StartWorker();
        }
        #endregion

        #region Interface

        public static void SetInterfaceMode(int value)
        {
            //0 = full  1= compacta
            if (WriteToRegistryKey.GetValue("Interface") == null)
            {
                WriteToRegistryKey.SetValue("Interface",0,RegistryValueKind.DWord);
            }
            WriteToRegistryKey.SetValue("Interface", value, RegistryValueKind.DWord);
        }

        public static int GetInterfaceMode()
        {
            if (WriteToRegistryKey == null)
                return 0;

            if (WriteToRegistryKey != null && WriteToRegistryKey.GetValue("Interface") == null)
                return 0;
            return WriteToRegistryKey.GetValue("Interface").ToString() == "1" ? 1 : 0;
        }
        #endregion
    }
}
