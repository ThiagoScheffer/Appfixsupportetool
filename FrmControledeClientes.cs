using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Suporte
{
    public partial class FrmControledeClientes : Form
    {
        private readonly DataSet _dsCadastro = new DataSet();
        private string _fileCadClientes = "";
        private int _selectedRow;

        public FrmControledeClientes()
        {
            InitializeComponent();
        }


        private static string ToFirstLettertoCap(string text)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text);

            //textBox1.Text = textInfo.ToTitleCase(textBox1.Text);
        }

        #region CadClientes

        private void LoadDatagridCadastro()
        {
            if (!File.Exists(_fileCadClientes))
                return;
            _dsCadastro.Clear();
            _dsCadastro.ReadXml(_fileCadClientes);//<-- carrega do diretorio selecionado
            dgvCadCliente.DataSource = _dsCadastro;
            dgvCadCliente.DataMember = "CPFkey";//-> Busca dentro do ds o Datamember real
            dgvCadCliente.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCadCliente.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvCadCliente.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCadCliente.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvCadCliente.FirstDisplayedScrollingRowIndex = dgvCadCliente.RowCount - 1;

        }

        private void btnCadNovo_Click(object sender, EventArgs e)
        {
            tbxCadCPF.Clear();
            tbxCadCPF.ResetText();
            tbxCadEmail.Clear();
            tbxCadEnd.Clear();
            tbxCadNome.Clear();
            tbxCadTel.Clear();
            tbxCadNome.Focus();
        }

        private void dgvCadCliente_MouseClick(object sender, MouseEventArgs e)
        {
            if (!grpCad.Enabled)
                return;

            DataGridViewRow dr = dgvCadCliente.SelectedRows[0];
            _selectedRow = dr.Index;
            cbxCadTpCliente.SelectedItem = dr.Cells[0].Value.ToString();
            tbxCadNome.Text = dr.Cells[1].Value.ToString();
            tbxCadEmail.Text = dr.Cells[2].Value.ToString();
            tbxCadEnd.Text = dr.Cells[3].Value.ToString();
            tbxCadTel.Text = dr.Cells[4].Value.ToString();
            //FIX CPF
            tbxCadCPF.Mask = dr.Cells[0].Value.ToString() != "Residencial" ? "00,000,000/0000-00" : "000,000,000-00";
            tbxCadCPF.Text = dr.Cells[5].Value.ToString();
        }

        private void btnCadAdd_Click(object sender, EventArgs e)
        {
            if (tbxCadNome.Text == "" || cbxCadTpCliente.SelectedItem == null)
            {
                MessageBox.Show("Um campo está faltando !");
                return;
            }
            DataRow drNewRow = _dsCadastro.Tables[0].NewRow();
            drNewRow[0] = cbxCadTpCliente.SelectedItem.ToString();//Tipo de Cliente
            drNewRow[1] = ToFirstLettertoCap(tbxCadNome.Text);
            drNewRow[2] = tbxCadEmail.Text;
            drNewRow[3] = tbxCadEnd.Text;
            drNewRow[4] = tbxCadTel.Text;
            drNewRow[5] = tbxCadCPF.Text;

            _dsCadastro.Tables[0].Rows.Add(drNewRow);
            MessageBox.Show("Cadastrado !");
        }

        private void btnCadSalvar_Click(object sender, EventArgs e)
        {
            dgvCadCliente.Update();
            _dsCadastro.AcceptChanges();
            _dsCadastro.WriteXml(_fileCadClientes);
            MessageBox.Show("Alterações salvas no arquivo !");
            // LoadDatagridCadastro();
        }

        private void btnCadAplicar_Click(object sender, EventArgs e)
        {
            if (tbxCadNome.Text == "")
                return;

            dgvCadCliente.Rows[_selectedRow].SetValues(cbxCadTpCliente.SelectedItem, tbxCadNome.Text, tbxCadEmail.Text, tbxCadEnd.Text, tbxCadTel.Text, tbxCadCPF.Text);
            // dgvEdit.EndEdit();
            //dgvEdit.Refresh();
            MessageBox.Show("Valores Atualizados.");
        }

        private void cbxTpCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbxCadCPF.Mask = cbxCadTpCliente.SelectedItem.ToString() != "Residencial" ? "00,000,000/0000-00" : "000,000,000-00";
        }
        #endregion

        private void FrmControledeClientes_Load(object sender, EventArgs e)
        {
            try
            {
                _fileCadClientes = CRegistros.GetOneDriveFolder() + "\\Suporte\\CadastrodeClientes.xml";

                grpCad.Enabled = true;
                dgvCadCliente.Enabled = true;
                LoadDatagridCadastro();
            }
            catch (Exception)
            {
                
                //ignore
            }
            
        }

    }
}
