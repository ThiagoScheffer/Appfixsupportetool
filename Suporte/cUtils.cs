using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Suporte.Properties;
using Color = System.Drawing.Color;


namespace Suporte
{
    public class cUtils
    {
        #region DLLimport

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className,
                                                 IntPtr windowTitle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, uint wParam, StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        private const int WM_GETTEXT = 0x000D;
        private const int WM_GETTEXTLENGTH = 0x000E;
        private const int SW_SHOWMINIMIZED = 2;


        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);

         #endregion
        private const string ServerTest = "http://www.google.com.br";
        private static readonly ManagementObjectSearcher OSname = new ManagementObjectSearcher("select * from win32_operatingsystem");

       // private static readonly ManagementObjectSearcher ProcSearcher = new ManagementObjectSearcher("select * from Win32_Process");
        private static readonly ManagementObjectSearcher Systeminfo =
        new ManagementObjectSearcher("select * from Win32_OperatingSystem");
        public static readonly string UserDomainName = Environment.UserDomainName + @"\" + Environment.UserName;
        static readonly frmUsuario fMainUsuario = (frmUsuario)Application.OpenForms["frmUsuario"];
        static readonly frmEditor fMainEditor = (frmEditor)Application.OpenForms["frmEditor"];

        #region Segurança

        public static void LogSend(string error)
        {
            LogEmailSend("AutoLog Error:" + "\n" + error);
        }

        public static void SiteBlockWrite(string sitetoblock)
        {
            using (
                StreamWriter w =
                    File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System),
                                                 "drivers/etc/hosts")))
            {
                w.WriteLine("127.0.0.1 " + sitetoblock);
            }
        }

        #endregion

        #region IsOnline?

        public static bool ConnectionAvailable()
        {
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)WebRequest.Create("http://www.google.com.br");
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

        #region EMAIL

        protected internal static void LogEmailSend(string texto)
        {
            // string pcname = Environment.MachineName.ToString(CultureInfo.InvariantCulture);
            //// string usuario = Environment.UserName.ToString(CultureInfo.InvariantCulture);
            // //string pcclient = cRegistros.GetCliente();


            // string installdate = (from ManagementObject searcher in Systeminfo.Get() select searcher["InstallDate"].ToString()).FirstOrDefault();
            // //Fix Double icon.
            // Assembly assembly = Assembly.GetExecutingAssembly();
            // FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            // string version = fvi.ProductVersion;

            
            string informacoes = " Cliente: " + CRegistros.GetCliente() + "  Usuario: " + CRegistros.GetComputerName() + "\n\n" + texto + "\n\r" + GetProductVersion(null);

            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(informacoes, EventLogEntryType.Information, 101, 1);
            }

        }
        protected internal static void EnviarEmail(string texto)
        {
           //off
           
        }

        //2023 - fail to be secure remove!
        public static async void SendEmailAsync(string texto)
        {
            using (var mailMessage = new MailMessage())
            {
                string informacoes = " Cliente: " + CRegistros.GetCliente() + "  PC: " + CRegistros.GetComputerName();

                string emailuser = "xxxxxxxx@xxxxxxxxxx.com";
                mailMessage.From = new MailAddress(emailuser);
                mailMessage.To.Add(emailuser);
                mailMessage.Subject = informacoes;
                mailMessage.Body = texto;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Host = "smtp.office365.com";
                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(emailuser, EDCode("zzxxzxxzxzxzxzxz==", false));
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
        }
        
        public static string EDCode(string Text, bool Encode)
        {
            
            return (Encode)//SE for True Converte , outro Decodifica
                       ? Convert.ToBase64String(Encoding.ASCII.GetBytes(Text))
                       : Encoding.ASCII.GetString(Convert.FromBase64String(Text));
        }
        #endregion

        #region FORMS
        //delegate void SendMsgDelegate(string tbxavisos,string tbxInfo,Color backcolor);
        public static void SendMsg(string tbxavisos,string tbxInfo,Color backcolor)
         {
            if (fMainEditor != null)
            {
                if (fMainEditor.tbxInfo.InvokeRequired)
                {
                    fMainEditor.tbxInfo.BeginInvoke((MethodInvoker) delegate
                    {
                        if (tbxInfo != null)
                            fMainEditor.tbxInfo.Text = tbxInfo;

                        if (tbxavisos != null)
                        {
                            fMainEditor.tbxAvisos.Text = tbxavisos;
                            if (backcolor != Color.Empty)
                                fMainEditor.tbxAvisos.BackColor = backcolor;
                        }
                    });
                }
                else
                {
                    if (tbxInfo != null)
                        fMainEditor.tbxInfo.Text = tbxInfo;

                    if (tbxavisos != null)
                    {
                        fMainEditor.tbxAvisos.Text = tbxavisos;
                        if (backcolor != Color.Empty)
                            fMainEditor.tbxAvisos.BackColor = backcolor;
                    }
                }
            }
            
            if (fMainUsuario != null)
             {
                 if (fMainUsuario.tbxInfo.InvokeRequired)
                 {
                     fMainUsuario.tbxInfo.BeginInvoke((MethodInvoker) delegate
                     {
                         if (tbxInfo != null)
                             fMainUsuario.tbxInfo.Text = tbxInfo;

                         if (tbxavisos != null)
                         {
                             fMainUsuario.tbxAvisos.Text = tbxavisos;
                             if (backcolor != Color.Empty)
                                 fMainUsuario.tbxAvisos.BackColor = backcolor;
                         }
                     });
                 }
                 else
                 {
                    if (tbxInfo != null)
                        fMainUsuario.tbxInfo.Text = tbxInfo;

                    if (tbxavisos != null)
                    {
                        fMainUsuario.tbxAvisos.Text = tbxavisos;
                        if (backcolor != Color.Empty)
                            fMainUsuario.tbxAvisos.BackColor = backcolor;
                    }
                }
             }

         }

        #endregion

        internal static void LoadExcelDB(string url, string filename)
        {
            // Create a connection string to the Excel file.
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=finance.xlsx;Extended Properties=\Excel 12.0 Xml; HDR = YES;\";

            // Open the connection to the Excel file.
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            // Create a DataSet to store the data from the Excel file.
            DataSet dataSet = new DataSet();

            // Create a DataAdapter to read the data from the Excel file.
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1]", connection);

            // Fill the DataSet with the data from the Excel file.
            dataAdapter.Fill(dataSet);

            // Close the connection to the Excel file.
            connection.Close();

            // Display the data from the DataSet.
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine("Tipo de Lancamento: {0}, Data Pagamento: {1}, Descricao: {2}, Valor: {3}, Categoria: {4}, Recebido de: {5}, Pago: {6}",
                    row["Tipo de Lancamento"], row["Data Pagamento"], row["Descricao"], row["Valor"], row["Categoria"], row["Recebido de"], row["Pago"]);
            }

            // Close the DataSet.
            dataSet.Dispose();
        }

        public static void DownloadFile(string url, string filename)
        {
            if (!ConnectionAvailable()) return;

            if (File.Exists(Program.UpdateDir + "\\" + filename))//se o arquivo ja esta ali, ignorar
                return;
            try
            {
                WebClient webDownup = new WebClient();
                webDownup.DownloadFileAsync(new Uri(url), Program.UpdateDir + "\\" + filename);
            }
            catch (WebException exception)
            {
                LogEmailSend("Utils DownloadFile:" + exception);
            }

        }

        public static void DownloadFileQueued(string url,string filename)
        {
            try
            {
                if (!ConnectionAvailable()) return;

                if (File.Exists(Program.UpdateDir + "\\" + filename))//se o arquivo ja esta ali, ignorar
                    return;
                

                using (WebClient webClient = new WebClient())
                {
                    string savetodir = Program.UpdateDir + "\\" + filename;
                   // webClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    webClient.DownloadFile(new Uri(url), @savetodir);

                    //Add them to the local
                   // Context.listOfLocalDirectories.Add(downloadToDirectory);
                }
            }
            catch (Exception exception)
            {
                LogEmailSend("Utils DownloadFileAsyn:" + exception);
            }
        }       

        public static void UpdaterRebuild()
        {
            const string updaterExe = @"C:\ProgramData\SuporteUpdater\suporteupdater.exe";
            if (File.Exists(Program.UpdateDir + "\\suporteupdater.exe"))
            {
                File.Delete(Program.UpdateDir + "\\suporteupdater.exe");
                File.WriteAllBytes(updaterExe, Resources.suporteupdater);
            }
            else
            {
                File.WriteAllBytes(updaterExe, Resources.suporteupdater);
            }
        }

        public static string GetInstallDate()
        {
            string data = null;
            foreach (ManagementObject os in OSname.Get())
            {
                data = ManagementDateTimeConverter.ToDateTime(os["InstallDate"].ToString()).ToString();
            }
            return data;
        }

        public static string GetProductVersion(string filepath)
        {
            if (String.IsNullOrEmpty(filepath))
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fvi.ProductVersion;
            }
            else
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(filepath);
                return fvi.ProductVersion;
            }
           
        }

        public static int GetfileversionInt(string filepath)
        {
            if (!File.Exists(filepath)) return 0;
            FileVersionInfo fviInfo = FileVersionInfo.GetVersionInfo(filepath);
            return Convert.ToInt16(fviInfo.FileVersion.Replace(".",""));//1.1.1.1 = 1111
        }
        public static string GetFileVersion(string filepath)
        {
            if (!File.Exists(filepath)) return null;
            FileVersionInfo fviInfo = FileVersionInfo.GetVersionInfo(filepath);
            return fviInfo.FileVersion;
        }
        public static string ExtractStringwithQuotationMark(string textline, string firstString, string lastString)
        {
            string input = textline;
            string pattern = "(?<=\\" + firstString + ")(.*?)(?=\\" + lastString + ")";
            Match output = Regex.Match(input, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return output.ToString();
        }
        //Uso para Definition files
        public static string DefFileExtractString(string textline, string FirstString, string LastString)
        {
            string input = textline;
            string pattern = @"(?<=\\" + FirstString + ")(.*?)(?=\\" + LastString + ")";
            Match output = Regex.Match(input, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return output.ToString();
        }

        public static void ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            StreamReader reader = new StreamReader(filePath);
            string texto = reader.ReadToEnd();
            reader.Close();

            texto = Regex.Replace(texto, searchText, replaceText);

            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(texto);
            writer.Close();
        }

        public static void ReplaceLineString(string filepath, string search, string toreplace)
        {
            StringBuilder nStringBuilder = new StringBuilder();
            string[] file = File.ReadAllLines(filepath);
            foreach (var line in file)
            {
                if (line.Contains(search))
                {
                    string temp = line.Replace(search, toreplace);
                    nStringBuilder.Append(temp + "\r\n");
                    continue;
                }
                nStringBuilder.Append(line + "\r\n");
            }
            File.WriteAllText(filepath, nStringBuilder.ToString());
        }

        public static string GetDescripClientName()
        {
            foreach (ManagementObject searcher in Systeminfo.Get())
            {
                return searcher["Description"].ToString();
            }
            return null;
        }

        public static string GetCurrentUserName()
        {
            return Environment.UserName;
        }
        public static string GetDesktopWindowsTitles(string processname)
        {
            Process[] processlist = Process.GetProcessesByName(processname);
            bool any = false;
            foreach (Process p in processlist)
            {
                if (p.MainModule.FileName.Contains(processname))
                {
                    any = true;
                    break;
                }
            }
            return any ? processname : "";
        }

        public static void GetDesktopWindowsTitlesandClose(string processtokill)
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
                    MessageBox.Show(@"Processo não encontrado!");
                break;
            }
        }

        public static void TeamViewerMinimize()
        {
            string _pTitle = GetDesktopWindowsTitles("TeamViewer");

            // retrieve Notepad main window handle
            IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, _pTitle);
            if (!hWnd.Equals(IntPtr.Zero))
            {
                // SW_SHOWMAXIMIZED to maximize the window
                // SW_SHOWMINIMIZED to minimize the window
                // SW_SHOWNORMAL to make the window be normal size
                ShowWindowAsync(hWnd, SW_SHOWMINIMIZED);
            }

        }

        static bool EnumAllChilds(IntPtr hWnd, IntPtr lParam)
        {
            StringBuilder sb = new StringBuilder(2048);

            SendMessage(hWnd, WM_GETTEXT, new IntPtr(sb.Capacity), sb);

            if (!string.IsNullOrEmpty($"{sb}"))
            {
                Console.WriteLine($"\t{hWnd:X}\t{sb}");
            }

            EnumChildWindows(hWnd, EnumAllChilds, lParam);
            return true;
        }

        static bool EnumTopLevel(IntPtr hWnd, IntPtr lParam)
        {
            StringBuilder sb = new StringBuilder(2048);

            SendMessage(hWnd, WM_GETTEXT, new IntPtr(sb.Capacity), sb);
            Console.WriteLine($"TopLevel: hWnd: {hWnd:X}\t{(string.IsNullOrEmpty($"{sb}") ? "No Caption" : $"{sb}")}");

            // Call for child windows
            EnumChildWindows(hWnd, EnumAllChilds, lParam);

            return true;
        }

      
        public static void GetLoginandId()
        {
            /* IntPtr hWndTeamViewer = FindWindowByCaption(IntPtr.Zero, "DWAgent");

             IntPtr hWndID = FindWindowEx(hWndTeamViewer, IntPtr.Zero, "utilizador", IntPtr.Zero);
             IntPtr hWndPass = FindWindowEx(hWndTeamViewer, hWndID, "senha", IntPtr.Zero);

             IntPtr pLengthID = SendMessage(hWndID, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
             IntPtr pLengthPass = SendMessage(hWndPass, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);

             StringBuilder strbID = new StringBuilder((int)pLengthID);
             StringBuilder strbPass = new StringBuilder((int)pLengthPass);

             SendMessage(hWndID, WM_GETTEXT, (uint)pLengthID + 1, strbID);
             SendMessage(hWndPass, WM_GETTEXT, (uint)pLengthPass + 1, strbPass);
             if (strbID.ToString().Contains("-"))
                 return null;
             if (String.IsNullOrEmpty(strbID.ToString()))
                 return null;
             return strbID.ToString() + "\n" + strbPass.ToString(); //Forçado String por gerar um erro desconhecido
             */


            EnumWindows(EnumTopLevel, IntPtr.Zero);
            Console.ReadLine();
        }

        public static bool CopyFolderRecursive(string Source, string Destination)
        {
            Source = Source.EndsWith(@"\") ? Source : Source + @"\";
            Destination = Destination.EndsWith(@"\") ? Destination : Destination + @"\";

            try
            {
                if (!Directory.Exists(Source)) return true;

                if (Directory.Exists(Destination) == false)
                {
                    Directory.CreateDirectory(Destination);
                }

                foreach (FileInfo fileInfo in Directory.GetFiles(Source).Select(files => new FileInfo(files)))
                {
                    fileInfo.CopyTo(String.Format(@"{0}\{1}", Destination, fileInfo.Name), true);
                }

                return !(from dirs in Directory.GetDirectories(Source) let directoryInfo = new DirectoryInfo(dirs) where CopyFolderRecursive(dirs, Destination + directoryInfo.Name) == false select dirs).Any();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetUpdaterVersion()
        {
            const string updaterExe = @"C:\ProgramData\SuporteUpdater\suporteupdater.exe";
            if (File.Exists(updaterExe))
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(updaterExe);
                return fvi.ProductVersion;
            }
            return "None";
        }

        public static string GetwindowsVer()
        {
            OperatingSystem os = Environment.OSVersion;
            Version version = os.Version;
            return version.Build.ToString();
        }

        public static void StartAsAdmin(string filepath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(filepath);
            startInfo.Verb = "runas";
            Process.Start(startInfo);
        }
        public static void StartWithArgs(string processStart, string args)
        {
            if(!File.Exists(processStart)) return;
            
            ProcessStartInfo startInfo = new ProcessStartInfo { FileName = processStart, Arguments = args };
            startInfo.Verb = "runas";
            var process = Process.Start(startInfo);
            if (process == null || startInfo.FileName != "CCleaner.exe") return;
            frmUsuario fMain = (frmUsuario)Application.OpenForms["frmUsuario"];
            if (fMain != null)
            {
                fMain.tbxAvisos.Text = @"Limpeza iniciada...Aguarde!";
                process.WaitForExit();
                fMain.tbxAvisos.Text = @"Limpeza concluída! Atualizando...";
                cHDCheck.GetTempGarbage();//Atualiza os valores
                fMain.tbxAvisos.Text = @"Limpeza concluída!";
            }
        }

        public static void DoExit()
        {
            //Application.ExitThread();
            Program.Quit = true;
            Environment.Exit(0);
        }

        public static void DoRestart()
        {
            Program.Quit = true;
            Application.ExitThread();
            CreateRestartFile();//Cria um arquivo tmp somente para o updater saber que deve restartar o aplicativo.
            StartAsAdmin(Program.UpdateDir + "\\suporteupdater.exe");//3093 as admin força o sistema a executar sempre corretamente apos o restart
            Environment.Exit(0);
        }

        private static void CreateRestartFile()
        {
            const string dorestart = @"C:\ProgramData\SuporteUpdater\DoRestart.tmp";
            // Console.WriteLine(error.ToString());
            if (!File.Exists(dorestart))
            {
                File.CreateText(dorestart);
            }
        }

        public static void StartCmd(string cmdarg)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd.exe ","/c " + cmdarg);
            var process = Process.Start(procStartInfo);
           // Debug.Assert(process != null, "process != null");
            process.WaitForExit();
        }
        public static bool IsFormOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().Any(form => form.GetType().Name == form.Name);
        }


        public static DateTime DCombine(DateTime date, DateTime time)
        {
            return date.Date + time.TimeOfDay;
        }

        public static string GetVersionUpdate(string filepath)
        {
            //if(!filepath.Contains("txt"))return 
            StreamReader fReader = new StreamReader(filepath);
            MessageBox.Show(fReader.ReadLine());
            fReader.Close();
            return null;
        }

        /*
        c:
        cd \
        cd c:\windows\system32\spool\PRINTERS
        net stop spooler
        del /f /s *.spl
        del /f /s *.shd
        cd c:\windows\system32\spool\SERVERS
        del /f /s *.spl
        del /f /s *.shd
        net start spooler
        echo Concluido.
        */

        public static void CleanPrinter()
        {
            StartCmd("net stop spooler");//para o spooler antes de prosseguir 

            string folder1 = @"c:\windows\system32\spool\PRINTERS";
            string folder2 = @"c:\windows\system32\spool\SERVERS";

            //give permissions first!!
            CRegistros.GrantAccess(folder1);
            CRegistros.GrantAccess(folder2);

            try
            {
                foreach (var file in DirRecursiveSearch(folder1))
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(file);

                       // FileAttributes attributes = File.GetAttributes(file);

                        if (fileInfo.Extension == ".spl" || fileInfo.Extension == ".shd")
                        {
                            fileInfo.Delete();
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }

                foreach (var file in DirRecursiveSearch(folder2))
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(file);

                        // FileAttributes attributes = File.GetAttributes(file);

                        if (fileInfo.Extension == ".spl" || fileInfo.Extension == ".shd")
                        {
                            fileInfo.Delete();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

                StartCmd("net start spooler");
                MessageBox.Show(@"Spooler limpo.");
            }
            catch (Exception)
            {
                StartCmd("net start spooler");
            }
        }

        //Folders recursive search function.
        static List<string> DirRecursiveSearch(string sDir)
        {
            List<string> files = new List<string>();

            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirRecursiveSearch(d));
                }
            }
            catch (Exception)
            {
               // Console.WriteLine(excpt.Message);
            }
            return files;
        }
    }
}