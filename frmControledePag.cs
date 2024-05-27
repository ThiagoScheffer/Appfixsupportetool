using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Suporte
{
    public partial class frmControledePag : Form
    {
        //private string XMLPagamentos = @"C:\ProgramData\SuporteUpdater\controledepagamentos.xml";
       // private string Cliente = "";
        //delegate void SetComboBoxCellType(int iRowIndex);
        private readonly DataSet _dataSet = new DataSet();
        private readonly DataTable _dataTable = new DataTable("Clientes");
        private int Index = 0;
        private int filteridx = -1;
        private string FilePath;
        #region FORM
        public frmControledePag()
        {
            InitializeComponent();
        }
        private void LoadDataGridWithFilter(string filtro)
        {
            //_dataSet.Clear(); //Limpa para atualizar
            //_dataSet.ReadXml(tbxLocalXML.Text);
            dataGridView1.DataSource = _dataSet;
            dataGridView1.DataMember = "Clientes";
            DataView dvView = new DataView(_dataSet.Tables[0]);

            if (filtro != " ")
            {
                if (filteridx == 0)
                    dvView.RowFilter = "Cliente LIKE '" + filtro + "'";
                else
                    dvView.RowFilter = "Status LIKE '" + filtro + "'";
            }


            dataGridView1.DataSource = dvView;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //cliente
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //data
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //tipo
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //valor
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //valorpago
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //PC
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Status

            dataGridView1.Columns["Descrição"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["Descrição"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //descr
             
           // dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //ano 

            HighlightGrid();
        }

        private void HighlightGrid()
        {
            double somavalores = 0.0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                //fix null
                if (row.Cells["Valor"].Value == null)
                    return;

                //all values sum
                var valores = Convert.ToDecimal(row.Cells["Valor"].Value);
                if (valores == 0) continue;
                somavalores += (double)valores;
                tbxValores.Text = somavalores.ToString("C2");


                object value = row.Cells["Status"].Value;
                if (value == null) continue;
                if (value.ToString() == "Pago" || value.ToString() == "") continue;
                row.DefaultCellStyle.BackColor = Color.Orange;
            }

             ScrollDown();
        }

        private void FeedComboBoxFilter()
        {
            //String[] arrays;
            if (filteridx == 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    object value = row.Cells["Cliente"].Value;
                    if (value != null && cbxFilter.Items.Contains(value)) continue;
                    var o = row.Cells[0].Value;
                    if (o != null && o.ToString() != string.Empty)
                        cbxFilter.Items.Add(o.ToString());

                }
            }
            if (filteridx == 5)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var value = row.Cells["Status"].Value;
                    if (value != null && cbxFilter.Items.Contains(value)) continue;
                    if (value != null && value.ToString() == "Não Pago")
                        cbxFilter.Items.Add(value);
                }
            }
        }


        private void chkbxFilterbyName_CheckStateChanged(object sender, EventArgs e)
        {
            
           // if (!tbxLocalXML.Text.Contains("controledepagamentos"))
           //     return;
            cbxFilter.Items.Clear();
            cbxFilter.Enabled = chkbxFilterbyName.CheckState == CheckState.Checked;
            filteridx = 0;
            FeedComboBoxFilter();//Nomes


            chkbxPerStatus.CheckState = CheckState.Unchecked;
            chkbxPerStatus.Enabled = false;//Desativar o filtro por Status
            if (chkbxFilterbyName.CheckState == CheckState.Unchecked)
            {
                chkbxPerStatus.Enabled = true;
                cbxFilter.Enabled = false;
                LoadDataGridWithFilter(" ");
            }
        }

        private void chkbxPerStatus_CheckStateChanged(object sender, EventArgs e)
        {
           // if (!tbxLocalXML.Text.Contains("controledepagamentos"))
            //    return;
            cbxFilter.Items.Clear();
            chkbxFilterbyName.CheckState = CheckState.Unchecked;
            chkbxFilterbyName.Enabled = false;
            cbxFilter.Enabled = false;
            filteridx = 5;
            if (chkbxPerStatus.CheckState == CheckState.Unchecked)
            {
                chkbxFilterbyName.Enabled = true;
                cbxFilter.Enabled = true;
                LoadDataGridWithFilter(" ");
                return;
            }
            //FeedComboBoxFilter();//Status
            LoadDataGridWithFilter("Não Pago");//Load       

        }

        //ComboBox
        private void cbxFilterNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxFilter.SelectedItem.ToString()))
                LoadDataGridWithFilter(cbxFilter.SelectedItem.ToString());
        }
        #endregion

        private void Gravar()
        {
            dataGridView1.Update();
            dataGridView1.EndEdit();
            _dataSet.AcceptChanges();
            _dataSet.WriteXml(FilePath);

                HighlightGrid();
        }


        private void ScrollDown()
        {
            dataGridView1.AutoResizeRows();
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }
        private void LoadDataGrid()
        {
            //_dataSet.Clear();
            //_dataSet.ReadXml(tbxLocalXML.Text);//<-- carrega do diretorio selecionado
            //dataGridView1.DataSource = _dataSet;
            //dataGridView1.DataMember = "Clientes";//-> Busca dentro do ds o Datamember real

            // dataGridView1.Columns[1].CellTemplate.ValueType = typeof (DateTime);
          //  dataGridView1.Columns[1].ValueType = typeof(DateTime);
            // dataGridView1.Columns[1].DefaultCellStyle.Format = "yyyy";
          //  dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
          //  dataGridView1.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
          //  dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            /*
             * XmlDocument doc = new XmlDocument();
                doc.Load(Server.MapPath("Orders.xml"));
                XmlNodeReader reader = new XmlNodeReader(doc);
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                reader.Close();
             */
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
                _dataSet.ReadXml(FilePath);
                dataGridView1.DataSource = new BindingSource(_dataSet, "Clientes");


               // dataGridView1.Columns["Valor"].ValueType = typeof(decimal);
               // dataGridView1.Columns["ValorPago"].ValueType = typeof(decimal);
                //VISUAL
                dataGridView1.Columns["Data"].ValueType = typeof(DateTime);
                dataGridView1.Columns["Data"].DefaultCellStyle.Format = "d";

                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
                //Descrição
                dataGridView1.Columns["Descrição"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.Columns["Descrição"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

            HighlightGrid();

            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[0];
                dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].Selected = true;
            }
        }

        #region Botoes

        private void btnCarregarGrid_Click(object sender, EventArgs e)
        {
            FilePath = CRegistros.GetOneDriveFolder() + "\\Suporte\\controledepagamentos.xml";

            if (!File.Exists(FilePath))
            {
                Close();
                return;
            }
            LoadDataGrid();
            btnCarregarGrid.Enabled = false;
            /*
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                tbxLocalXML.Text = Path.GetFullPath(openFile.FileName);
                if (!openFile.FileName.Contains("controledepagamentos"))
                    return;
            }

            if (string.IsNullOrEmpty(tbxLocalXML.Text))
                return;
            LoadDataGrid();
              */
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Gravar();
            MessageBox.Show(@"Gravado com Sucesso.");
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            DateTime combined = cUtils.DCombine(dtpData.Value, DateTime.Now);
            DataRow drNewRow = _dataSet.Tables[0].NewRow();

            //treat input values for money

            drNewRow["Cliente"] = tbxCliente.Text;
            drNewRow["Data"] = combined.ToString("s");
            drNewRow["Tipo"] = cbxTipo.SelectedItem;
            drNewRow["Valor"] = tbxValor.Text;
            drNewRow["ValorPago"] = tbxValorPago.Text;
            drNewRow["PC"] = tbxPC.Text;
            drNewRow["Status"] = cbxStatus.SelectedItem;
            drNewRow["Descrição"] = tbxServico.Text.TrimEnd();
            drNewRow["Ano"] = cbxAno.SelectedItem;
            _dataSet.Tables[0].Rows.Add(drNewRow);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            Index = dr.Index;
            tbxCliente.Text = dr.Cells[0].Value.ToString();
            dtpData.Text = dr.Cells[1].Value.ToString();
            cbxTipo.SelectedItem = dr.Cells[2].Value.ToString();
            tbxValor.Text = dr.Cells[3].Value.ToString();
            tbxValorPago.Text = dr.Cells[4].Value.ToString();
            tbxPC.Text = dr.Cells[5].Value.ToString();
            cbxStatus.SelectedItem = dr.Cells[6].Value.ToString();
            tbxServico.Text = dr.Cells[7].Value.ToString();
            cbxAno.SelectedItem = dr.Cells[8].Value.ToString();

            //updateValorRestante
            if (tbxValor.Text != "")
            {
                if (tbxValorPago.Text != "")
                {
                    var valorescalc = Convert.ToDecimal(tbxValor.Text) - Convert.ToDecimal(tbxValorPago.Text);
                    tbxValorRestante.Text = valorescalc.ToString("C2");
                }
                
            
        }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (tbxCliente.Text == "")
                return;

            DateTime combined = cUtils.DCombine(dtpData.Value, DateTime.Now);

            dataGridView1.Rows[Index].SetValues(tbxCliente.Text, combined.ToString("s"), cbxTipo.SelectedItem, tbxValor.Text,tbxValorPago.Text, tbxPC.Text, cbxStatus.SelectedItem, tbxServico.Text.TrimEnd(), cbxAno.SelectedItem);
            MessageBox.Show(@"Valores Atualizados.");
        }
        
        #endregion

        private void btnConverter_Click(object sender, EventArgs e)
        {
            //_dataSet.Clear();
            //_dataSet.ReadXml(tbxLocalXML.Text);//<-- carrega do diretorio selecionado
            //dataGridView1.DataSource = _dataSet;
            //dataGridView1.DataMember = "Clientes";//-> Busca dentro do ds o Datamember real
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    object value = row.Cells[1].Value;
            //    if (value == null) continue;
            //    string s = XmlConvert.ToString(DateTime.Parse(value.ToString()), "UTC");
            //    MessageBox.Show(DateTime.Parse(value.ToString()).ToString(formatString));
            //    MessageBox.Show(XmlConvert.ToDateTime(value.ToString(), "o").ToString());
            //    MessageBox.Show(DateTime.Parse(value.ToString()).ToUniversalTime().ToString("s"));
            //    dataGridView1.Rows[row.Index].Cells[1].Value = DateTime.Parse(value.ToString()).ToUniversalTime().ToString("s");
            //}
          //  Gravar();

            //CONVERTER 2 extrair data do value e recriar campo ANO
            _dataSet.Clear(); //Limpa para atualizar
            _dataTable.Reset();
            _dataTable.Columns.Add(new DataColumn("Cliente", typeof(string)));
            _dataTable.Columns.Add(new DataColumn("Data", typeof(DateTime)));
            _dataTable.Columns.Add(new DataColumn("Tipo", typeof(string)));
            _dataTable.Columns.Add(new DataColumn("Valor", typeof(string)));
            _dataTable.Columns.Add(new DataColumn("PC", typeof(string)));
            _dataTable.Columns.Add(new DataColumn("Status", typeof(string)));
            _dataTable.Columns.Add(new DataColumn("Descrição", typeof(string)));
            _dataTable.Columns.Add(new DataColumn("Ano", typeof(string)));
            _dataSet.Tables.Add(_dataTable);
            _dataSet.ReadXml(FilePath);
            dataGridView1.DataSource = new BindingSource(_dataSet, "Clientes");

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                object value = row.Cells[1].Value;
                if (value == null) continue;
                //MessageBox.Show(DateTime.Parse(value.ToString()).ToUniversalTime().ToString("yyyy"));
                dataGridView1.Rows[row.Index].Cells[7].Value = DateTime.Parse(value.ToString()).ToUniversalTime().ToString("yyyy");
            }

            Gravar();
        }

        private void tbxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Double value;//("{0:#,##0.00}", 
                tbxValor.Text = Double.TryParse(tbxValor.Text, out value) ? String.Format(CultureInfo.CurrentCulture, "{0:##0.00}", value) : String.Empty;
            }
        }

        private void frmAdmPag_Load(object sender, EventArgs e)
        {
            cbxAno.Items.Add(DateTime.Now.Year);
            cbxAno.SelectedIndex = 0;
        }

        private void frmControledePag_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            ScrollDown();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
