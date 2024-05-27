using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmControledeOrcamentos : Form
    {
        private readonly DataSet ds = new DataSet();
        private AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
        private int SelectedRow;
        private string Status = "Todos";
        private string Tipo = "Todos";
        private string Num = "";
        private string DataNull = null;
        private string OfflineFile = "";//@"C:\Temp\ControledeOrçamentos.xml";
       // private string EventosFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Eventos.xml";
        public frmControledeOrcamentos()
        {
            InitializeComponent(); 
        }

        #region Load GRID
        private void DataGridColor()
        {
            foreach (DataGridViewRow row in dgvPreview.Rows)
            {
                autoCompleteString.Add(row.Cells[2].Value.ToString());
                if (row.Cells[5].Value.ToString() != "Aguardando") continue;
                row.DefaultCellStyle.BackColor = Color.LightSalmon;
            }
            tbxNome.AutoCompleteCustomSource = autoCompleteString;
        }

        private void CleanDataGridExpired()
        {
            List<int> rowsToRemove = new List<int>();
            foreach (DataGridViewRow row in dgvEdit.Rows)
            {
                var value = row.Cells[1].Value;
                //if (value != null && value.ToString() == "00/00/0000") continue;
                if(value ==null) continue;
              //  if (row.Cells[5].Value.ToString() != "Aguardando") continue;
                if (DateTime.Today.AddDays(-8) > Convert.ToDateTime(row.Cells[1].Value.ToString()))
                    rowsToRemove.Add(row.Index);
                
            }
            if(rowsToRemove.Count == 0)
                return;
            foreach (var index in rowsToRemove.OrderByDescending(x=>x))
            {
                dgvEdit.Rows.RemoveAt(index);
            }
            dgvEdit.Refresh();
           // LoadDataGridEdit();
        }
        private void LoadDataGridEdit()
        {
            if(!File.Exists(OfflineFile))
                return;
            ds.Clear();
            ds.ReadXml(OfflineFile);//<-- carrega do diretorio selecionado
            dgvEdit.DataSource = ds;
            dgvEdit.DataMember = "Pkey";//-> Busca dentro do ds o Datamember real
             dgvEdit.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // dgvEdit.AutoResizeColumns();
        }

        private void LoadDataGridView()//GRID DE VISAO APENAS
        {
            ds.Clear(); //Limpa para atualizar
            try
            {
                ds.ReadXml(OfflineFile);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            dgvPreview.DataSource = ds;
            dgvPreview.DataMember = "Pkey";
            DataView dvView = new DataView(ds.Tables[0]);

            if (Status == "Todos" && Tipo == "Todos")
            {
                dvView.EndInit();
            }
            else if (Status == "Todos" && Tipo != "Todos") //Tipo
            {
                dvView.RowFilter = "Tipo LIKE '" + Tipo + "'";
            }
            else if (Status != "Todos" && Tipo == "Todos") //Mes
            {
                dvView.RowFilter = "Status LIKE '" + Status + "'";
            }
            else if (Status != "Todos" && Tipo != "Todos")
            {
                dvView.RowFilter = "Tipo LIKE '" + Tipo + "' AND Status LIKE '" + Status + "'";
            }

            if(!string.IsNullOrEmpty(Num))
            dvView.RowFilter = "Numero LIKE '" + tbxSearch.Text + "'";
            dgvPreview.DataSource = dvView;
            dgvPreview.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Data
            dgvPreview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //MEs
            dgvPreview.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //hora
            dgvPreview.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Tipo
            dgvPreview.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Contratante
            dgvPreview.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //descr 
            dgvPreview.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Status
            dgvPreview.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Status
            dgvPreview.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Status
            dgvPreview.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Status
            dgvPreview.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Status
            dgvPreview.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Status
            dgvPreview.Refresh();
            DataGridColor();
        }
        private void cbxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
           Tipo = cbxViewTipo.SelectedItem.ToString();
           LoadDataGridView();
        }
        private void cbxMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Status = cbxViewStatus.SelectedItem.ToString();
            LoadDataGridView();
        }
        #endregion

        #region Editar
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            LoadDataGridEdit();
            gbxCadastro.Enabled = true;
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
            if (tbxNome.Text == "" || cbxStatus.SelectedItem == null || cbxTipo.SelectedItem == null || cbxPagamento.SelectedItem == null)
            {
                MessageBox.Show("Um campo está faltando !");
                return;
            }
            DataRow drNewRow = ds.Tables[0].NewRow();
            drNewRow[0] = dtpDataEntrada.Text;
            drNewRow[1] = dtpDataVal.Text;
            drNewRow[2] = ToFirstLettertoCap(tbxNome.Text);
            drNewRow[3] = cbxTipo.SelectedItem;
            drNewRow[4] = tbxValor.Text;
            drNewRow[5] = cbxStatus.SelectedItem;
            drNewRow[6] = cbxPagamento.SelectedItem;
            drNewRow[7] = tbx1Entrada.Text;
            drNewRow[8] = tbxParcela1.Text;
            drNewRow[9] = tbxParcela2.Text;
            drNewRow[10] = tbxParcela3.Text;
            drNewRow[11] = tbxNOrdem.Text;
            ds.Tables[0].Rows.Add(drNewRow);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            dgvEdit.Update();
            dgvEdit.EndEdit();
            ds.AcceptChanges();
            ds.WriteXml(OfflineFile);
            MessageBox.Show("Alterações salvas no arquivo !");
            LoadDataGridView();
        }
        #endregion

        //FORM LOAD
        private void frmClientControl_Load(object sender, EventArgs e)
        {
            try
            {
                OfflineFile = CRegistros.GetOneDriveFolder() + "\\Suporte\\ControledeOrçamentos.xml";
            }
            catch (Exception)
            {
                return;
            }

            if (!File.Exists(OfflineFile))
            {
                Close();
                return;
            }

            cbxViewTipo.SelectedIndex = 0;
            cbxViewStatus.SelectedIndex = 0;
            LoadDataGridView();

        }

        #region Botoes
        private void btnSearchcpf_Click(object sender, EventArgs e)
        {
            Num = tbxSearch.Text;

            if (Num.Contains(" "))
                return;

            LoadDataGridView();
            Num = "";
        }
        private void tbxValor_Leave(object sender, EventArgs e)
        {
            Double value;//("{0:#,##0.00}", 
            tbxValor.Text = Double.TryParse(tbxValor.Text, out value) ? String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:##0.00}", value) : String.Empty;
        }

        private void tbxParcela1_Leave(object sender, EventArgs e)
        {
            Double value;//("{0:#,##0.00}", 
            tbxParcela1.Text = Double.TryParse(tbxParcela1.Text, out value) ? String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:##0.00}", value) : String.Empty;
        }

        private void tbxParcela2_Leave(object sender, EventArgs e)
        {
            Double value;//("{0:#,##0.00}", 
            tbxParcela2.Text = Double.TryParse(tbxParcela2.Text, out value) ? String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:##0.00}", value) : String.Empty;
        }

        private void tbxParcela3_Leave(object sender, EventArgs e)
        {
            Double value;//("{0:#,##0.00}", 
            tbxParcela3.Text = Double.TryParse(tbxParcela3.Text, out value) ? String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:##0.00}", value) : String.Empty;
        }
        private void tbx1Entrada_Leave(object sender, EventArgs e)
        {
            //Double value;//("{0:#,##0.00}", 
           // tbx1Entrada.Text = Double.TryParse(tbx1Entrada.Text, out value) ? String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:##0.00}", value) : String.Empty;
        }
        private void cbxPagamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            double valor = Convert.ToDouble(tbxValor.Text); // valor original
          //  double percentual = 30.0 / 100.0; // 30%
            //double valor_final = valor - (percentual * valor);

            if (cbxPagamento.SelectedItem.ToString() == "A Prazo")
            {
                tbx1Entrada.Enabled = true;
                tbxParcela1.Enabled = true;
                tbxParcela2.Enabled = true;
                tbxParcela3.Enabled = true;
                tbx1Entrada.Text = ((valor *30)/100).ToString(CultureInfo.InvariantCulture);

            }
            else
            {
                tbx1Entrada.Text = "";
                tbxParcela1.Text = "";
                tbxParcela2.Text = "";
                tbxParcela3.Text = "";
                tbx1Entrada.Enabled = false;
                tbxParcela1.Enabled = false;
                tbxParcela2.Enabled = false;
                tbxParcela3.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CleanDataGridExpired();
        }

        private void dgvEdit_MouseClick(object sender, MouseEventArgs e)
        {
            if(!gbxCadastro.Enabled)
                return;
            btnAtualizar.Enabled = true;//Ativa botao de atualizar.

            DataGridViewRow dr = dgvEdit.SelectedRows[0];
            SelectedRow = dr.Index;
            dtpDataEntrada.Text = dr.Cells[0].Value.ToString();
            dtpDataVal.Text = dr.Cells[1].Value.ToString();
            tbxNome.Text = dr.Cells[2].Value.ToString();
            cbxTipo.SelectedItem = dr.Cells[3].Value.ToString();
            tbxValor.Text = dr.Cells[4].Value.ToString();
            cbxStatus.SelectedItem = dr.Cells[5].Value.ToString();
            cbxPagamento.SelectedItem = dr.Cells[6].Value.ToString();
            tbx1Entrada.Text = dr.Cells[7].Value.ToString();

            if (dr.Cells[8].Value.ToString() != "")
            {
                tbxParcela1.Enabled = true;
                tbxParcela2.Enabled = true;
                tbxParcela3.Enabled = true;
            }
            else
            {
                tbxParcela1.Enabled = false;
                tbxParcela2.Enabled = false;
                tbxParcela3.Enabled = false;
            }
            tbxParcela1.Text = dr.Cells[8].Value.ToString();
            tbxParcela2.Text = dr.Cells[9].Value.ToString();
            tbxParcela3.Text = dr.Cells[10].Value.ToString();
            tbxNOrdem.Text = dr.Cells[11].Value.ToString();
            
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if(tbxNome.Text == "")
                return;
            if (dtpDataVal.Enabled)
                DataNull = dtpDataVal.Text;

            dgvEdit.Rows[SelectedRow].SetValues(dtpDataEntrada.Text, DataNull, tbxNome.Text,
                cbxTipo.SelectedItem, tbxValor.Text, cbxStatus.SelectedItem,cbxPagamento.SelectedItem,tbx1Entrada.Text, tbxParcela1.Text, 
                tbxParcela2.Text, tbxParcela3.Text, tbxNOrdem.Text);
            MessageBox.Show("Valores Atualizados.");
        }
        #endregion

        private void btnCalcularPar_Click(object sender, EventArgs e)
        {
            tbxParcela1.Text = "";
            tbxParcela2.Text = "";
            tbxParcela3.Text = "";
            double valor = Convert.ToDouble(tbxValor.Text); // valor original
            double newvalor = valor - (valor*30)/100; //== Valor a dividir
            double parcela = Math.Round(newvalor/Convert.ToDouble(numParc.Value),2);
            if (numParc.Value == 1)
            {
                tbxParcela1.Text = parcela.ToString();
                tbxParcela2.Text = "";
                tbxParcela3.Text = "";
            }
            if (numParc.Value == 2)
            {
                tbxParcela1.Text = parcela.ToString();
                tbxParcela2.Text = parcela.ToString();
                tbxParcela3.Text = "";
            }
            if (numParc.Value == 3)
            {
                tbxParcela1.Text = parcela.ToString();
                tbxParcela2.Text = parcela.ToString();
                tbxParcela3.Text = parcela.ToString();
            }
        }

    }
}