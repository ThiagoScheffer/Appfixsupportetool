using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmAgEventos : Form
    {
        private readonly DataSet ds = new DataSet();
        private string Mes = "Todos";
        private string Tipo = "Todos";
        private int SelectedRow;

        private string EventosFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Eventos.xml";
        public frmAgEventos()
        {
            InitializeComponent();
        }
        #region Load GRID

        private void DataGridColor()
        {
            foreach (DataGridViewRow row in dgvAgenda.Rows)
            {
                if (row.Cells[5].Value.ToString() == "Concluído") continue;
                row.DefaultCellStyle.BackColor = Color.LightSalmon;
            }
        }
        private void LoadDataGridEdit()
        {
            if(!File.Exists(tbxLocalXML.Text))
                return;
            ds.Clear();
            ds.ReadXml(tbxLocalXML.Text);//<-- carrega do diretorio selecionado
            dgvEdit.DataSource = ds;
            dgvEdit.DataMember = "Year";//-> Busca dentro do ds o Datamember real
            dgvEdit.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Data
            dgvEdit.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //MEs
            dgvEdit.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //hora
            dgvEdit.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Tipo
            dgvEdit.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Contratante
            dgvEdit.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Status
            dgvEdit.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvEdit.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //descr 
            dgvEdit.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //ano
        }

        private void LoadDataGridView(string Mes, string Tipo)
        {
            ds.Clear(); //Limpa para atualizar
            try
            {
                ds.ReadXml(CRegistros.GetAgendaPath());
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao acessar arquivo de Eventos!");
            }
            dgvAgenda.DataSource = ds;
            dgvAgenda.DataMember = "Year";
            DataView dvView = new DataView(ds.Tables[0]);

            if (Mes == "Todos" && Tipo == "Todos")
            {
                dvView.EndInit();
            }
            else if (Mes == "Todos" && Tipo != "Todos") //Tipo
            {
                dvView.RowFilter = "Tipo LIKE '" + Tipo +"'";
            }
            else if (Mes != "Todos" && Tipo == "Todos") //Mes
            {
                dvView.RowFilter = "Mes LIKE '" + Mes + "'";
            }
            else if (Mes != "Todos" && Tipo != "Todos")
            {
                dvView.RowFilter = "Tipo LIKE '" + Tipo + "' AND Mes LIKE '" + Mes + "'";
            }

            dgvAgenda.DataSource = dvView;
            dgvAgenda.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Data
            dgvAgenda.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Mes
            dgvAgenda.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Hora
            dgvAgenda.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Tipo
            dgvAgenda.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Contratante
            dgvAgenda.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Status
            dgvAgenda.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvAgenda.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //descr 
            dgvAgenda.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //ano
        }
        private void cbxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string TipoSelecionado = cbxViewTipo.SelectedItem.ToString();
            Tipo = TipoSelecionado;
            LoadDataGridView(Mes, TipoSelecionado);
        }
        private void cbxMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string MesSelecionado = cbxViewMes.SelectedItem.ToString();
            Mes = MesSelecionado;
            LoadDataGridView(MesSelecionado, Tipo);
        }
        #endregion

        private void btnAlterarLocal_Click(object sender, EventArgs e)
        {
            //Gravar no Reg o novo caminho
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            { 
                tbxLocalXML.Text = Path.GetFullPath(openFile.FileName);
                CRegistros.WriteAgendaPath(tbxLocalXML.Text);//Grava no Registro o Local do Arquivo Alterado.
            }

            if (string.IsNullOrEmpty(tbxLocalXML.Text))
                return;
            //Cliente = tbxLocalXML.Text;
            LoadDataGridEdit();
        }

        private void CreateFileEventos()
        {

          File.WriteAllBytes(EventosFilePath, Properties.Resources.Eventos);

        }

        //FORM LOAD EV
        private void frmAgenda_Load(object sender, EventArgs e)
        {
            cbxViewTipo.SelectedIndex = 0;
            cbxViewMes.SelectedIndex = 0;

            //LOAD CUSTOM DTP
            dtpHour.CustomFormat = "HH:mm";

           if (!File.Exists(EventosFilePath))
               CreateFileEventos();

            if (File.Exists(CRegistros.GetAgendaPath()))
            {
                LoadDataGridView(Mes, Tipo); //Grid Principal
                DataGridColor();
            }
            else if (File.Exists(EventosFilePath))
            {
                CRegistros.WriteAgendaPath(EventosFilePath);//Registra o Caminho da Agenda.
                LoadDataGridView(Mes, Tipo); //Grid Principal
                DataGridColor();
            }
            else
            {
                Close();
            }
        }

        private void btnLoadAgenda_Click(object sender, EventArgs e)
        {
            tbxLocalXML.Text = CRegistros.GetAgendaPath();
            groupBox1.Enabled = true;
            LoadDataGridEdit();
        }

        private string CovertFirstLettertoCap(string text)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text);

            //textBox1.Text = textInfo.ToTitleCase(textBox1.Text);
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (tbxContratante.Text == "" || cbxStatus.SelectedItem == null ||
                cbxTipo.SelectedItem == null)
            {
                MessageBox.Show("Um campo está faltando !");
                return;
            }
            DateTime dt = dtpData.Value;
            DataRow drNewRow = ds.Tables[0].NewRow();
            drNewRow[0] = dtpData.Text;
            drNewRow[1] = CovertFirstLettertoCap(dt.ToString("MMMM"));
            drNewRow[2] = dtpHour.Text;
            drNewRow[3] = cbxTipo.SelectedItem;
            drNewRow[4] = tbxContratante.Text;
            drNewRow[5] = cbxStatus.SelectedItem;
            drNewRow[6] = tbxServico.Text;
            drNewRow[7] = DateTime.Now.ToString("yyyy");
            ds.Tables[0].Rows.Add(drNewRow);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            dgvEdit.Update();
            dgvEdit.EndEdit();
            ds.AcceptChanges();
            ds.WriteXml(tbxLocalXML.Text);
            MessageBox.Show("Alterações salvas no arquivo !");
            
            LoadDataGridView(Mes,Tipo);
        }

        private void frmAgenda_FormClosed(object sender, FormClosedEventArgs e)
        {
            ds.Dispose();
            dgvEdit.Dispose();
            dgvAgenda.Dispose();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (tbxContratante.Text == "")
                return;
            DateTime dt = dtpData.Value;
            dgvEdit.Rows[SelectedRow].SetValues(dtpData.Text,CovertFirstLettertoCap(dt.ToString("MMMM")),dtpHour.Text, cbxTipo.SelectedItem, tbxContratante.Text, cbxStatus.SelectedItem, tbxServico.Text,DateTime.Now.ToString("yyyy"));
            MessageBox.Show("Valores Atualizados.");

        }

        private void dgvEdit_MouseClick(object sender, MouseEventArgs e)
        {
            if(!groupBox1.Enabled)
                return;
            btnAplicar.Enabled = true;

            DataGridViewRow dr = dgvEdit.SelectedRows[0];
            SelectedRow = dr.Index;
            dtpData.Text = dr.Cells[0].Value.ToString();
            dtpHour.Text = dr.Cells[2].Value.ToString();
            cbxTipo.SelectedItem = dr.Cells[3].Value.ToString();
            tbxContratante.Text = dr.Cells[4].Value.ToString();
            cbxStatus.SelectedItem = dr.Cells[5].Value.ToString();
            tbxServico.Text = dr.Cells[6].Value.ToString();
        }
    }
}
