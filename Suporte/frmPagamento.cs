using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Suporte
{
    public partial class frmPagamento : Form
    {
        private readonly DataSet _dataSet = new DataSet();
        private readonly DataTable _dataTable = new DataTable("Clientes");

        private static bool HasPendencia;
        private string Ano = "Todos";
        private string Tipo = "Todos";
        //private static string XMLPagamentos = @"C:\Users\EncryptorX\Dropbox\Empresa\Aplicativos\Suporte\controledepagamentos.xml";
        private string XMLPagamentos = @"C:\ProgramData\SuporteUpdater\controledepagamentos.xml";
       // private const string XMLPagURL = "https://dl.dropboxusercontent.com/s/7nbkemfpt6mxuix/controledepagamentos.xml";
        private static string AvisoMSG;

        // private const string RegFolderNt = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";

        public frmPagamento()
        {
            InitializeComponent();
        }
        private void LoadInfofromXML()
        {
            try
            {
                HasPendencia = false; //Reseta antes de atualizar
                if (Program.PagButtonPressed)
                {
                    if (!File.Exists(XMLPagamentos))
                        if(Program.Debug)//use this one for testing
                        XMLPagamentos = CRegistros.GetOneDriveFolder() + "\\Suporte\\controledepagamentos.xml";
                    else
                    {
                        cUtils.DownloadFile("xxxx",
                            "controledepagamentos.xml");
                        MessageBox.Show(@"Arquivo de pagamento será atualizado apos o OK...");
                        Thread.Sleep(6000);//Fix access error
                    }
                   

                    LoadDataGrid();
                }
                else
                    LoadTempDataGrid(); //grid temporaria e invisivel para tooltip info - iniciada 1 vez ao carregar o aplicativo
            }
            catch (Exception)
            {
                //  MessageBox.Show(exception.ToString());
                CleanTraces();
                Visible = false;
                HasPendencia = false;
                Close();
            }

        }

        private void CleanTraces()
        {
            try
            {
                //Privacidade.
                if (!Program.Debug)
                {
                    if (File.Exists(XMLPagamentos))
                        File.Delete(XMLPagamentos);
                }
            }
            catch (Exception)
            {
            }

        }

       

        //CARREGAR DATAGRID MAIN
        private void LoadDataGrid()
        {
            try
            {
                _dataSet.Clear(); //Limpa para atualizar
                _dataTable.Reset();
                _dataTable.Columns.Add(new DataColumn("Cliente", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Data", typeof(DateTime)));
                _dataTable.Columns.Add(new DataColumn("Tipo", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Valor", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("ValorPago", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("PC", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Status", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Descrição", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Ano", typeof(int)));
                _dataSet.Tables.Add(_dataTable);
                _dataSet.ReadXml(XMLPagamentos);

                //DATAVIEW
                string ClienteCadastrado = CRegistros.GetCliente();
                DataView dvView = new DataView(_dataSet.Tables["Clientes"])
                {
                    RowFilter = "Cliente LIKE '" + ClienteCadastrado + "'"
                };

                dataGridView1.DataSource = dvView;//new BindingSource(_dataSet, "Clientes");
                //VISUAL
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns["Data"].ValueType = typeof(DateTime);
                dataGridView1.Columns["Data"].DefaultCellStyle.Format = "d";
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

                dataGridView1.Columns["Descrição"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.Columns["Descrição"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                DataGridSum(); //Destaca os itens nao pagos
            }
            catch (Exception e)
            {
               // MessageBox.Show(@"Não há registros ainda neste controle.");
                MessageBox.Show(e.ToString());
                Close();
            }
        }

        private void DataGridSum()
        {
            double SomaTotal = 0;
            double SomaTotaljapago = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Status"].Value.ToString() == "Pago") continue;

                row.DefaultCellStyle.BackColor = Color.LightSalmon;
                HasPendencia = true;
                SomaTotal += Convert.ToDouble(row.Cells["Valor"].Value);
                SomaTotaljapago += Convert.ToDouble(row.Cells["ValorPago"].Value);
            }

            SomaTotal = SomaTotal - SomaTotaljapago;
            decimal TotalServicos = dataGridView1.RowCount;
            //MessageBox.Show(IsPago.ToString());
            tbxTotal.Text = SomaTotal.ToString("C");
            tbxNservicos.Text = TotalServicos.ToString(CultureInfo.InvariantCulture);
            dataGridView1.AutoResizeRows();
           // dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }


        //CARREGAR DATAGRID COM FILTRO
        private void DatagridFiltered()
        {
            string ClienteCadastrado = CRegistros.GetCliente();
            DataView dvView = new DataView(_dataSet.Tables["Clientes"]);
            if (Ano == "Todos" && Tipo == "Todos")
            {
                dvView.RowFilter = "cliente LIKE '" + ClienteCadastrado + "'";
            }
            else if (Ano == "Todos" && Tipo != "Todos") // TODOS E ALGUM
            {
                dvView.RowFilter = "cliente LIKE '" + ClienteCadastrado + "'" + "AND tipo LIKE '" +
                                   cbxTipo.SelectedItem + "'";
            }
            else if (Ano != "Todos" && Tipo == "Todos") // ALgum e TODOS
            {
                dvView.RowFilter = "cliente LIKE '" + ClienteCadastrado + "' AND Ano LIKE '" + Ano + "'";
            }
            else if (Ano != "Todos" && Tipo != "Todos")
            {
                dvView.RowFilter = "cliente LIKE '" + ClienteCadastrado + "'" + "AND tipo LIKE '" + cbxTipo.SelectedItem + "' AND Ano LIKE '" + Ano + "'";
            }
            dataGridView1.DataSource = dvView;//new BindingSource(_dataSet, "Clientes");

            //VISUAL
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].ValueType = typeof(DateTime);
            dataGridView1.Columns[1].DefaultCellStyle.Format = "d";
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            dataGridView1.Columns["Descrição"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["Descrição"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.AutoResizeRows();
        }

        //(dataGridViewFields.DataSource as DataTable).DefaultView.RowFilter = string.Format("Field = '{0}'", textBoxFilter.Text);
        private void LoadTempDataGrid()
        {
            if(Program.PagButtonPressed) return;
            // XmlReader reader = XmlReader.Create(@"c:\intel\teste.xml");
            using (DataSet dataSource = new DataSet())
            {
                if (!File.Exists(XMLPagamentos))
                    return;
                dataSource.ReadXml(XMLPagamentos);

                //Dias definidos manualmente
                int i = CRegistros.GetDiaPrazo().Item1;
                int f = CRegistros.GetDiaPrazo().Item2;
               // bool ativado = cAtivacao.GetAtivStatus();

                //== HJ tem que ser maior que dia i e menor que dia f = padrao 1 e 7
                bool Prazo = DateTime.Today.Day > i && DateTime.Today.Day <= f; 
                string ClientName = CRegistros.GetCliente();
                if (Prazo)
                {
                    foreach (DataRow row in dataSource.Tables["Clientes"].Rows)
                    {
                        if (row["Cliente"].ToString() != ClientName) continue; //Ignora os outros clientes
                        //Sendo Não Pago + Prazo = 
                        if (row["Status"].ToString() != "Não Pago") continue;
                        
                        HasPendencia = true;//Marca Pendencias

                        //Se o valor do deb for maior que 100,00 e a dif de tempo do serviço realizado for menor que 12 dias no minimo ignorar
                        double valor = Convert.ToDouble(row[3]);
                        if (valor >= 300.0) continue;

                        //Guarda o valor de quantos dias passaram desde o ultimo serviço
                        DateTime dtTabela = DateTime.Parse(row["Data"].ToString());
                        DateTime dtDatadeHJ = DateTime.Today.Date;
                        var DiasCalculo = dtTabela.Date - dtDatadeHJ.Date;
                        int DiasdeAtraso = DiasCalculo.Days * -1;

                        //Se passou 1 mes ignorar
                        if (DiasdeAtraso  > 30) continue; if (DiasdeAtraso < 12) continue;

                        AvisoMSG = "Nosso Controle de pagamentos acusa um débito, referente a serviço(s) realizado(s) há " + DiasdeAtraso.ToString()+ " dias, prestes a expirar, motivo pelo qual solicitamos-lhe a regularização da situação.";

                        Messenger frmMessenger = new Messenger(AvisoMSG);
                        frmMessenger.ShowDialog();
                        return;
                    }
                }
                else
                {
                    foreach (DataRow row in dataSource.Tables["Clientes"].Rows)
                    {
                        if (row["Cliente"].ToString() != ClientName) continue; //Ignora os outros clientes
                        if (row["Status"].ToString() != "Não Pago") continue;

                        //Se o valor do deb for maior que 100,00 e a dif de tempo do serviço realizado for menor que 12 dias no minimo ignorar
                        double valor = Convert.ToDouble(row[3]);
                        DateTime dtTabela = DateTime.Parse(row["Data"].ToString());
                        DateTime dtDatadeHJ = DateTime.Today.Date.AddDays(1);
                        if (valor > 250 && dtDatadeHJ.ToShortDateString() == dtTabela.ToShortDateString())
                        {
                            AvisoMSG =
                                string.Format(
                                    @"Lembrete: {0} é a data de pagamento da prestação de sua compra, realizada com nossa empresa.",
                                    dtTabela.ToShortDateString());

                            Messenger frmMessenger01 = new Messenger(AvisoMSG);
                            frmMessenger01.ShowDialog();
                            break;
                        }
                    }

                    if ((from DataRow row in dataSource.Tables["Clientes"].Rows where row["Cliente"].ToString() == ClientName where row["Status"].ToString() == "Não Pago" select Convert.ToDouble(row[3])).Any(valor => !(valor >= 150)))
                    {
                        HasPendencia = true;
                        IniciarAvisoPendencias();
                    }
                }
            }
        }

        //Verifica e Ativa o Aviso
        private void IniciarAvisoPendencias()
        {
            //MessageBox.Show("Verfica: " + HaPendencia + " Acess: " + Program._PagAccess);
            //Se for Administrativo este micro so recebe uma mensagem via BallonTip.
            if (!HasPendencia) return;
            frmUsuario frmUsuario = (frmUsuario) Application.OpenForms["frmUsuario"];
            if (frmUsuario != null)
            {
                frmUsuario.notifyIcon.ShowBalloonTip(5, "AVISO",
                    "Lembre-se: Você ainda não efetuou o pagamento do ultimo serviço prestado.",
                    ToolTipIcon.Info);
            }

            CleanTraces();
        }

        public void StartPagCheck()
        {
            LoadInfofromXML();
        }


        private void frmPagamento_Load(object sender, EventArgs e)
        {
            //Auto Completar Campos
            tbxNomeCliente.Text = CRegistros.GetCliente().Replace('_',' ');
            cbxTipo.SelectedIndex = 0;
            cbxAno.SelectedIndex = 0;
            LoadInfofromXML();
        }

        private void frmPagamento_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Program.PagButtonPressed = false; //Reseta para falso o acesso de verif pagamento via botao
                CleanTraces();
            }
            catch (Exception)
            {

            }

        }

        private void cbxAno_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string AnoSelecionado = cbxAno.SelectedItem.ToString();

            try
            {
                if (AnoSelecionado.Equals("2013"))
                {
                    Ano = "2013";
                    //LoadDataGrid();
                }
                else if (AnoSelecionado.Equals("2014"))
                {
                    Ano = "2014";
                    // LoadDataGrid();
                }
                else if (AnoSelecionado.Equals("2015"))
                {
                    Ano = "2015";
                    // LoadDataGrid();
                }
                else if (AnoSelecionado.Equals("Todos"))
                {
                    Ano = "Todos";
                    // LoadDataGrid();
                }
            }
            finally
            {
                DatagridFiltered();
            }

        }

        private void cbxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string TipoSelecionado = cbxTipo.SelectedItem.ToString();
            try
            {
                if (TipoSelecionado.Equals("Compra"))
                {
                    Tipo = "Compra";
                    //LoadDataGrid();
                }
                else if (TipoSelecionado.Equals("Remoto"))
                {
                    Tipo = "Remoto";
                    // LoadDataGrid();
                }
                else if (TipoSelecionado.Equals("Atendimento"))
                {
                    Tipo = "Atendimento";
                    // LoadDataGrid();
                }
                else if (TipoSelecionado.Equals("Todos"))
                {
                    Tipo = "Todos";
                    // LoadDataGrid();
                }
            }
            finally
            {
               DatagridFiltered(); 
            }
  
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
        
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PaintEventArgs myPaintArgs = new PaintEventArgs(e.Graphics,


                                 new Rectangle(new Point(0, 0), this.Size));


            this.InvokePaint(dataGridView1, myPaintArgs);
        }
    }

}