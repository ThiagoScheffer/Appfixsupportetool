using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmControledeEstoque : Form
    {
        private string _fileEstoque;
        private DataSet dsSet = new DataSet();
        private int RowIndex = 0;
        private DataView dvView = new DataView();
        public frmControledeEstoque()
        {
            InitializeComponent();
        }
        #region FORM

        private void frmControledeEstoque_Load(object sender, EventArgs e)
        {
            try
            {
                _fileEstoque = CRegistros.GetOneDriveFolder() + "\\Suporte\\ControledeEstoque.xml";

                if (!File.Exists(_fileEstoque))
                {
                    Close();
                }
                cbxFiltroTipo.SelectedIndex = 0;
                LoadEstoque();
            }
            catch (Exception)
            {
                // ignored
            }
        } 
        #endregion

        #region Estoque Editar

        private void EstoqueEditDestaque()
        {
            foreach (DataGridViewRow row in dgvEditEstoque.Rows)
            {
                object value = row.Cells[7].Value;//Aviso: null = ignorar
                if (value == null || value.ToString() == "") continue;
                if (row.Cells[0].Value.ToString() == "Produto")
                {
                    if (Convert.ToInt32(row.Cells[5].Value) <= Convert.ToInt32(value))//Quantidade Menor= que Aviso
                        row.DefaultCellStyle.BackColor = Color.DarkOrange;
                }
                else
                {
                    object o = row.Cells[6].Value;
                    if (o == null || o.ToString() == "") continue;
                    if (Convert.ToInt32(o) <= Convert.ToInt32(value))//Restante <= Aviso
                        row.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }
        private void btnAbrirEstoque_Click(object sender, EventArgs e)
        {
            dsSet.Clear();
            dsSet.ReadXml(_fileEstoque);
            dgvEditEstoque.DataSource = dsSet;
            dgvEditEstoque.DataMember = "Produto";
            dgvEditEstoque.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvEditEstoque.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            EstoqueEditDestaque();
            btnAdicionar.Enabled = true;
            btnAtualizar.Enabled = true;
            btnSalvar.Enabled = true;

        }
        private void tbxValor_Leave(object sender, EventArgs e)
        {
            Double value;//("{0:#,##0.00}", 
            tbxValor.Text = Double.TryParse(tbxValor.Text, out value) ? String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:##0.00}", value) : String.Empty;
        }
        private void dgvEditEstoque_MouseClick(object sender, MouseEventArgs e)
        {
            btnAtualizar.Enabled = true;
            tbxRest.Enabled = true;

            DataGridViewRow dr = dgvEditEstoque.SelectedRows[0];
            RowIndex = dr.Index;//Idx para salvar a alteração no Row selecionado
            cbxTipo.SelectedItem = dr.Cells[0].Value.ToString();
            cbxCat.SelectedItem = dr.Cells[1].Value.ToString();
            cbxMarca.SelectedItem = dr.Cells[2].Value.ToString();
            tbxDesc.Text = dr.Cells[3].Value.ToString();
            tbxValor.Text = dr.Cells[4].Value.ToString();
            tbxQtd.Text = dr.Cells[5].Value.ToString();
            tbxRest.Text = dr.Cells[6].Value.ToString();
            tbxAvisar.Text = dr.Cells[7].Value.ToString();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            dgvEditEstoque.Update();
            dgvEstoque.Update();
            dsSet.AcceptChanges();
            dsSet.WriteXml(_fileEstoque);
            EstoqueViewHightlight();
            EstoqueEditDestaque();
            MessageBox.Show(@"Arquivo Salvo !");
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            DataRow drNewRow = dsSet.Tables[0].NewRow();
            drNewRow[0] = cbxTipo.SelectedItem;
            drNewRow[1] = cbxCat.SelectedItem;
            drNewRow[2] = cbxMarca.SelectedItem;
            drNewRow[3] = tbxDesc.Text;
            drNewRow[4] = tbxValor.Text;
            drNewRow[5] = tbxQtd.Text;
            if(cbxTipo.SelectedItem.ToString() == "Produto")
            drNewRow[6] = "";
            else
            drNewRow[6] = tbxRest.Text;
            drNewRow[7] = tbxAvisar.Text;
            dsSet.Tables[0].Rows.Add(drNewRow);
            dgvEditEstoque.Update();
            dgvEstoque.Update();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (tbxDesc.Text == "")
                return;
            dgvEditEstoque.Rows[RowIndex].SetValues(cbxTipo.SelectedItem, cbxCat.SelectedItem, cbxMarca.SelectedItem, tbxDesc.Text, tbxValor.Text, tbxQtd.Text, tbxRest.Text, tbxAvisar.Text);
            MessageBox.Show(@"Valores Atualizados.");
        }
        #endregion

        #region Estoque View

        private void EstoqueViewHightlight()
        {
            foreach (DataGridViewRow row in dgvEstoque.Rows)
            {
                object value = row.Cells[7].Value;//Aviso: null = ignorar
                if (value == null || value.ToString() == "") continue;

                if (row.Cells[0].Value.ToString() == "Produto")
                {
                    if (Convert.ToInt32(row.Cells[5].Value) <= Convert.ToInt32(value))//Quantidade Menor= que Aviso
                        row.DefaultCellStyle.BackColor = Color.DarkOrange;
                }
                else
                {
                    object o = row.Cells[6].Value;
                    if (o == null || o.ToString() == "") continue;
                    if (Convert.ToInt32(o) <= Convert.ToInt32(value))//Restante <= Aviso
                        row.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }
        private void LoadEstoque()
        {
            dsSet.Clear();
            dsSet.ReadXml(_fileEstoque);
            dgvEstoque.DataSource = dsSet;
            dgvEstoque.DataMember = "Produto";
            dgvEstoque.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvEstoque.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEstoque.FirstDisplayedScrollingRowIndex = dgvEstoque.RowCount - 1;
            EstoqueViewHightlight();
        }

        private void cbxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbxRest.Enabled = cbxTipo.SelectedItem.ToString() != "Produto";
        }

        private void cbxFiltroTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterEstoque();
        }

        private void FilterEstoque()
        {
            //dvView.Table = dsSet.Tables[0];
            dvView = dsSet.Tables[0].DefaultView;
            if (cbxFiltroTipo.SelectedItem.ToString() != "Todos")
            {
                dvView.RowFilter = "Tipo='" + cbxFiltroTipo.SelectedItem + "'";
                dvView.Sort = "Tipo";
            }
            else
            {
                dvView.RowFilter = "";
            }

            dgvEstoque.DataSource = dvView;
            dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvEstoque.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvEstoque.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvEstoque.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEstoque.FirstDisplayedScrollingRowIndex = dgvEstoque.RowCount - 1;
            EstoqueViewHightlight();
        } 
        #endregion
    }
}
