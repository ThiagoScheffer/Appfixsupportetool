using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suporte
{
    class cMessenger
    {
        private static bool _hasWork;
        private static string _OnedriveFile = "";
        private static string _agendaFilePath = "";//@"C:\Temp\Agenda.xml";
        static readonly frmUsuario fMainUsuario = (frmUsuario)Application.OpenForms["frmUsuario"];
        static readonly frmEditor fMainEditor = (frmEditor)Application.OpenForms["frmEditor"];
        public static void Start()
        {
          ReadAgendaStatus();

          if (CRegistros.Tecnico)
                StartFileWatched();

        }
        #region Serviços

        private static void StartFileWatched()
        {
            try
            {
                _OnedriveFile = CRegistros.GetOneDriveFolder() + "\\Suporte\\ControledeClientes.xml";
            }
            catch (Exception)
            {
                return;
            }
            if (!Directory.Exists(Path.GetDirectoryName(_OnedriveFile))) return;
            FileSystemWatcher watcher = new FileSystemWatcher(Path.GetDirectoryName(_OnedriveFile))
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite,
                Filter = "ControledeClientes.xml"
            };

            watcher.Changed += OnChanged;
            watcher.EnableRaisingEvents = true;
        }
        // Define the event handlers. 
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
           AvisoTarefaAtualizadas();
        }
        public static void ReadServicosStatus()
        {
            try
            {

            }
            catch (Exception)
            {
                return;
            }
            using (DataSet dataSource = new DataSet())
            {
                if (!File.Exists(_OnedriveFile))
                    return;
                dataSource.ReadXml(_OnedriveFile);
                DataRow[] foundRows = dataSource.Tables["CPFkey"].Select("Status NOT LIKE 'Concluído' OR Status NOT LIKE 'Concluído e Pago'");
                if (foundRows.Length != 0)
                   _hasWork = true;

                if(_hasWork)
                 AvisodeTarefas();
                else
                    LimparAvisos();
            }
        }

        private static void AvisoTarefaAtualizadas()
        {
            frmUsuario frmUsuario = (frmUsuario) Application.OpenForms["frmUsuario"];
            frmUsuario?.notifyIcon.ShowBalloonTip(5, "Controle de Serviços", "Serviços foram atualizados",ToolTipIcon.Info);
            frmEditor frmEditor = (frmEditor) Application.OpenForms["frmEditor"];
            frmEditor?.notifyIcon.ShowBalloonTip(5, "Controle de Serviços", "Serviços foram atualizados",
                ToolTipIcon.Info);
        }

        private static void AvisodeTarefas()
        {
            frmUsuario frmUsuario = (frmUsuario) Application.OpenForms["frmUsuario"];
            if (frmUsuario != null)
            {
                frmUsuario.tbxAvisos.Text = @"Há Serviço(s) pendente(s)";
                frmUsuario.tbxAvisos.ForeColor = Color.White;
                frmUsuario.tbxAvisos.BackColor = Color.CornflowerBlue;
                    //notifyIcon.ShowBalloonTip(5, "Controle de Serviços", "Há Serviço(s) pendente(s)", ToolTipIcon.Info);
            }

            frmEditor frmEditor = (frmEditor) Application.OpenForms["frmEditor"];
            if (frmEditor == null) return;
            frmEditor.tbxAvisos.Text = @"Há Serviço(s) pendente(s)";
            frmEditor.tbxAvisos.ForeColor = Color.White;
            frmEditor.tbxAvisos.BackColor = Color.CornflowerBlue;
        }
        #endregion

        #region Agenda
        //Novo metodo
        public static void ReadAgendaStatus()
        {
            Task taskA = Task.Run(() =>LoadAgendaMethod());
            taskA.Wait();
        }

        #endregion

        private static void LoadAgendaMethod()
        {
            var Onefolder = CRegistros.GetOneDriveFolder();

            if (Onefolder == null) return;//win7fix

            _agendaFilePath = CRegistros.GetOneDriveFolder() + "\\Suporte\\Agenda.xml";

            if (!File.Exists(_agendaFilePath))
                return;
     

            using (DataSet dataSet = new DataSet())
            {
                dataSet.ReadXml(_agendaFilePath);
                dataSet.Tables["Evento"].DefaultView.Sort = "Data ASC";
                DataView dv = new DataView(dataSet.Tables["Evento"]) {Sort = "Data ASC"}; //FIXED Ordem errada de Avisos

                try
                {
                    //foreach (DataRow row in dataSet.Tables["Evento"].Rows)
                    foreach (DataRowView row in dv)
                    {
                        //HJ
                        if (row["Status"].ToString() != "Agendado")
                            continue;
                        DateTime dateTime = Convert.ToDateTime(row["Data"]);
                        if (dateTime.ToShortDateString() == DateTime.Today.ToShortDateString() && DateTime.Parse(dateTime.ToShortTimeString()) >= DateTime.Parse(DateTime.Now.ToShortTimeString()))
                        {
                            var row1 = row;
                            cUtils.SendMsg(@"Hoje às: " + row1["Hora"] + @" -> " + row1["Nome"], null,Color.Orange);
                            return;
                        }
                    }
                    foreach (DataRowView row in dv)
                    {
                        //Amanha
                        //HJ
                        if (row["Status"].ToString() != "Agendado")
                            continue;

                        if (Convert.ToDateTime(row["Data"].ToString()).ToShortDateString() ==
                            DateTime.Today.AddDays(1).ToShortDateString())
                        {
                            var row1 = row;
                            cUtils.SendMsg(@"Amanha às: " + row1["Hora"] + @" -> " + row1["Nome"], null, Color.YellowGreen);
                            return;
                        }
                    }

                   cUtils.SendMsg(" ", " ", Color.Empty);
                    cUtils.SendMsg(" ", " ", Color.White);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
        }

        private static void LimparAvisos()
        {
            frmUsuario frmUsuario = (frmUsuario)Application.OpenForms["frmUsuario"];
            if (frmUsuario != null)
            {
                frmUsuario.tbxAvisos.Text = "";
                frmUsuario.tbxAvisos.ForeColor = Color.Black;
                frmUsuario.tbxAvisos.BackColor = Color.White;
                return;
            }

            frmEditor frmEditor = (frmEditor)Application.OpenForms["frmEditor"];
            if (frmEditor != null)
            {
                frmEditor.tbxAvisos.Text = "";
                frmEditor.tbxAvisos.ForeColor = Color.Black;
                frmEditor.tbxAvisos.BackColor = Color.White;
            }
        }


        //Mostrar alerta - compara data marcada com o dia de hj.
        public static void AvisodeRevisao()
        {
            if (CRegistros.GetSetDataRetornoRevisao == "False") return;
            //RESGATAR INFORMAÇOES PARA AVISOS E FIM DO TRIAL
            DateTime dataGravada;
            DateTime.TryParse(CRegistros.GetSetDataRetornoRevisao, out dataGravada);//Data Gravada
            DateTime datadeHj = DateTime.Now.Date;
            //Passaram 60 dias - dataGravada = HJ = que (HJ-60 dias a partir da datagravada)
            if (dataGravada.AddMonths(2) == datadeHj)
            {
                frmAvisosRetorno frmAvisosRetorno = new frmAvisosRetorno(@"Caro cliente, é recomendado uma revisão neste computador para o melhor rendimento e segurança.");
                frmAvisosRetorno.ShowDialog();
               // MessageBox.Show(@"Falta menos de 15 dias para o sistema expirar!", @"ATENÇÃO", MessageBoxButtons.OK,
                //MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }



}
