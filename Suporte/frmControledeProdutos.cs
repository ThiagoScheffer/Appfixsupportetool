using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmControledeProdutos : Form
    {
        private string _fileControle;
        private readonly DataSet _dsSet = new DataSet();
        private readonly DataTable _dataTable = new DataTable("Produto");
        private int RowIndex = 0;
        private DataView dvView = new DataView();
        public frmControledeProdutos()
        {
            InitializeComponent();
        }
        #region FORM

        private void frmControledeEstoque_Load(object sender, EventArgs e)
        {
            try
            {
                _fileControle = CRegistros.GetOneDriveFolder() + "\\Suporte\\ControledeProdutos.xml";

                if (!File.Exists(_fileControle))
                {
                    Close();
                }
                LoadEstoque();
            }
            catch (Exception)
            {
                
                //ignore
            }

            
        }

        private void tbxViewSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterEstoque(tbxViewSN.Text, "SN");
            }
        }
        #endregion

        #region Controle Editar

        private void ControleEditDestaque()
        {
            foreach (DataGridViewRow row in dgvEditControle.Rows)
            {
                object value = row.Cells[3].Value;
                if (value == null || value.ToString() == "") continue;
                //Mes da venda tem que ser Menor ou igual a 3 = 3Meses apos avenda
                //  MESDATAVENDA - MESATUAL <= 3
                DateTime VendaData = Convert.ToDateTime(row.Cells[3].Value.ToString());
                if (Math.Abs(VendaData.Month - DateTime.Now.Month) <= 3)
                {
                        row.DefaultCellStyle.BackColor = Color.DarkOrange;
                }
            }
        }

        private void btnAbrirEstoque_Click(object sender, EventArgs e)
        {
            _dsSet.Clear();
            _dsSet.ReadXml(_fileControle);
            dgvEditControle.DataSource = _dsSet;
            dgvEditControle.DataMember = "Produto";

            //Ajustes na interface
            dgvEditControle.Columns[0].HeaderCell.Value = "Cliente";
            dgvEditControle.Columns[1].HeaderCell.Value = "Nota de Compra";
            dgvEditControle.Columns[2].HeaderCell.Value = "Nota de Venda";
            dgvEditControle.Columns[3].HeaderCell.Value = "Data da Venda";
            dgvEditControle.Columns[3].ValueType = typeof(DateTime);//Tipo DATA

            //dgvEditControle.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEditControle.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvEditControle.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //SCROLL
            dgvEditControle.FirstDisplayedScrollingRowIndex = dgvControle.RowCount - 1;

            btnAdicionar.Enabled = true;
            btnAtualizar.Enabled = true;
            btnSalvar.Enabled = true;

        }

        private void dgvEditEstoque_MouseClick(object sender, MouseEventArgs e)
        {
            btnAtualizar.Enabled = true;
            tbxNNVenda.Enabled = true;

            DataGridViewRow dr = dgvEditControle.SelectedRows[0];
            RowIndex = dr.Index;//Idx para salvar a alteração no Row selecionado
            tbxNomeCliente.Text = dr.Cells[0].Value.ToString();
            tbxNNCompra.Text = dr.Cells[1].Value.ToString();
            tbxNNVenda.Text = dr.Cells[2].Value.ToString();
            object value = dr.Cells[3].Value;
            if (value != null)
            {
                dtpDataVenda.Value = Convert.ToDateTime(value.ToString());
            }
            tbxDesc.Text = dr.Cells[4].Value.ToString();
            tbxSN.Text = dr.Cells[5].Value.ToString();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Atualiza ambos os Grids
            dgvEditControle.Update();
            dgvControle.Update();
            
            //Salvar
            _dsSet.AcceptChanges();
            _dsSet.WriteXml(_fileControle);
            //Atualiza os Destaques
            ControleViewHightlight();
            ControleEditDestaque();
            MessageBox.Show(@"Arquivo Salvo !");
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            DataRow drNewRow = _dsSet.Tables[0].NewRow();
            drNewRow[0] = tbxNomeCliente.Text;
            drNewRow[1] = tbxNNCompra.Text;
            drNewRow[2] = tbxNNVenda.Text;
            drNewRow[3] = dtpDataVenda.Value;
            drNewRow[4] = tbxDesc.Text;
            drNewRow[5] = tbxSN.Text;

            _dsSet.Tables[0].Rows.Add(drNewRow);
            dgvEditControle.Update();
            dgvControle.Update();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (tbxNomeCliente.Text == "")
                return;
            dgvEditControle.Rows[RowIndex].SetValues(tbxNomeCliente.Text, tbxNNCompra.Text, tbxNNVenda.Text,dtpDataVenda.Value , tbxDesc.Text, tbxSN.Text);
            MessageBox.Show(@"Valores Atualizados.");
        }
        #endregion

        #region Controle View

        //DESTACAR PRODUTO EM GARANTIA
        private void ControleViewHightlight()
        {
            foreach (DataGridViewRow row in dgvControle.Rows)
            {
                object value = row.Cells[3].Value;
                if (value == null || value.ToString() == "") continue;
                //Mes da venda tem que ser Menor ou igual a 3 = 3Meses apos avenda
                //  MESDATAVENDA - MESATUAL <= 3
                //TODO Verificar redundancia de data-ano
                DateTime VendaData = Convert.ToDateTime(row.Cells[3].Value.ToString());
                if (Math.Abs(VendaData.Month - DateTime.Now.Month) <= 3)
                {
                    row.DefaultCellStyle.BackColor = Color.DarkOrange;
                }
            }
        }
        private void LoadEstoque()
        {
            //Limpar
            _dsSet.Clear();
            _dataTable.Reset();
            //Criar Colunas
            _dataTable.Columns.Add(new DataColumn("Nome_Cliente", typeof(string)));
            _dataTable.Columns.Add(new DataColumn("Num_Nota_Compra", typeof(string)));
            _dataTable.Columns.Add(new DataColumn("Num_Nota_Venda", typeof(string)));
            _dataTable.Columns.Add(new DataColumn("Data_Venda", typeof(string)));
            _dataTable.Columns.Add(new DataColumn("Descrição", typeof(string)));
            _dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
            //Carregar
            _dsSet.Tables.Add(_dataTable);
            _dsSet.ReadXml(_fileControle);
            dgvControle.DataSource = new BindingSource(_dsSet, "Produto");
            //Ajustes na interface
            dgvControle.Columns[0].HeaderCell.Value = "Cliente";
            dgvControle.Columns[1].HeaderCell.Value = "Nota de Compra";
            dgvControle.Columns[2].HeaderCell.Value = "Nota de Venda";
            dgvControle.Columns[3].HeaderCell.Value = "Data da Venda";
            dgvControle.Columns[3].ValueType = typeof(DateTime);//Tipo DATA

          //  dgvControle.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvControle.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvControle.FirstDisplayedScrollingRowIndex = dgvControle.RowCount - 1;

            ControleViewHightlight();
        }

        private void tbxNNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterEstoque(tbxViewNNota.Text, "Num_Nota_Venda");
            }
        }

        private void FilterEstoque(string search,string field)
        {
            //dvView.Table = dsSet.Tables[0];
            dvView = _dsSet.Tables[0].DefaultView;
            if (tbxViewNNota.Text != string.Empty)
            {
                dvView.RowFilter = field + "='" + search + "'";
                dvView.Sort = field;
            } else
            if (tbxViewSN.Text != string.Empty)
            {
                dvView.RowFilter = field + "='" + search + "'";
                dvView.Sort = field;
            }
            else
            {
                dvView.RowFilter = "";
            }

            dgvControle.DataSource = dvView;
            dgvControle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvControle.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvControle.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvControle.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ControleViewHightlight();

            if(dgvControle.RowCount != 0)
            dgvControle.FirstDisplayedScrollingRowIndex = dgvControle.RowCount - 1;
        }
        #endregion


    }
}
