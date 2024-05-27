using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suporte
{
    static class cHDCheck
    {
        public static void GetTempGarbage()
        {
            string TempDir = Path.GetTempPath();
            long Tempsize = 0;
            long TempConverted = 0;
            //C:\Users\Sensei\AppData\Local\Microsoft\Windows\INetCache\IE
            string OperaCache = @"C:\Users\" + Environment.UserName+@"\AppData\Local\Opera Software";
            string IeCache = @"C:\Users\" + Environment.UserName+@"\AppData\Local\Microsoft\Windows\INetCache\IE";
            frmUsuario fMain = (frmUsuario)Application.OpenForms["frmUsuario"];
            if (fMain == null) return;

            // Define and run the task.
            Task taskA = Task.Run(() => 
                Tempsize = (GetDirSize(TempDir) + GetDirSize(OperaCache) + GetDirSize(IeCache))
                );
            try
            {
                taskA.Wait();
            }
            catch (Exception)
            {
              return;
            }


            if (Tempsize < 105)
                TempConverted = 100;
            if (Tempsize > 400 && Tempsize < 800)
                TempConverted = 300;
            if (Tempsize > 800 && Tempsize < 1000)
                TempConverted = 500;
            if (Tempsize > 1000 && Tempsize < 1200)
                TempConverted = 800;
            if (Tempsize > 1200 && Tempsize < 1800)
                TempConverted = 1000;
            if (Tempsize > 2000 && Tempsize < 2500)
                TempConverted = 1500;
            if (Tempsize > 4500)
                TempConverted = 2000;


            // Output a message from the calling thread.
            switch (TempConverted)//Tempsize max = 139(BARSIZE)=2000
            {
                case 100://100mb etc etc
                    fMain.pnlMeterBar.Size = new Size(10, 13);
                    fMain.pnlMeterBar.BackColor = Color.SteelBlue;
                    break;
                case 300:
                    fMain.pnlMeterBar.Size = new Size(30, 13);
                    fMain.pnlMeterBar.BackColor = Color.SteelBlue;
                    break;
                case 500:
                    fMain.pnlMeterBar.Size = new Size(50, 13);
                    fMain.pnlMeterBar.BackColor = Color.SteelBlue;
                    break;
                case 800:
                    fMain.pnlMeterBar.Size = new Size(80, 13);
                    fMain.pnlMeterBar.BackColor = Color.DarkOrange;
                    break;
                case 1000:
                    fMain.pnlMeterBar.Size = new Size(100, 13);
                    break;
                case 1500:
                    fMain.pnlMeterBar.Size = new Size(115, 13);
                    fMain.pnlMeterBar.BackColor = Color.DarkRed;
                    break;
                case 2000:
                    fMain.pnlMeterBar.Size = new Size(139, 13);
                    fMain.pnlMeterBar.BackColor = Color.Red;
                    break;
                default:
                    fMain.pnlMeterBar.Size = new Size(2, 13);
                    fMain.pnlMeterBar.BackColor = Color.SteelBlue;
                    break;
            }
        }



        #region GetSizes Func
        private static long GetDirSize(string sourceDir)
        {
            long value = DirectorySize(sourceDir, true);
            //MessageBox.Show("V1 :"+ value.ToString());
            value = value / (1024 * 1024); //- MB
            //MessageBox.Show("V2 Div :" + value.ToString());
            if (value < 1024)
            {return value;}

            if (value <= 1024) 
                return value;

           // value = value / 1024;
            return value;
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

    }
}
/*
 * Task t = Task.Run( () => {
                              // Just loop. 
                              int ctr = 0;
                              for (ctr = 0; ctr <= 1000000; ctr++)
                              {}
                              Console.WriteLine("Finished {0} loop iterations",
                                                ctr);
                           } );
  t.Wait();
 * 
 * 
 * private void WriteToLog(string text)
{
var task = Task.Run(async () => { await WriteToLogAsync(text); });
task.Wait();
}
 */


