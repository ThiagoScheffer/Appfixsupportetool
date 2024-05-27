using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Suporte
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //GLOBAL VARS
       // public static bool Debug = true;
        public static bool Debug = true;

        public const string UpdateDir = @"C:\ProgramData\SuporteUpdater";
        public const string InstallDir = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Maintenance";
        public const string ApplicationExe = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Maintenance\Suporte.exe";
        public static bool Quit = false;
        public static bool PagButtonPressed;
        public static readonly bool PPInstalled = Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\Adobe\\Premiere Pro");
        public static readonly bool LTInstalled = Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\Adobe\\Lightroom\\Filter Presets");
        public static readonly bool PPandLT = PPInstalled && LTInstalled;
        //public static readonly bool IsPremiereCC = Directory.Exists(@"C:\Program Files\Adobe\Adobe Premiere Pro CC");
        //public static readonly bool Online = cUtils.ConnectionAvailable();
        public static readonly bool Editor = LTInstalled || PPInstalled;

        [STAThread]
        static void Main()
        {
            string currentApp = Process.GetCurrentProcess().ProcessName;
            Process[] runningProcesses = Process.GetProcessesByName(currentApp);
            var currentSessionID = Process.GetCurrentProcess().SessionId;
            Process[] sameAsthisSession = (from c in runningProcesses where c.SessionId == currentSessionID select c).ToArray();

            //Se há um processo ja em execução e este nao pertence ao usuario atual , entao executar o novo processo.
            //GetProcessOwner - compara o processo Suporte e verifica a qual usuario ele pertence
            //se o processo tentar abrir uma nova instacia dentro do mesmo usuario - sair do aplicativo.
           // MessageBox.Show(cUtils.GetProcessOwner("Suporte").ToString());
            if (sameAsthisSession.Length > 1){Application.Exit();}
            else
            {
                //Apply suport for colors
                Application.EnableVisualStyles();
                //Force GDI for better visual
                Application.SetCompatibleTextRenderingDefault(false);
                if (Debug)
                {
                    Application.Run(new frmUsuario());
                   //Application.Run(new frmEditor());
                }
                else
                {
                    if (Editor)
                        Application.Run(new frmEditor());
                    else
                        Application.Run(new frmUsuario());
                }
            }
        }
    }
}
