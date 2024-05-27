using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmControledeServicos : Form
    {
        private readonly DataSet _dsServ = new DataSet();
        private readonly DataSet _dsSituacao = new DataSet();
        private readonly DataSet _dsCadastro = new DataSet();
        private readonly DataTable _dtSituacao = new DataTable("Clientes");
        private readonly AutoCompleteStringCollection _autoCompleteString = new AutoCompleteStringCollection();
        private int _selectedRow;
        private string _status = "Todos";
        private string _tipo = "Todos";
        private string _cpf = "";
        private string _dataNull = null;
        private string _fileControle = "";// @"C:\Users\Public\Downloads\ControledeClientes.xml";
        private string _fileCadClientes = "";
        private string _fileSituacao = "";
        public frmControledeServicos()
        {
            InitializeComponent();
        }

        private void LoadPath()
        {
            _fileControle = CRegistros.GetOneDriveFolder() + "\\Suporte\\ControledeServicos.xml";
            _fileSituacao = CRegistros.GetOneDriveFolder() + "\\Suporte\\ControledeSituacao.xml";
            _fileCadClientes = CRegistros.GetOneDriveFolder() + "\\Suporte\\CadastrodeClientes.xml";


            if (!File.Exists(_fileControle))
            {
                Close();
            }
        }

        #region Load GRIDVIEW
        private void GridViewHightlight()
        {
            //Concluído e Pago
            foreach (DataGridViewRow row in dgvListaServ.Rows)
            {
                _autoCompleteString.Add(row.Cells[2].Value.ToString());
                if (row.Cells[5].Value.ToString() == "Concluído" || row.Cells[5].Value.ToString() == "Concluído e Pago") continue;
                row.DefaultCellStyle.BackColor = Color.DarkOrange;
            }
            tbxNome.AutoCompleteCustomSource = _autoCompleteString;
            dgvListaServ.AutoResizeRows();
        }

        private void LoadDataGridServicos()//GRID DE VISAO APENAS
        {
            _dsServ.Clear(); //Limpa para atualizar
            try
            {
                _dsServ.ReadXml(_fileControle);
            }
            catch (Exception)
            {
                MessageBox.Show("Nao ha registros!");
                return;
            }
            dgvListaServ.DataSource = _dsServ;
            dgvListaServ.DataMember = "CPFkey";
            DataView dvView = new DataView(_dsServ.Tables[0]);

            if (_status == "Todos" && _tipo == "Todos")
            {
                dvView.EndInit();
            }
            else if (_status == "Todos" && _tipo != "Todos") //Tipo
            {
                dvView.RowFilter = "Tipo LIKE '" + _tipo + "'";
            }
            else if (_status != "Todos" && _tipo == "Todos") //Mes
            {
                dvView.RowFilter = "Status LIKE '" + _status + "'";
            }
            else if (_status != "Todos" && _tipo != "Todos")
            {
                dvView.RowFilter = "Tipo LIKE '" + _tipo + "' AND Status LIKE '" + _status + "'";
            }
            if (!string.IsNullOrEmpty(_cpf))
                dvView.RowFilter = "[CPF-CNPJ] = '" + _cpf + "'";

            dgvListaServ.DataSource = dvView;


            //Autoscroll ate  fim
            try
            {
                dgvListaServ.FirstDisplayedScrollingRowIndex = dgvListaServ.RowCount - 1;
            }
            catch (Exception)
            {}
            

            //Visual

            dgvListaServ.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvListaServ.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvListaServ.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            GridViewHightlight();
            //Autoscroll ate  fim
            dgvListaServ.FirstDisplayedScrollingRowIndex = dgvListaServ.RowCount - 1;
        }
        private void cbxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string TipoSelecionado = cbxViewTipo.SelectedItem.ToString();
            _tipo = TipoSelecionado;
            LoadDataGridServicos();
        }
        private void cbxMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string MesSelecionado = cbxViewStatus.SelectedItem.ToString();
            _status = MesSelecionado;
            LoadDataGridServicos();
        }
        #endregion

        #region Editar
        private void ShowGarantia()
        {
            DateTime Data;
            foreach (DataGridViewRow row in dgvEditServ.Rows)
            {
                string value = row.Cells[1].Value.ToString();
                if (string.IsNullOrEmpty(value)) continue;
                if (row.Cells[5].Value.ToString() != "Concluído e Pago") continue;
                Data = Convert.ToDateTime(row.Cells[1].Value.ToString());
                if (Data >= DateTime.Now.AddDays(-8))
                    row.DefaultCellStyle.BackColor = Color.DarkOrange;
            }
        }
        private void GridEditarHighlight()
        {
            //Concluído e Pago
            foreach (DataGridViewRow row in dgvEditServ.Rows)
            {
               // _autoCompleteString.Add(row.Cells[2].Value.ToString());
                if (row.Cells[5].Value.ToString() == "Concluído" || row.Cells[5].Value.ToString() == "Concluído e Pago") continue;
                row.DefaultCellStyle.BackColor = Color.DarkOrange;
            }
        }

        private void LoadDataGridEdit()
        {
            if (!File.Exists(_fileControle))
                return;
            _dsServ.Clear();
            _dsServ.ReadXml(_fileControle);//<-- carrega do diretorio selecionado
            dgvEditServ.DataSource = _dsServ;
            dgvEditServ.DataMember = "CPFkey";//-> Busca dentro do ds o Datamember real

            //visual
            dgvEditServ.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvEditServ.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //obs 
            dgvEditServ.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvEditServ.FirstDisplayedScrollingRowIndex = dgvEditServ.RowCount - 1;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            LoadDataGridEdit();
            gbxCadastro.Enabled = true;
            FeedClientList();
            GridEditarHighlight();
            //Autoscroll ate  fim
            dgvEditServ.FirstDisplayedScrollingRowIndex = dgvEditServ.RowCount - 1;

            //Abre em modo de edição o controle de Situações
            OpenSituacaoDataBase();
        }

        private string ToFirstLettertoCap(string text)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text);

            //textBox1.Text = textInfo.ToTitleCase(textBox1.Text);
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (tbxNome.Text == "" || cbxStatus.SelectedItem == null || cbxTipo.SelectedItem == null)
            {
                MessageBox.Show("Um campo está faltando !");
                return;
            }
            DataRow drNewRow = _dsServ.Tables[0].NewRow();
            drNewRow[0] = dtpDataEntrada.Text;
            if (cbxStatus.SelectedItem.ToString() == "Concluído")
            {
                drNewRow[1] = dtpDataSaida.Text;
            }
            else
            {
                drNewRow[1] = null;
            }
            drNewRow[2] = ToFirstLettertoCap(tbxNome.Text);
            drNewRow[3] = cbxTipo.SelectedItem;
            drNewRow[4] = cbxServico.SelectedItem;
            drNewRow[5] = cbxStatus.SelectedItem;
            drNewRow[6] = tbxRelatorio.Text;
            drNewRow[7] = tbxValor.Text;
            drNewRow[8] = tbxCPF.Text;
            _dsServ.Tables[0].Rows.Add(drNewRow);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            dgvEditServ.Update();
            _dsServ.AcceptChanges();
            _dsServ.WriteXml(_fileControle);
            _dsSituacao.AcceptChanges();
            _dsSituacao.WriteXml(_fileSituacao);
            dgvEditServ.Refresh();
            MessageBox.Show("Alterações salvas no arquivo !");
            
            LoadDataGridServicos();
        }

        private void tbxValor_Leave(object sender, EventArgs e)
        {
            Double value;//("{0:#,##0.00}", 
            tbxValor.Text = Double.TryParse(tbxValor.Text, out value) ? String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:##0.00}", value) : String.Empty;
        }

        //FIX CPF CNPJ
        private void cbxTipo_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            tbxCPF.Mask = cbxTipo.SelectedItem.ToString() != "Residencial" ? "00,000,000/0000-00" : "000,000,000-00";
        }

        private void cbxStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxStatus.SelectedItem.ToString() == "Concluído" ||
                cbxStatus.SelectedItem.ToString() == "Concluído e Pago")
            {
                dtpDataSaida.Enabled = true;
            }
            else
                dtpDataSaida.Enabled = false;
        }

        private void btnShowGarantia_Click(object sender, EventArgs e)
        {
            ShowGarantia();
        }

        private void dgvEdit_MouseClick(object sender, MouseEventArgs e)
        {
            if (!gbxCadastro.Enabled)
                return;
            btnAtualizar.Enabled = true;//Ativa botao de atualizar.

            DataGridViewRow dr = dgvEditServ.SelectedRows[0];
            _selectedRow = dr.Index;
            dtpDataEntrada.Text = dr.Cells[0].Value.ToString();
            //FIX DATE
            if (!string.IsNullOrEmpty(dr.Cells[1].Value.ToString()))//Se nao estiver vazio preenche o campo data.
            {
                dtpDataSaida.Enabled = true;
                dtpDataSaida.Text = dr.Cells[1].Value.ToString();
                _dataNull = dtpDataSaida.Text;
            }
            else
            {
                _dataNull = null;
                dtpDataSaida.Enabled = false;
            }
            tbxNome.Text = dr.Cells[2].Value.ToString();
            cbxTipo.SelectedItem = dr.Cells[3].Value.ToString();
            cbxServico.SelectedItem = dr.Cells[4].Value.ToString();
            cbxStatus.SelectedItem = dr.Cells[5].Value.ToString();
            tbxRelatorio.Text = dr.Cells[6].Value.ToString();
            tbxValor.Text = dr.Cells[7].Value.ToString();
            //FIX CPF
            tbxCPF.Mask = dr.Cells[3].Value.ToString() != "Residencial" ? "00,000,000/0000-00" : "000,000,000-00";
            tbxCPF.Text = dr.Cells[8].Value.ToString();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (tbxNome.Text == "") return;
            
            if (dtpDataSaida.Enabled) _dataNull = dtpDataSaida.Text;

            //Alterar apenas Datagrid servicos
            dgvEditServ.Rows[_selectedRow].SetValues(dtpDataEntrada.Text, _dataNull, tbxNome.Text,cbxTipo.SelectedItem, cbxServico.SelectedItem, cbxStatus.SelectedItem, tbxRelatorio.Text, tbxValor.Text, tbxCPF.Text);


            if (cbxStatus.SelectedItem.ToString() == "Concluído e Pago")
            {
                RemoveSituacao();
            }
            else
            {
                //Situação update.
                AplicarAteracoesSituacao();
            }
        }

        private void FeedClientList()//Lista Clientes AutoComplete
        {
            if (!File.Exists(_fileCadClientes))
                return;
            _dsCadastro.Clear();
            _dsCadastro.ReadXml(_fileCadClientes);//<-- carrega do diretorio selecionado
            var clientesCollection = new AutoCompleteStringCollection();
            foreach (DataRow row in _dsCadastro.Tables["CPFkey"].Rows)
            {
                if (row.ItemArray[1] != null)
                {
                    clientesCollection.Add(row.ItemArray[1].ToString());
                }
            }
            tbxNome.AutoCompleteCustomSource = clientesCollection;
            tbxNome.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbxNome.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void AutoCompleteFields()
        {
            if (!File.Exists(_fileCadClientes))
                return;
            _dsCadastro.Clear();
            _dsCadastro.ReadXml(_fileCadClientes);//<-- carrega do diretorio selecionado
            foreach (DataRow row in _dsCadastro.Tables["CPFkey"].Rows)
            {
                if (row.ItemArray[1].ToString().Contains(tbxNome.Text))
                {
                    cbxTipo.SelectedItem = row.ItemArray[0].ToString();
                    tbxCPF.Text = row.ItemArray[5].ToString();
                }
            }
        }
        #endregion
        
        //FORM LOAD
        private void frmClientControl_Load(object sender, EventArgs e)
        {
            //Carrega os diretórios do XML
            LoadPath();

            cbxViewTipo.SelectedIndex = 0;
            cbxViewStatus.SelectedIndex = 0;
            LoadDataGridServicos();
        }

        private void btnSearchcpf_Click(object sender, EventArgs e)
        {
            if (tbxSearchCPF.Text.Contains(" "))
                _cpf = tbxSearchCNPJ.Text;
            if (tbxSearchCNPJ.Text.Contains(" "))
                _cpf = tbxSearchCPF.Text;

            if (_cpf.Contains(" "))
                return;

            LoadDataGridServicos();
            _cpf = "";
        }

        private void tbxNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AutoCompleteFields();
            }
        }

        #region Controle de Situação

        private void btnAddSituação_Click(object sender, EventArgs e)
        {
            AddNovaSituacao();
        }

        private void OpenSituacaoDataBase()
        {
            //Adicionar situação tem que pegar os valores dos campos e adiciona-los na tabela situaçao
            _dsSituacao.Clear(); //Limpa para atualizar
            _dtSituacao.Reset();
            _dtSituacao.Columns.Add(new DataColumn("Cliente", typeof(string)));
            _dtSituacao.Columns.Add(new DataColumn("Data", typeof(DateTime)));
            _dtSituacao.Columns.Add(new DataColumn("Serviço", typeof(string)));
            _dtSituacao.Columns.Add(new DataColumn("Status", typeof(string)));
            _dsSituacao.Tables.Add(_dtSituacao);
            _dsSituacao.ReadXml(_fileSituacao);
        }

        private void RemoveSituacao()
        {
            try
            {
                //Remove o item exato que esta sendo atualizado para concluido e pago.
                foreach (DataRow row in _dsSituacao.Tables[0].Rows)
                {
                    if (row[@"Data"].ToString() != dtpDataEntrada.Value.ToString()) continue;

                    row.Delete();
                    break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            MessageBox.Show(@"Situação Removida.");
        }
        private void AddNovaSituacao()
        {
            try
            {
                //Gravar novo registro
                // string ClienteCadastrado = tbxClienteCadastrado.Text; // cRegistros.GetCliente();
                DataRow drNewRow = _dsSituacao.Tables[0].NewRow();
                drNewRow[0] = tbxNome.Text;
                //drNewRow[0] = tbxNome.Text;
                drNewRow[1] = dtpDataEntrada.Text;
                drNewRow[2] = tbxRelatorio.Text;
                drNewRow[3] = cbxStatus.SelectedItem;

                _dsSituacao.Tables[0].Rows.Add(drNewRow);
                _dsSituacao.AcceptChanges();
                _dsSituacao.WriteXml(_fileSituacao);
                MessageBox.Show(@"Situação Adicionada");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AplicarAteracoesSituacao()
        {
            try
            {
                foreach (DataRow row in _dsSituacao.Tables[0].Rows)
                {
                    if (row[@"Data"].ToString() != dtpDataEntrada.Value.ToString()) continue;
                    if (row[@"Cliente"].ToString() != tbxNome.Text) continue;

                    row[@"Serviço"] = cbxServico.SelectedItem + " : \n" + tbxRelatorio.Text;
                    row["Data"] = dtpDataEntrada.Text;
                    row["Status"] = cbxStatus.SelectedItem;
                }
            }
            catch (Exception)
            {
                throw;
            }
            MessageBox.Show(@"Situação Atualizada.");
        } 
        #endregion
    }
}