using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace suporteupdater
{
    internal class Program
    {
        //2023
        private const string DownloadUrl = "xxx";
        private const string DownloadVerUrl = "xxxx";
       
        private const string UpdatedExe = @"C:\ProgramData\SuporteUpdater\Suporte.exe";
        private const string FileVersion = @"C:\ProgramData\SuporteUpdater\versionupdate.txt";
        private const string InstallDir = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Maintenance";
        private const string ApplicationExe = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Maintenance\Suporte.exe";
        private static bool _doUpdate;
        private static bool _doRestart;
       // private static readonly string TaskUsername = "Suporte_" + GetCurrentUserName().Replace(" ", "");///nome do arquivo
        static readonly WebClient WebDownup = new WebClient();

        private static void Main()
        {
            //Verificar a existencia do Dir Manutençao - 2023 fix error win11
            if (!Directory.Exists(InstallDir))
                Directory.CreateDirectory(InstallDir);

            //Verifica se o arquivo principal existe no diretorio correto
            if (!File.Exists(ApplicationExe))
            {
                if(File.Exists(UpdatedExe))
                File.Copy(UpdatedExe, ApplicationExe, true);
                else
                {
                    DownloadtheNewFile();//Iniciar Download
                    LogError(@"Erro ao copiar do arquivo de update:");
                }
            }

            //Verifica se o updater apenas ira restartar o aplicativo
            DoRestart();

            if (_doRestart)
            {
                Thread.Sleep(1000);//Aguarda 1Segundo para finalizar o aplicativo principal.
                StartNewApp();
                return;//Finalizado o updater.
            }

            if (!ConnectionAvailable("http://www.google.com.br"))
                return;
            
            //Verifica se o aplicativo ja esta na pasta maintenance
            if (!File.Exists(ApplicationExe))
            CheckApplicationExistence();
            
            //Updates
            DownloadVerFile();

            CheckNewVersion();


            if (_doUpdate)
            {
                StartUpdate(); //Iniciar Copia....
            }
          //  else
          //  {
           //     Quit();
          //  }

            StartNewApp(); //Inicia o aplicativo atualizado.
        }

        private static string GetCurrentUserName()
        {
            return Environment.UserName;
        }

        private static void StartWithArgs(string processStart, string args)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo {FileName = processStart, Arguments = args};
                Process.Start(startInfo);
            }
            catch (Exception)
            {

            }
        }
        #region IsOnline?

        private static bool ConnectionAvailable(string strServer)
        {
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)WebRequest.Create(strServer);
                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();

                if (HttpStatusCode.OK == rspFP.StatusCode)
                {
                    // HTTP = 200 - Internet connection available, server online
                    rspFP.Close();
                    return true;
                }
                // Other status - Server or connection not available
                rspFP.Close();
                return false;
            }
            catch (WebException)
            {
                // Exception - connection not available
                // MessageBox.Show("Check your connection !");
                return false;
            }
        }

        #endregion
        private static void CheckApplicationExistence()
        {
            DownloadtheNewFile();
            File.Copy(UpdatedExe, ApplicationExe, true); 
            StartNewApp();
            Quit();
        }
        private static void StartNewApp()
        {
            try
            {
                //var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(ApplicationExe) {Verb = "runas"};
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
        }

        #region Update Check
        private static void StartUpdate()
        {
            //Verificar a existencia do Dir Manutençao
            if (!Directory.Exists(InstallDir))
                Directory.CreateDirectory(InstallDir);
           
            try
            {
                if (File.Exists(ApplicationExe)) 
                File.Delete(ApplicationExe);

                File.Copy(UpdatedExe, ApplicationExe,true);
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
                //ShowError(ex.ToString());
            }
        }
        
        private static void DownloadVerFile() //XML VERSION CHECK
        {
            try
            {
                //Verificar Local do Updater
                try
                {
                    if (File.Exists(FileVersion))
                        File.Delete(FileVersion);
                }
                catch (Exception ex)
                {
                    LogError(ex.ToString());
                }


                WebDownup.DownloadFile(new Uri(DownloadVerUrl), FileVersion);
            }
            catch (WebException ex)
            {
                LogError(ex.ToString());
            }
        }

        //Carrega Informaçoes do XML
        private static int GetVersionfromFile()
        {
            StreamReader fReader = new StreamReader(FileVersion);
            var version = Convert.ToInt16(fReader.ReadLine());
            fReader.Close();//finaliza stream
            return version;

        }
        private static void CheckNewVersion()
        {
            //Verifica defeito no arquivo de update.
            try
            {
                if (!File.Exists(FileVersion))
                    return;

                //Verifica se o arquivo nao esta corrompido
                FileInfo fileInfo = new FileInfo(FileVersion);
                if (fileInfo.Length <= 1) return;
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }


            //Tudo OK Prosseguir...
            try
            {
                var productVersionfromFile = GetVersionfromFile();//== x000
                var currentProductVersion = Convert.ToInt16(FileVersionInfo.GetVersionInfo(ApplicationExe).FileVersion.Replace(".",""));//== x000
                //Se versao do aplicativo desta maquina for menor que a ver do arquivo online - retorna.
                if (!(currentProductVersion < productVersionfromFile)) return;
                _doUpdate = true;
                GetDesktopWindowsTitlesandClose("Suporte");//Mata o processo para iniciar atualizaçao
                DownloadtheNewFile();//Iniciar Download
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
             // ShowError(ex.ToString());
            }
        }

        private static void GetDesktopWindowsTitlesandClose(string processtokill)
        {
            Process[] processlist = Process.GetProcessesByName(processtokill);
            foreach (Process p in processlist)
            {
                //IntPtr pwindow = p.MainWindowHandle;
                if (p.MainModule.FileName.Contains(processtokill))
                {
                    p.Kill();
                }
                else
                break;
            }
        }
        private static void DownloadtheNewFile()
        {
            try
            {
                try
                {
                    if (File.Exists(UpdatedExe))//Remove updates antigos antes de fazer o novo download
                        File.Delete(UpdatedExe);
                }
                catch (Exception ex)
                {
                    LogError(ex.ToString());
                }

                WebClient webDownup = new WebClient();
                webDownup.DownloadFile(new Uri(DownloadUrl),UpdatedExe);//Salvar na pasta de Update
            }
            catch (WebException ex)
            {
                LogError(ex.ToString());
               // ShowError(ex.ToString());
            }
        }
        #endregion

        private static void Quit()
        {
            Environment.Exit(0);
        }

        private static void LogError(string error)
        {
            string FileLog = @"C:\ProgramData\SuporteUpdater\UpdaterLog.log";
           // Console.WriteLine(error.ToString());
            if (!File.Exists(FileLog))
            {
                File.CreateText(FileLog);
            }
            using (StreamWriter sw = File.AppendText(FileLog))
            {
                sw.WriteLine(error);
            }
        }
        //DO RESTART FROM MAIN APP
        private static void DoRestart()
        {
            const string dorestart = @"C:\ProgramData\SuporteUpdater\DoRestart.tmp";
            // Console.WriteLine(error.ToString());
            if (File.Exists(dorestart))
            {
                _doRestart = true;
                File.Delete(dorestart);
            }
        }
    }
}
