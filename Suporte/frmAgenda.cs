using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Suporte
{
    public partial class frmAgenda : Form
    {
        private readonly DataSet _dataSet = new DataSet();
        private readonly DataTable _dataTable = new DataTable("Evento");
        private DataView _dvView = new DataView();
        private int _selectedRow = -1;
        private string _agendaFilePath = "";
       public frmAgenda()
        {
            InitializeComponent();
        }
        #region FORM
        //FORM LOAD EV
        private void frmAgenda_Load(object sender, EventArgs e)
        {
            _agendaFilePath = CRegistros.GetOneDriveFolder() + "\\Suporte\\Agenda.xml";

            if (!File.Exists(_agendaFilePath))
            {
                Close();
                return;
            }
            cbxViewTipo.SelectedIndex = 0;
            cbxViewMes.SelectedIndex = 0;

            //Tranforma o dtp em horas apenas
            dtpHour.CustomFormat = "HH:mm";

            //await Task.Run(() => LoadDataGridView());

            LoadDataGridView();

        }
        private static string CovertFirstLettertoCap(string text)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text);
        }
        private void frmAgenda_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dataSet.Dispose();
            dgvEdit.Dispose();
            dgvAgenda.Dispose();
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OcultarConcluidos(bool ocultar)
        {
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvAgenda.DataSource];
            currencyManager1.SuspendBinding();
            foreach (DataGridViewRow row in dgvAgenda.Rows)
            {
                if (row.Cells[2].Value.ToString() == "Concluído")
                    row.Visible = ocultar;
            }
            currencyManager1.ResumeBinding();
        }

        private void OcultarOutrosMeses(bool ocultar)
        {
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvAgenda.DataSource];
            currencyManager1.SuspendBinding();
            string Mes = DateTime.Now.ToString("MMMM");
            foreach (DataGridViewRow row in dgvAgenda.Rows)
            {
                //MES for Diferente do MES Atual  - Ocultar
                if (row.Cells[6].Value.ToString() != CovertFirstLettertoCap(Mes))
                {
                    row.Visible = ocultar;
                }

            }
            currencyManager1.ResumeBinding();
        }
        private void chkbxOcultar_CheckStateChanged(object sender, EventArgs e)
        {
            OcultarConcluidos(chkbxOcultar.CheckState != CheckState.Checked);
        }

        private void chkbxOcultarMes_CheckStateChanged(object sender, EventArgs e)
        {
            OcultarOutrosMeses(chkbxOcultarMes.CheckState != CheckState.Checked);
        }
        #endregion

        #region VISUALIZAR
        private void DataGridHighlight()
        {
            bool hasAlert = false;//FIX Skipping DATE
            int alertidx = -1;

            // SortDataByMultiColumns();

            foreach (DataGridViewRow row in dgvAgenda.Rows)
            {
                //CELL STATUS = [2]
                if (row.Cells[2].Value.ToString() == "Concluído")
                    continue;
                
                //Converte [4] para Formato DATE
                var fullDateTime = Convert.ToDateTime(row.Cells[4].Value);
                
                //Adiciona a data no calendario.
                monthCalendar1.AddBoldedDate(fullDateTime);
                monthCalendar1.UpdateBoldedDates();

                //Destacar serviço se for Hoje
                if (fullDateTime.Day == DateTime.Today.Day && fullDateTime.Hour > DateTime.Now.Hour)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                    //_alertidx = row.Index; Marcando IDX Errado
                }

                #region EXPIRAR

                //Setar para Concluido apos a data expirada. DATA
                if (fullDateTime < DateTime.Today) //
                {
                    dgvAgenda.Rows[row.Index].Cells[2].Value = "Concluído";
                }
                //Setar para Concluido apos a data expirada. HORA
                if (fullDateTime.Day == DateTime.Today.Day && fullDateTime.Hour <= DateTime.Now.Hour && fullDateTime.Minute <= DateTime.Now.Minute)
                {
                    dgvAgenda.Rows[row.Index].Cells[2].Value = "Concluído";
                }
                #endregion

                #region EventCheck
                //Verifica a data armazenada,data de hj, no fulldatetime eadiciona +1 dia ate achar o proximo dia de serviço.
                if (DateTime.Today.AddDays(1) == fullDateTime.Date && fullDateTime < DateTime.Today.AddDays(5) && !hasAlert) //Proximo dia tem um compromisso
                {
                    hasAlert = true;
                    dtpProxServ.Value = fullDateTime; alertidx = row.Index;
                    continue;
                }
                if (DateTime.Today.AddDays(2) == fullDateTime.Date && !hasAlert)
                {
                    hasAlert = true;
                    dtpProxServ.Value = fullDateTime; alertidx = row.Index;
                    continue;
                }
                if (DateTime.Today.AddDays(3) == fullDateTime.Date && !hasAlert)
                {
                    hasAlert = true;
                    dtpProxServ.Value = fullDateTime; alertidx = row.Index;
                    continue;
                }
                if (DateTime.Today.AddDays(4) == fullDateTime.Date && !hasAlert)
                {
                    hasAlert = true;
                    dtpProxServ.Value = fullDateTime; alertidx = row.Index;
                    continue;
                }
                if (DateTime.Today.AddDays(5) == fullDateTime.Date && !hasAlert)
                {
                    hasAlert = true;
                    dtpProxServ.Value = fullDateTime;
                    alertidx = row.Index;
                    continue;
                }
                if (DateTime.Today.AddDays(6) == fullDateTime.Date && !hasAlert)
                {
                    hasAlert = true;
                    dtpProxServ.Value = fullDateTime;
                    alertidx = row.Index;
                }
                #endregion
            }
            if (alertidx == -1) return;
            dgvAgenda.CurrentCell = dgvAgenda.Rows[alertidx].Cells[0];
            dgvAgenda.Rows[alertidx].Selected = true;
        }
        //string formatted = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss+HH:mm");
        private void LoadDataGridView()
        {
            try
            {
                _dataSet.Clear(); //Limpa para atualizar
                _dataTable.Reset();
                _dataTable.Columns.Add(new DataColumn("Tipo", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Nome", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Status", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Tarefa", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Data", typeof(DateTime)));
                _dataTable.Columns.Add(new DataColumn("Hora", typeof(string)));
                _dataTable.Columns.Add(new DataColumn("Mes", typeof(string)));
                _dataSet.Tables.Add(_dataTable);
                _dataSet.ReadXml(_agendaFilePath);
                //if (dgvAgenda.InvokeRequired)
               // {
                 //   dgvAgenda.BeginInvoke((MethodInvoker) delegate
                  //  {
                        dgvAgenda.DataSource = new BindingSource(_dataSet, "Evento");

                        //VISUAL
                        dgvAgenda.Columns[4].ValueType = typeof (DateTime);
                        dgvAgenda.Columns[4].DefaultCellStyle.Format = "d";
                        dgvAgenda.Sort(dgvAgenda.Columns[4], ListSortDirection.Ascending);
                        dgvAgenda.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        dgvAgenda.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        //Autoscroll ate fim
                        dgvAgenda.FirstDisplayedScrollingRowIndex = dgvAgenda.RowCount - 1;
                   // });
               // }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            
            DataGridHighlight();
        }

        private static void ShortFormDateFormat(DataGridViewCellFormattingEventArgs formatting)
        {
            if (formatting.Value != null)
            {
                try
                {
                    DateTime theDate = DateTime.Parse(formatting.Value.ToString());
                    String dateString = theDate.ToString("dd/MM/yyyy");
                    formatting.Value = dateString;
                    formatting.FormattingApplied = true;
                }
                catch (FormatException)
                {
                    // Set to false in case there are other handlers interested trying to
                    // format this DataGridViewCellFormattingEventArgs instance.
                    formatting.FormattingApplied = false;
                }
            }
        }
        private void cbxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltrosAgendaView();
        }
        private void cbxMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltrosAgendaView();
        }

        private void FiltrosAgendaView()
        {
            _dvView = _dataSet.Tables[0].DefaultView;
            if (cbxViewTipo.SelectedItem.ToString() != "Todos" && cbxViewMes.SelectedItem.ToString() != "Todos") //11
            {
                //Filtar Tipo e Mes
                _dvView.RowFilter = "Tipo='" + cbxViewTipo.SelectedItem + "'AND Mes='"+cbxViewMes.SelectedItem+"'";
                _dvView.Sort = "Mes";
            }
            else if (cbxViewMes.SelectedItem.ToString() == "Todos" && cbxViewTipo.SelectedItem.ToString() == "Todos")//00
            {
                _dvView.RowFilter = "";
            }
            else if (cbxViewMes.SelectedItem.ToString() != "Todos" && cbxViewTipo.SelectedItem.ToString() == "Todos")//10
            {
                _dvView.RowFilter = "Mes='" + cbxViewMes.SelectedItem + "'";
                _dvView.Sort = "Mes";
            }
            else if (cbxViewMes.SelectedItem.ToString() == "Todos" && cbxViewTipo.SelectedItem.ToString() != "Todos")//01
            {
                _dvView.RowFilter = "Tipo='" + cbxViewTipo.SelectedItem + "'";
                _dvView.Sort = "Tipo";
            }

            dgvAgenda.DataSource = _dvView;
            dgvAgenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvAgenda.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvAgenda.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvAgenda.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        #endregion

        #region AGENDA EDITAR
        //ALTERA O STATUS PARA CONCLUIDO PARA SERVIÇOS JA EXPIRADOS
        private void DataGridSetConcluido()
        {
            foreach (DataGridViewRow row in dgvEdit.Rows)
            {
                object value = row.Cells[2].Value;
                object value2 = row.Cells[4].Value;
                if (value == null || value2 == null || Convert.IsDBNull(value2)) continue;//Fix null error 08/11/14

                if (value.ToString() == "Concluído") continue;
               // monthCalendar1.AddBoldedDate(Convert.ToDateTime(row.Cells[4].Value.ToString()));
               // monthCalendar1.UpdateBoldedDates();
                
                //Modelo Novo
                DateTime fullDateTime = Convert.ToDateTime(value2);

                //Setar para Concluido apos a data expirada. DATA
                if (fullDateTime < DateTime.Today) //FIX
                {
                    dgvEdit.Rows[row.Index].Cells[2].Value = "Concluído";
                }
                //Setar para Concluido apos a data expirada. HORA
                if (fullDateTime.Day == DateTime.Today.Day && fullDateTime.Hour <= DateTime.Now.Hour) //
                {
                    dgvEdit.Rows[row.Index].Cells[2].Value = "Concluído";
                }
            }
        }
        private void LoadDataGridEdit()
        {
            if (!File.Exists(_agendaFilePath))
                return;
            _dataSet.Clear();
            _dataSet.ReadXml(_agendaFilePath);//<-- carrega do diretorio selecionado
            dgvEdit.DataSource = _dataSet;
            dgvEdit.DataMember = "Evento";//-> Busca dentro do ds o Datamember real

            dgvEdit.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvEdit.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //descr 
            dgvEdit.Columns[4].ValueType = typeof(DateTime);
            dgvEdit.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvEdit.Sort(dgvEdit.Columns[4], ListSortDirection.Ascending);
            if (dgvEdit.Rows.Count != 0)
            {
                dgvEdit.CurrentCell = dgvEdit.Rows[dgvEdit.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[0];
                dgvEdit.Rows[dgvEdit.Rows.GetLastRow(DataGridViewElementStates.None)].Selected = true;
            }
            dgvEdit.AutoResizeRows();
            //Autoscroll ate fim
            dgvEdit.FirstDisplayedScrollingRowIndex = dgvEdit.RowCount - 1;
            //dgvEdit.Rows[dgvEdit.Rows.GetLastRow(DataGridViewElementStates.None)].Cells. = true;
        }
        private void btnLoadAgenda_Click(object sender, EventArgs e)
        {
            btnSetarConcluido.Enabled = true;
            btnAdicionar.Enabled = true;
            btnSalvar.Enabled = true;
            dgvEdit.Enabled = true;
            groupBox1.Enabled = true;
            LoadDataGridEdit();
        }
        //DateTime newDateTime = oldDateTime.Add(TimeSpan.Parse(timeString));

        //ADICIONAR NOVO EVENTO
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (tbxNome.Text == string.Empty || cbxStatus.SelectedItem == null ||
                cbxTipo.SelectedItem == null)
            {
                MessageBox.Show("Um campo está faltando !");
                return;
            }
            DateTime combined = cUtils.DCombine(dtpData.Value, dtpHour.Value);
            DateTime dt = dtpData.Value;
            DataRow drNewRow = _dataSet.Tables[0].NewRow();
            drNewRow[0] = cbxTipo.SelectedItem;
            drNewRow[1] = tbxNome.Text;
            drNewRow[2] = cbxStatus.SelectedItem;
            drNewRow[3] = tbxServico.Text;
            drNewRow[4] = combined;
            drNewRow[5] = combined.ToShortTimeString();
            drNewRow[6] = CovertFirstLettertoCap(dt.ToString("MMMM"));

            _dataSet.Tables[0].Rows.Add(drNewRow);
        }

        //SALVAR ALTERAÇOES
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            dgvEdit.Update();
            _dataSet.AcceptChanges();
            _dataSet.WriteXml(_agendaFilePath);
            MessageBox.Show("Alterações foram salvas no arquivo !");

           // LoadDataGridView();
        }


        //APLICAR MODIFICAÇOES
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (tbxNome.Text == "")
                return;
            if (_selectedRow == -1)
                return;
            DateTime dt = dtpData.Value;
            DateTime combined = cUtils.DCombine(dtpData.Value, dtpHour.Value);

            dgvEdit.Rows[_selectedRow].SetValues(cbxTipo.SelectedItem, tbxNome.Text, cbxStatus.SelectedItem, tbxServico.Text, combined, combined.ToShortTimeString(), CovertFirstLettertoCap(dt.ToString("MMMM")));
            MessageBox.Show("Os valores foram atualizados.");
        }


        //CLICK NA LINHA PARA EDIÇAO
        private void dgvEdit_MouseClick(object sender, MouseEventArgs e)
        {
            if (!groupBox1.Enabled)
                return;
            btnAplicar.Enabled = true;

            DataGridViewRow dr = dgvEdit.SelectedRows[0];
            _selectedRow = dr.Index;
            dtpData.Text = dr.Cells[4].Value.ToString();
            dtpHour.Text = dr.Cells[5].Value.ToString();
            cbxTipo.SelectedItem = dr.Cells[0].Value.ToString();
            tbxNome.Text = dr.Cells[1].Value.ToString();
            cbxStatus.SelectedItem = dr.Cells[2].Value.ToString();
            tbxServico.Text = dr.Cells[3].Value.ToString();
        }

        //AUTO APLICAR STATUS ALTERADO
        private void cbxStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void btnSetarConcluido_Click(object sender, EventArgs e)
        {
            DataGridSetConcluido();
        } 
        #endregion
    }
}
