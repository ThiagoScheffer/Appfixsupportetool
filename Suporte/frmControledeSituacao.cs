using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmControledeSituacao : Form
    {
        private readonly DataSet _dataSet = new DataSet();
        private readonly DataTable _dataTable = new DataTable("Clientes");

        private const string XMLURL = "https://onedrive.live.com/download?cid=A24F44861BB6D250&resid=A24F44861BB6D250%21365&authkey=AKZ4soLTmKkd6zE";
        private const string XMLPath = @"C:\ProgramData\SuporteUpdater\ControledeSituacao.xml";
        public frmControledeSituacao()
        {
            InitializeComponent();
        }
        #region FORM
        private void frmControledeEstoque_Load(object sender, EventArgs e)
        {
           
            StartDownload();
        }
        #endregion
        
        #region Estoque View
        private void LoadGrid()
        {
            try
            {
                _dataSet.Clear(); //Limpa para atualizar
                _dataTable.Reset();
                _dataTable.Columns.Add(new DataColumn("Cliente", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Data", typeof(DateTime)));
                _dataTable.Columns.Add(new DataColumn("Serviço", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Status", typeof(string)));
                _dataSet.Tables.Add(_dataTable);
                _dataSet.ReadXml(XMLPath);

                //DATAVIEW
                string ClienteCadastrado = CRegistros.GetCliente();
                DataView dvView = new DataView(_dataSet.Tables["Clientes"])
                {
                    RowFilter = "Cliente LIKE '" + ClienteCadastrado + "'"
                };

                dgvServicos.DataSource = dvView;//new BindingSource(_dataSet, "Clientes");

                //VISUAL
                dgvServicos.Columns[0].Visible = false;
                dgvServicos.Columns[1].ValueType = typeof(DateTime);
                dgvServicos.Columns[1].DefaultCellStyle.Format = "d";
                dgvServicos.Sort(dgvServicos.Columns[1], ListSortDirection.Ascending);
                dgvServicos.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvServicos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //descr 
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
        #endregion

        private void CleanTraces()
        {
            try
            {
                //Privacidade.
                if (File.Exists(XMLPath))
                    File.Delete(XMLPath);
            }
            catch (Exception)
            {
            }

        }

        private void StartDownload()
        {
            try
            {
                try
                {
                    CleanTraces();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Falha ao Acessar o Arquivo ! Tente novamente.");
                    return;
                }

                WebClient webDownup = new WebClient();
                webDownup.DownloadFileAsync(new Uri(XMLURL), XMLPath);
                webDownup.DownloadFileCompleted += webDownup_DownloadFileCompleted;

            }
            catch (WebException error)
            {
                cUtils.LogSend("CheckupdatePag" + "\n" + error);
                MessageBox.Show("Foi encotrado um problema. Um Log foi enviado para o Técnico corrigir.");
            }
        }

        private void webDownup_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            LoadGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
