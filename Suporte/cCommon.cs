using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using Suporte.Properties;
using Timer = System.Windows.Forms.Timer;

namespace Suporte
{
    static class cCommon
    {
        private const string UpdaterExePath = @"C:\ProgramData\SuporteUpdater\suporteupdater.exe";
        private static int _segundos;
        private static readonly Timer timer = new Timer();
       // private static Task<Task> tStartListTask; 
        public static void StartMethods()
        {

            //Criar diretorios do aplicativo.
            CreateDirs();

            //Termos.
            //CRegistros.TermosdeGarantia();

            //Timer para as funções básicas. Dando tempo para a execuçao
            _segundos = 0;
            timer.Interval = 1000;
            timer.Tick += TimerOnTick;
            timer.Start();
        }

        private static void ClearSuportDir()//Limpa o diretorio de updates
        {
            try
            {
                if(File.Exists(@"C:\ProgramData\SuporteUpdater\SuporteCommands.xml"))
                    File.Delete(@"C:\ProgramData\SuporteUpdater\SuporteCommands.xml");

                if (File.Exists(@"C:\ProgramData\SuporteUpdater\versionupdate.xml"))
                    File.Delete(@"C:\ProgramData\SuporteUpdater\versionupdate.xml");

                if (File.Exists(@"C:\ProgramData\SuporteUpdater\VirusDatabase.xml"))
                    File.Delete(@"C:\ProgramData\SuporteUpdater\VirusDatabase.xml");

                if (File.Exists(@"C:\ProgramData\SuporteUpdater\ControledeSituacao.xml"))
                    File.Delete(@"C:\ProgramData\SuporteUpdater\ControledeSituacao.xml");

                if (File.Exists(@"C:\ProgramData\SuporteUpdater\controledepagamentos.xml"))
                    File.Delete(@"C:\ProgramData\SuporteUpdater\controledepagamentos.xml");

                if (File.Exists(@"C:\ProgramData\SuporteUpdater\suporte.exe"))//3089
                    File.Delete(@"C:\ProgramData\SuporteUpdater\suporte.exe");
            }
            catch (Exception)
            {
            }
        }

        private static void TimerOnTick(object sender, EventArgs eventArgs)
        {
            _segundos++;
            //10 segundos para liberar tarefas primarias
            if (_segundos == 10)
            {
                cUtils.SendMsg( null,"Iniciando...",Color.Empty);
                ClearSuportDir();//Limpeza de arquivos nao atualizados.
            }

            if (_segundos == 20)
            {
                cUtils.SendMsg(null,"Registrando configurações...", Color.Empty);
             
                if (Program.Editor)
                {
                    if(Program.PPInstalled)
                    { 
                    cEditor.WritetoDefaultCacheKeys();//Força registro dos diretorios de Cache - QUANDO FOR DEFINIDO
                    cEditor.WriteAllValuestoRegistry();
                    }
                    cEditor.StartWorker();//Atualizar Campos do form (requer 10s para atualizar os reg)
                }

               cUtils.DownloadFile("xxxxxxxxxx", "controledepagamentos.xml");
            }
            if (_segundos == 30)
            {

                if (CRegistros.Administrativo)
                {

                    cUtils.SendMsg(null, "Verificando débitos...", Color.Empty);
                    VerificarPagamento();
                }

                if (CRegistros.Tecnico)
                    cMessenger.Start();//Verifica atual dos serviços,agenda etc

                cUtils.DownloadFile("xxxxxxxxxxxx", "VirusDatabase.xml");
      
            }

            if (_segundos == 40)
            {
                cIntegridade.StartSystemCheck();//Verifica Malwares e afins - download de arquivos do aplicativo.
                cUtils.SendMsg(null, "Verificando integridade...", Color.Empty);
                cUtils.DownloadFile("xxxxxx", "SuporteCommands.xml");
            }
            if (_segundos == 45)
            {
                
                cUtils.SendMsg(null, "Verificando atualizações...", Color.Empty);
                
                //MSG
                cMessenger.AvisodeRevisao();

                if (!Program.Debug)
                    StartUpdater();
            }
            if (_segundos == 50)
            {
                frmAdministrador.ReadServerCommands();
                cUtils.SendMsg(null, "Aplicativo pronto.", Color.Empty);
            }
            if (_segundos == 60)
            {
                timer.Stop();
                timer.Dispose();
            }
        }

        //CRIA OS DIRETORIOS PRIMARIOS
        private static void CreateDirs()
        {
            if (!Directory.Exists(Program.InstallDir))
            {
                Directory.CreateDirectory(Program.InstallDir);
                CRegistros.GrantAccess(Program.InstallDir);// SET  ADM ACCESS
            }
            if (Directory.Exists(Program.UpdateDir)) return;
            Directory.CreateDirectory(Program.UpdateDir);
            CRegistros.GrantAccess(Program.UpdateDir);// SET  ADM ACCESS
        }
        //VERIFICAR PAGAMENTOS
        private static void VerificarPagamento()
        {
            //Se status de ativação é "Por Ativar" retorna.
            //  if (!cAtivacao.GetAtivStatus())
             //   return;
            //Se for nao for administrativo nao ha necessidade de ficar recebendo informaçoes de pagamentos.
            if (!CRegistros.Administrativo)
                return;
            //Fix offline msg
            if(!cUtils.ConnectionAvailable()) return;

            using (frmPagamento frmPagVerif = new frmPagamento())
            {
                frmPagVerif.StartPagCheck(); //Iniciar Verificação de pagamentos
            }
        }

        //UPDATER - Verifica se existe o updater ! cria e executa;
        private static void StartUpdater()
        {
            try
            {
                const string updatefile = Program.UpdateDir + "\\suporteupdater.exe";

                if (!File.Exists(updatefile))
                {
                    File.WriteAllBytes(UpdaterExePath, Resources.suporteupdater);
                }
                Thread.Sleep(1000);
                //Atualizar Updater sempre.
                int verint = cUtils.GetfileversionInt(updatefile);
                if (verint < 1040)
                {
                    File.Delete(updatefile);
                    Thread.Sleep(1000);
                    File.WriteAllBytes(UpdaterExePath, Resources.suporteupdater);
                }
               // MessageBox.Show(verint.ToString());
                
               //Não usar AsAdmin
                Process.Start(updatefile);
            }
            catch (Exception exception)
            {
                cUtils.LogSend("UpdaterStart: \n "+ exception.ToString());
            }
        }
    }
}
