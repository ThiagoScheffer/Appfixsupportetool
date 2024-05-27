namespace Suporte
{
    partial class frmControledeServicos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvListaServ = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxViewStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxViewTipo = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbxSearchCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.tbxSearchCPF = new System.Windows.Forms.MaskedTextBox();
            this.btnSearchcpf = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvEditServ = new System.Windows.Forms.DataGridView();
            this.gbxCadastro = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxCPF = new System.Windows.Forms.MaskedTextBox();
            this.tbxValor = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpDataSaida = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxServico = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDataEntrada = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxRelatorio = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddSituação = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnShowGarantia = new System.Windows.Forms.Button();
            this.btnLoadAgenda = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaServ)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditServ)).BeginInit();
            this.gbxCadastro.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(873, 528);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvListaServ);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(865, 502);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Serviços";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvListaServ
            // 
            this.dgvListaServ.AllowUserToAddRows = false;
            this.dgvListaServ.AllowUserToDeleteRows = false;
            this.dgvListaServ.AllowUserToOrderColumns = true;
            this.dgvListaServ.AllowUserToResizeColumns = false;
            this.dgvListaServ.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaServ.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaServ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvListaServ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaServ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaServ.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaServ.Location = new System.Drawing.Point(3, 100);
            this.dgvListaServ.Name = "dgvListaServ";
            this.dgvListaServ.ReadOnly = true;
            this.dgvListaServ.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvListaServ.Size = new System.Drawing.Size(859, 399);
            this.dgvListaServ.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.tbxSearchCNPJ);
            this.panel1.Controls.Add(this.tbxSearchCPF);
            this.panel1.Controls.Add(this.btnSearchcpf);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 97);
            this.panel1.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbxViewStatus);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbxViewTipo);
            this.groupBox2.Location = new System.Drawing.Point(5, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 68);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Organizar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(165, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Por Tipo";
            // 
            // cbxViewStatus
            // 
            this.cbxViewStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxViewStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxViewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxViewStatus.FormattingEnabled = true;
            this.cbxViewStatus.Items.AddRange(new object[] {
            "Todos",
            "Concluído e Pago",
            "Em Andamento",
            "Aguardando"});
            this.cbxViewStatus.Location = new System.Drawing.Point(8, 32);
            this.cbxViewStatus.Name = "cbxViewStatus";
            this.cbxViewStatus.Size = new System.Drawing.Size(121, 21);
            this.cbxViewStatus.TabIndex = 8;
            this.cbxViewStatus.SelectionChangeCommitted += new System.EventHandler(this.cbxMes_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Por Situação";
            // 
            // cbxViewTipo
            // 
            this.cbxViewTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxViewTipo.FormattingEnabled = true;
            this.cbxViewTipo.Items.AddRange(new object[] {
            "Todos",
            "Residencial",
            "Comercial",
            "Empresarial"});
            this.cbxViewTipo.Location = new System.Drawing.Point(135, 32);
            this.cbxViewTipo.Name = "cbxViewTipo";
            this.cbxViewTipo.Size = new System.Drawing.Size(121, 21);
            this.cbxViewTipo.TabIndex = 9;
            this.cbxViewTipo.SelectionChangeCommitted += new System.EventHandler(this.cbxTipo_SelectionChangeCommitted);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(398, 19);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 13);
            this.label20.TabIndex = 18;
            this.label20.Text = "Procurar CNPJ";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Location = new System.Drawing.Point(0, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(859, 18);
            this.panel3.TabIndex = 13;
            // 
            // tbxSearchCNPJ
            // 
            this.tbxSearchCNPJ.Location = new System.Drawing.Point(398, 35);
            this.tbxSearchCNPJ.Mask = "99,999,999/9999-99";
            this.tbxSearchCNPJ.Name = "tbxSearchCNPJ";
            this.tbxSearchCNPJ.Size = new System.Drawing.Size(109, 20);
            this.tbxSearchCNPJ.TabIndex = 17;
            // 
            // tbxSearchCPF
            // 
            this.tbxSearchCPF.Location = new System.Drawing.Point(302, 35);
            this.tbxSearchCPF.Mask = "000,000,000-00";
            this.tbxSearchCPF.Name = "tbxSearchCPF";
            this.tbxSearchCPF.Size = new System.Drawing.Size(90, 20);
            this.tbxSearchCPF.TabIndex = 14;
            // 
            // btnSearchcpf
            // 
            this.btnSearchcpf.Location = new System.Drawing.Point(513, 35);
            this.btnSearchcpf.Name = "btnSearchcpf";
            this.btnSearchcpf.Size = new System.Drawing.Size(75, 20);
            this.btnSearchcpf.TabIndex = 16;
            this.btnSearchcpf.Text = "OK";
            this.btnSearchcpf.UseVisualStyleBackColor = true;
            this.btnSearchcpf.Click += new System.EventHandler(this.btnSearchcpf_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(299, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Procurar CPF";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvEditServ);
            this.tabPage2.Controls.Add(this.gbxCadastro);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(865, 502);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Adicionar/Alterar Serviço";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvEditServ
            // 
            this.dgvEditServ.AllowUserToAddRows = false;
            this.dgvEditServ.AllowUserToResizeColumns = false;
            this.dgvEditServ.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEditServ.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEditServ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEditServ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditServ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEditServ.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEditServ.Location = new System.Drawing.Point(3, 3);
            this.dgvEditServ.Name = "dgvEditServ";
            this.dgvEditServ.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvEditServ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEditServ.Size = new System.Drawing.Size(859, 333);
            this.dgvEditServ.TabIndex = 28;
            this.dgvEditServ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvEdit_MouseClick);
            // 
            // gbxCadastro
            // 
            this.gbxCadastro.Controls.Add(this.label12);
            this.gbxCadastro.Controls.Add(this.label16);
            this.gbxCadastro.Controls.Add(this.tbxCPF);
            this.gbxCadastro.Controls.Add(this.tbxValor);
            this.gbxCadastro.Controls.Add(this.label15);
            this.gbxCadastro.Controls.Add(this.dtpDataSaida);
            this.gbxCadastro.Controls.Add(this.label14);
            this.gbxCadastro.Controls.Add(this.cbxServico);
            this.gbxCadastro.Controls.Add(this.label13);
            this.gbxCadastro.Controls.Add(this.tbxNome);
            this.gbxCadastro.Controls.Add(this.label2);
            this.gbxCadastro.Controls.Add(this.dtpDataEntrada);
            this.gbxCadastro.Controls.Add(this.label3);
            this.gbxCadastro.Controls.Add(this.cbxStatus);
            this.gbxCadastro.Controls.Add(this.label5);
            this.gbxCadastro.Controls.Add(this.label6);
            this.gbxCadastro.Controls.Add(this.cbxTipo);
            this.gbxCadastro.Controls.Add(this.label4);
            this.gbxCadastro.Controls.Add(this.tbxRelatorio);
            this.gbxCadastro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxCadastro.Enabled = false;
            this.gbxCadastro.Location = new System.Drawing.Point(3, 336);
            this.gbxCadastro.Name = "gbxCadastro";
            this.gbxCadastro.Size = new System.Drawing.Size(859, 125);
            this.gbxCadastro.TabIndex = 10;
            this.gbxCadastro.TabStop = false;
            this.gbxCadastro.Text = "Adicionar Dados";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(135, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "CPF/CNPJ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(262, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Valor";
            // 
            // tbxCPF
            // 
            this.tbxCPF.Location = new System.Drawing.Point(138, 33);
            this.tbxCPF.Mask = "000,000,000-00";
            this.tbxCPF.Name = "tbxCPF";
            this.tbxCPF.ReadOnly = true;
            this.tbxCPF.Size = new System.Drawing.Size(139, 20);
            this.tbxCPF.TabIndex = 27;
            // 
            // tbxValor
            // 
            this.tbxValor.AllowPromptAsInput = false;
            this.tbxValor.Location = new System.Drawing.Point(265, 87);
            this.tbxValor.Name = "tbxValor";
            this.tbxValor.Size = new System.Drawing.Size(65, 20);
            this.tbxValor.TabIndex = 35;
            this.tbxValor.Leave += new System.EventHandler(this.tbxValor_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(138, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Data Saída";
            // 
            // dtpDataSaida
            // 
            this.dtpDataSaida.Enabled = false;
            this.dtpDataSaida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataSaida.Location = new System.Drawing.Point(138, 87);
            this.dtpDataSaida.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpDataSaida.Name = "dtpDataSaida";
            this.dtpDataSaida.Size = new System.Drawing.Size(121, 20);
            this.dtpDataSaida.TabIndex = 33;
            this.dtpDataSaida.Value = new System.DateTime(2014, 3, 27, 0, 0, 0, 0);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(547, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Serviço";
            // 
            // cbxServico
            // 
            this.cbxServico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxServico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServico.FormattingEnabled = true;
            this.cbxServico.Items.AddRange(new object[] {
            "Formatação",
            "Limpeza",
            "Diagnóstico",
            "Instalação",
            "Remoção Vírus",
            "Reparo SO",
            "Reparo de Hardware",
            "Instalação de Peça",
            "Outro"});
            this.cbxServico.Location = new System.Drawing.Point(516, 32);
            this.cbxServico.Name = "cbxServico";
            this.cbxServico.Size = new System.Drawing.Size(146, 21);
            this.cbxServico.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(286, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Nome do Cliente";
            // 
            // tbxNome
            // 
            this.tbxNome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbxNome.Location = new System.Drawing.Point(286, 33);
            this.tbxNome.Name = "tbxNome";
            this.tbxNome.Size = new System.Drawing.Size(224, 20);
            this.tbxNome.TabIndex = 29;
            this.tbxNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxNome_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Data Entrada";
            // 
            // dtpDataEntrada
            // 
            this.dtpDataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntrada.Location = new System.Drawing.Point(11, 87);
            this.dtpDataEntrada.Name = "dtpDataEntrada";
            this.dtpDataEntrada.Size = new System.Drawing.Size(121, 20);
            this.dtpDataEntrada.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(724, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Situação";
            // 
            // cbxStatus
            // 
            this.cbxStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
            "Aguardando",
            "Aguardando Material",
            "Aguardando Autorização",
            "Saiu para Entrega",
            "Concluído e Pago",
            "Concluído",
            "Em Andamento"});
            this.cbxStatus.Location = new System.Drawing.Point(668, 32);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(165, 21);
            this.cbxStatus.TabIndex = 18;
            this.cbxStatus.SelectionChangeCommitted += new System.EventHandler(this.cbxStatus_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tipo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(424, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 16;
            // 
            // cbxTipo
            // 
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.Enabled = false;
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "Residencial",
            "Comercial",
            "Empresarial"});
            this.cbxTipo.Location = new System.Drawing.Point(6, 31);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(121, 21);
            this.cbxTipo.TabIndex = 15;
            this.cbxTipo.SelectionChangeCommitted += new System.EventHandler(this.cbxTipo_SelectionChangeCommitted_1);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Informações";
            // 
            // tbxRelatorio
            // 
            this.tbxRelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRelatorio.Location = new System.Drawing.Point(349, 71);
            this.tbxRelatorio.Name = "tbxRelatorio";
            this.tbxRelatorio.Size = new System.Drawing.Size(484, 48);
            this.tbxRelatorio.TabIndex = 12;
            this.tbxRelatorio.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.btnAddSituação);
            this.panel2.Controls.Add(this.btnAtualizar);
            this.panel2.Controls.Add(this.btnShowGarantia);
            this.panel2.Controls.Add(this.btnLoadAgenda);
            this.panel2.Controls.Add(this.btnSalvar);
            this.panel2.Controls.Add(this.btnAdicionar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 461);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 38);
            this.panel2.TabIndex = 11;
            // 
            // btnAddSituação
            // 
            this.btnAddSituação.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddSituação.Location = new System.Drawing.Point(286, 8);
            this.btnAddSituação.Name = "btnAddSituação";
            this.btnAddSituação.Size = new System.Drawing.Size(118, 23);
            this.btnAddSituação.TabIndex = 31;
            this.btnAddSituação.Text = "Adicionar Situação";
            this.btnAddSituação.UseVisualStyleBackColor = true;
            this.btnAddSituação.Click += new System.EventHandler(this.btnAddSituação_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAtualizar.Enabled = false;
            this.btnAtualizar.Location = new System.Drawing.Point(612, 8);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(118, 23);
            this.btnAtualizar.TabIndex = 30;
            this.btnAtualizar.Text = "Aplicar Modificações";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnShowGarantia
            // 
            this.btnShowGarantia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowGarantia.Location = new System.Drawing.Point(138, 8);
            this.btnShowGarantia.Name = "btnShowGarantia";
            this.btnShowGarantia.Size = new System.Drawing.Size(118, 23);
            this.btnShowGarantia.TabIndex = 28;
            this.btnShowGarantia.Text = "Dentro do Prazo";
            this.btnShowGarantia.UseVisualStyleBackColor = true;
            this.btnShowGarantia.Click += new System.EventHandler(this.btnShowGarantia_Click);
            // 
            // btnLoadAgenda
            // 
            this.btnLoadAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadAgenda.Location = new System.Drawing.Point(5, 8);
            this.btnLoadAgenda.Name = "btnLoadAgenda";
            this.btnLoadAgenda.Size = new System.Drawing.Size(122, 23);
            this.btnLoadAgenda.TabIndex = 12;
            this.btnLoadAgenda.Text = "Abrir Arquivo";
            this.btnLoadAgenda.UseVisualStyleBackColor = true;
            this.btnLoadAgenda.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(736, 8);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(118, 23);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "Salvar Alterações";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdicionar.Location = new System.Drawing.Point(410, 8);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(118, 23);
            this.btnAdicionar.TabIndex = 9;
            this.btnAdicionar.Text = "Adicionar Serviço";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // frmControledeServicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 528);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmControledeServicos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Serviço";
            this.Load += new System.EventHandler(this.frmClientControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaServ)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditServ)).EndInit();
            this.gbxCadastro.ResumeLayout(false);
            this.gbxCadastro.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxViewStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxViewTipo;
        private System.Windows.Forms.DataGridView dgvListaServ;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnLoadAgenda;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbxCadastro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDataEntrada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox tbxRelatorio;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.MaskedTextBox tbxSearchCPF;
        private System.Windows.Forms.Button btnSearchcpf;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxServico;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxNome;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox tbxCPF;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpDataSaida;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox tbxValor;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox tbxSearchCNPJ;
        private System.Windows.Forms.Button btnShowGarantia;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DataGridView dgvEditServ;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddSituação;
    }
}