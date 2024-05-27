using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmPaineldeControle : Form
    {
        private  string _servicosFile = "";
        private  string _agendaFilePath = "";
        private  string _estoqueFile;
        public frmPaineldeControle()
        {
            InitializeComponent();
        }

        private void Start()
        {
            //return;//REMOVER
            
            ReadAgendaStatus();
           // ReadOrcamentoStatus();
            ReadServicosStatus();
            ReadPagStatus();
            ReadEstoque();
        }
        #region Serviços

        private void ReadServicosStatus()
        {
            try
            {
                _servicosFile = CRegistros.GetOneDriveFolder()+ "\\Suporte\\ControledeServicos.xml";
            }
            catch (Exception)
            {
                return;
            }

            using (DataSet dataSource = new DataSet())
            {
                try
                {
                    if (!File.Exists(_servicosFile))
                        return;
                    dataSource.ReadXml(_servicosFile);
                    // if(dataSource.)
                    //Serv concluidos mas nao pagos.
                    DataRow[] foundRows = dataSource.Tables["CPFkey"].Select("Status LIKE 'Concluído'");
                    /*
                     * Aguardando
                        Aguardando Material
                        Aguardando Autorização
                        Saiu para Entrega
                        Concluído e Pago
                        Concluído
                        Em Andamento
                     */
                    // "NOT (City = 'Tokyo' OR City = 'Paris')
                    //Select itens que estao pendentes e avisar!
                    DataRow[] foundRowsImport = dataSource.Tables["CPFkey"].Select("NOT (Status= 'Concluído' OR Status= 'Concluído e Pago') ");
                    int import = foundRowsImport.Length;//Numero em pedencia
                    int npag = foundRows.Length;//nao pagos

                    //Serviços em Espera
                    foreach (DataRow row in dataSource.Tables["CPFkey"].Rows)
                    {
                        if (row["Status"].ToString() == "Concluído" || row["Status"].ToString() == "Concluído e Pago") continue; //Ignora todos nao aguardando
                        if (row["Status"].ToString() != "Concluído" || row["Status"].ToString() != "Concluído e Pago")
                        {
                            lblServAviso.Text = @"Serviço(s) na espera: " + import;
                            lblServAviso.BackColor = Color.Orange;
                            return;
                        }
                    }

                    //serviços nao pagos
                    foreach (DataRow row in dataSource.Tables["CPFkey"].Rows)
                    {
                        if (row["Status"].ToString() == "Concluído")
                        {
                            lblServAviso.Text = @"Serviço(s) não pago(s): " + npag;
                            lblServAviso.BackColor = Color.Turquoise;
                            return;
                        }
                    }
                    lblServAviso.Text = "";
                    lblServAviso.BackColor = Color.White;
                }
                catch (Exception)
                {}
            }
        }

        #endregion

        #region Agenda

        private void ReadAgendaStatus()
        {
            try
            {
                _agendaFilePath = CRegistros.GetOneDriveFolder() + "\\Suporte\\Agenda.xml";
            }
            catch (Exception)
            {
                return;
            }

            if (!File.Exists(_agendaFilePath))
                return;
            using (DataSet dataSet = new DataSet())
            {
                dataSet.ReadXml(_agendaFilePath);
                dataSet.Tables["Evento"].DefaultView.Sort = "Data ASC";
                DataView Dv = new DataView(dataSet.Tables["Evento"]);//FIXED Ordem errada de Avisos
                Dv.Sort = "Data ASC";
               
                try
                {
                    //foreach (DataRow row in dataSet.Tables["Evento"].Rows)
                    foreach (DataRowView row in Dv)
                    {
                        //HJ
                        if (row["Status"].ToString() != "Agendado")
                            continue;
                        DateTime dateTime = Convert.ToDateTime(row["Data"]);
                        if (dateTime.ToShortDateString() == DateTime.Today.ToShortDateString() && DateTime.Parse(dateTime.ToShortTimeString()) >= DateTime.Parse(DateTime.Now.ToShortTimeString()))
                        {
                            lblAvisos.Text = @"Hoje às: " + row["Hora"] + @" -> " + row["Nome"];
                            lblAvisos.BackColor = Color.Orange;
                            return;
                        }
                    }
                    foreach (DataRowView row in Dv)
                    {
                        //Amanha
                        //HJ
                        if (row["Status"].ToString() != "Agendado")
                            continue;

                        if (Convert.ToDateTime(row["Data"].ToString()).ToShortDateString() ==
                            DateTime.Today.AddDays(1).ToShortDateString())
                        {
                            lblAvisos.Text = @"Amanha às: " + row["Hora"] + @" -> " + row["Nome"];
                            lblAvisos.BackColor = Color.YellowGreen;
                            return;
                        }
                    }
                    lblAvisos.Text = "";
                }
                catch (Exception)
                {

                }
            }
        }

        #endregion
/*
        #region Orçamento

        private void ReadOrcamentoStatus()
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
                if (!File.Exists(_servicosFile))
                    return;
                dataSource.ReadXml(_servicosFile);
                DataRow[] foundRows = dataSource.Tables["Pkey"].Select("Status LIKE 'Aguardando'");
                if (foundRows.Length != 0)
                {
                    lblOrcaAviso.Text = "Há um orçamento em espera";
                    lblOrcaAviso.BackColor = Color.Orange;
                }
                else
                    lblOrcaAviso.Text = "";
            }
        }
        #endregion
*/
        #region Pagamentos

        private void ReadPagStatus()
        {
            try
            {
                _servicosFile = CRegistros.GetOneDriveFolder() + "\\Suporte\\controledepagamentos.xml";
            }
            catch (Exception)
            {
                return;
            }
            using (DataSet dataSource = new DataSet())
            {
                if (!File.Exists(_servicosFile))
                    return;
                dataSource.ReadXml(_servicosFile);
                DataRow[] foundRows = dataSource.Tables["Clientes"].Select("Status NOT LIKE 'Pago'");
                if (foundRows.Length != 0)
                {
                    lblPagstatus.Text = "Há debitos pendentes";
                    lblPagstatus.BackColor = Color.Orange;
                }
                else
                    lblPagstatus.Text = "";
            }
        }
        #endregion

        #region Estoque

        private void ReadEstoque()
        {
            try
            {
                _estoqueFile = CRegistros.GetOneDriveFolder() + "\\Suporte\\ControledeEstoque.xml";
            }
            catch (Exception)
            {
                return;
            }
            using (DataSet dataSource = new DataSet())
            {
                if (!File.Exists(_estoqueFile))
                    return;
                dataSource.ReadXml(_estoqueFile);

                try
                {
                    foreach (DataRow row in dataSource.Tables["Produto"].Rows)
                    {
                        //HJ
                        if ( string.IsNullOrEmpty(row["Aviso"].ToString()))
                            continue;

                        if (Convert.ToInt16(row["Aviso"]) >= Convert.ToInt16(row["Restante"]))
                        {
                            lblEstqStatus.Text = @"Revisar o Estoque";
                            lblEstqStatus.BackColor = Color.Orange;
                            return;
                        }
                    }
                    lblEstqStatus.Text = "";
                }
                catch (Exception)
                {

                }
            }
            
        }
        #endregion
        private void frmPaineldeControle_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            if (!cUtils.ConnectionAvailable()) return;
            frmAgenda frmAgenda = new frmAgenda(); 
            Close();
            frmAgenda.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            //frmControledeOrcamentos frmOrca = new frmControledeOrcamentos();
            //frmOrca.Show();
            FrmControledeClientes frmControledeClientes = new FrmControledeClientes();
            frmControledeClientes.Show();
        }

        private void btnServicos_Click(object sender, EventArgs e)
        {
            frmControledeServicos frmClientControl = new frmControledeServicos();
            frmClientControl.Show();
        }

        private void btnPagmentos_Click(object sender, EventArgs e)
        {
            frmControledePag frmAdmPag = new frmControledePag();
            frmAdmPag.Show();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            frmControledeEstoque frmControledeEstoque = new frmControledeEstoque();
            frmControledeEstoque.Show();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            frmControledeProdutos frmControleProdutos = new frmControledeProdutos();
            frmControleProdutos.Show();
        }
    }
}
