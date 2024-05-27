namespace Suporte
{
    partial class frmControledeOrcamentos
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxViewStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxViewTipo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvEdit = new System.Windows.Forms.DataGridView();
            this.gbxCadastro = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numParc = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCalcularPar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx1Entrada = new System.Windows.Forms.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxParcela3 = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxParcela2 = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbxPagamento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxParcela1 = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxNOrdem = new System.Windows.Forms.MaskedTextBox();
            this.tbxValor = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpDataVal = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDataEntrada = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnLoadAgenda = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdit)).BeginInit();
            this.gbxCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParc)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(1125, 527);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.dgvPreview);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.tbxSearch);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1117, 501);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Preview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Location = new System.Drawing.Point(3, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1114, 18);
            this.panel3.TabIndex = 13;
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.AllowUserToOrderColumns = true;
            this.dgvPreview.AllowUserToResizeColumns = false;
            this.dgvPreview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPreview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPreview.Location = new System.Drawing.Point(3, 103);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvPreview.Size = new System.Drawing.Size(1111, 395);
            this.dgvPreview.TabIndex = 17;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(380, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 20);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "OK";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearchcpf_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(305, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Procurar por número da ordem";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(308, 38);
            this.tbxSearch.Mask = "00000";
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(66, 20);
            this.tbxSearch.TabIndex = 14;
            this.tbxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSearch.ValidatingType = typeof(int);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbxViewStatus);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbxViewTipo);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
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
            "Aguardando",
            "Aprovado",
            "Entregue"});
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
            "KitUpgrade",
            "PC",
            "Produto"});
            this.cbxViewTipo.Location = new System.Drawing.Point(135, 32);
            this.cbxViewTipo.Name = "cbxViewTipo";
            this.cbxViewTipo.Size = new System.Drawing.Size(121, 21);
            this.cbxViewTipo.TabIndex = 9;
            this.cbxViewTipo.SelectionChangeCommitted += new System.EventHandler(this.cbxTipo_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 100);
            this.panel1.TabIndex = 18;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvEdit);
            this.tabPage2.Controls.Add(this.gbxCadastro);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1117, 501);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Editar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvEdit
            // 
            this.dgvEdit.AllowUserToResizeColumns = false;
            this.dgvEdit.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEdit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEdit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEdit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEdit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEdit.Location = new System.Drawing.Point(3, 3);
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEdit.Size = new System.Drawing.Size(1111, 332);
            this.dgvEdit.TabIndex = 6;
            this.dgvEdit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvEdit_MouseClick);
            // 
            // gbxCadastro
            // 
            this.gbxCadastro.Controls.Add(this.label20);
            this.gbxCadastro.Controls.Add(this.numParc);
            this.gbxCadastro.Controls.Add(this.label14);
            this.gbxCadastro.Controls.Add(this.btnCalcularPar);
            this.gbxCadastro.Controls.Add(this.label4);
            this.gbxCadastro.Controls.Add(this.tbx1Entrada);
            this.gbxCadastro.Controls.Add(this.label19);
            this.gbxCadastro.Controls.Add(this.tbxParcela3);
            this.gbxCadastro.Controls.Add(this.label18);
            this.gbxCadastro.Controls.Add(this.tbxParcela2);
            this.gbxCadastro.Controls.Add(this.label17);
            this.gbxCadastro.Controls.Add(this.cbxPagamento);
            this.gbxCadastro.Controls.Add(this.label1);
            this.gbxCadastro.Controls.Add(this.tbxParcela1);
            this.gbxCadastro.Controls.Add(this.label12);
            this.gbxCadastro.Controls.Add(this.label16);
            this.gbxCadastro.Controls.Add(this.tbxNOrdem);
            this.gbxCadastro.Controls.Add(this.tbxValor);
            this.gbxCadastro.Controls.Add(this.label15);
            this.gbxCadastro.Controls.Add(this.dtpDataVal);
            this.gbxCadastro.Controls.Add(this.label13);
            this.gbxCadastro.Controls.Add(this.tbxNome);
            this.gbxCadastro.Controls.Add(this.label2);
            this.gbxCadastro.Controls.Add(this.dtpDataEntrada);
            this.gbxCadastro.Controls.Add(this.label3);
            this.gbxCadastro.Controls.Add(this.cbxStatus);
            this.gbxCadastro.Controls.Add(this.label5);
            this.gbxCadastro.Controls.Add(this.label6);
            this.gbxCadastro.Controls.Add(this.cbxTipo);
            this.gbxCadastro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxCadastro.Enabled = false;
            this.gbxCadastro.Location = new System.Drawing.Point(3, 335);
            this.gbxCadastro.Name = "gbxCadastro";
            this.gbxCadastro.Size = new System.Drawing.Size(1111, 125);
            this.gbxCadastro.TabIndex = 10;
            this.gbxCadastro.TabStop = false;
            this.gbxCadastro.Text = "Dados";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(586, 75);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 13);
            this.label20.TabIndex = 49;
            this.label20.Text = "Nº Parcelas";
            // 
            // numParc
            // 
            this.numParc.Location = new System.Drawing.Point(598, 91);
            this.numParc.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numParc.Name = "numParc";
            this.numParc.Size = new System.Drawing.Size(34, 20);
            this.numParc.TabIndex = 47;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(649, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "Calcular Parcelas";
            // 
            // btnCalcularPar
            // 
            this.btnCalcularPar.Location = new System.Drawing.Point(652, 89);
            this.btnCalcularPar.Name = "btnCalcularPar";
            this.btnCalcularPar.Size = new System.Drawing.Size(118, 23);
            this.btnCalcularPar.TabIndex = 31;
            this.btnCalcularPar.Text = "Calcular Parcelas";
            this.btnCalcularPar.UseVisualStyleBackColor = true;
            this.btnCalcularPar.Click += new System.EventHandler(this.btnCalcularPar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "30%  Entrada";
            // 
            // tbx1Entrada
            // 
            this.tbx1Entrada.AllowPromptAsInput = false;
            this.tbx1Entrada.Enabled = false;
            this.tbx1Entrada.Location = new System.Drawing.Point(210, 90);
            this.tbx1Entrada.Name = "tbx1Entrada";
            this.tbx1Entrada.ReadOnly = true;
            this.tbx1Entrada.Size = new System.Drawing.Size(65, 20);
            this.tbx1Entrada.TabIndex = 45;
            this.tbx1Entrada.Leave += new System.EventHandler(this.tbx1Entrada_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(422, 75);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 44;
            this.label19.Text = "3º Parcela";
            // 
            // tbxParcela3
            // 
            this.tbxParcela3.AllowPromptAsInput = false;
            this.tbxParcela3.Enabled = false;
            this.tbxParcela3.Location = new System.Drawing.Point(419, 90);
            this.tbxParcela3.Name = "tbxParcela3";
            this.tbxParcela3.Size = new System.Drawing.Size(65, 20);
            this.tbxParcela3.TabIndex = 43;
            this.tbxParcela3.Leave += new System.EventHandler(this.tbxParcela3_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(354, 75);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "2º Parcela";
            // 
            // tbxParcela2
            // 
            this.tbxParcela2.AllowPromptAsInput = false;
            this.tbxParcela2.Enabled = false;
            this.tbxParcela2.Location = new System.Drawing.Point(351, 90);
            this.tbxParcela2.Name = "tbxParcela2";
            this.tbxParcela2.Size = new System.Drawing.Size(65, 20);
            this.tbxParcela2.TabIndex = 41;
            this.tbxParcela2.Leave += new System.EventHandler(this.tbxParcela2_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(92, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Modo de Pagamento";
            // 
            // cbxPagamento
            // 
            this.cbxPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPagamento.FormattingEnabled = true;
            this.cbxPagamento.Items.AddRange(new object[] {
            "À Vista",
            "Cheque",
            "A Prazo"});
            this.cbxPagamento.Location = new System.Drawing.Point(86, 89);
            this.cbxPagamento.Name = "cbxPagamento";
            this.cbxPagamento.Size = new System.Drawing.Size(121, 21);
            this.cbxPagamento.TabIndex = 39;
            this.cbxPagamento.SelectionChangeCommitted += new System.EventHandler(this.cbxPagamento_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "1º Parcela";
            // 
            // tbxParcela1
            // 
            this.tbxParcela1.AllowPromptAsInput = false;
            this.tbxParcela1.Enabled = false;
            this.tbxParcela1.Location = new System.Drawing.Point(281, 90);
            this.tbxParcela1.Name = "tbxParcela1";
            this.tbxParcela1.Size = new System.Drawing.Size(65, 20);
            this.tbxParcela1.TabIndex = 37;
            this.tbxParcela1.Leave += new System.EventHandler(this.tbxParcela1_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(491, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Numero da Ordem";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Valor";
            // 
            // tbxNOrdem
            // 
            this.tbxNOrdem.Location = new System.Drawing.Point(490, 90);
            this.tbxNOrdem.Mask = "00000";
            this.tbxNOrdem.Name = "tbxNOrdem";
            this.tbxNOrdem.Size = new System.Drawing.Size(90, 20);
            this.tbxNOrdem.TabIndex = 27;
            this.tbxNOrdem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxNOrdem.ValidatingType = typeof(int);
            // 
            // tbxValor
            // 
            this.tbxValor.AllowPromptAsInput = false;
            this.tbxValor.Location = new System.Drawing.Point(15, 90);
            this.tbxValor.Name = "tbxValor";
            this.tbxValor.Size = new System.Drawing.Size(65, 20);
            this.tbxValor.TabIndex = 35;
            this.tbxValor.Leave += new System.EventHandler(this.tbxValor_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(617, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Validade";
            // 
            // dtpDataVal
            // 
            this.dtpDataVal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataVal.Location = new System.Drawing.Point(617, 32);
            this.dtpDataVal.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpDataVal.Name = "dtpDataVal";
            this.dtpDataVal.Size = new System.Drawing.Size(121, 20);
            this.dtpDataVal.TabIndex = 33;
            this.dtpDataVal.Value = new System.DateTime(2014, 3, 27, 0, 0, 0, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(133, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Nome do Cliente";
            // 
            // tbxNome
            // 
            this.tbxNome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbxNome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxNome.Location = new System.Drawing.Point(133, 31);
            this.tbxNome.Name = "tbxNome";
            this.tbxNome.Size = new System.Drawing.Size(224, 20);
            this.tbxNome.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(490, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Data Entrada";
            // 
            // dtpDataEntrada
            // 
            this.dtpDataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntrada.Location = new System.Drawing.Point(490, 32);
            this.dtpDataEntrada.Name = "dtpDataEntrada";
            this.dtpDataEntrada.Size = new System.Drawing.Size(121, 20);
            this.dtpDataEntrada.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 15);
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
            "Aprovado",
            "Entregue"});
            this.cbxStatus.Location = new System.Drawing.Point(363, 30);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(121, 21);
            this.cbxStatus.TabIndex = 18;
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
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "KitUpgrade",
            "PC",
            "Produto"});
            this.cbxTipo.Location = new System.Drawing.Point(6, 31);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(121, 21);
            this.cbxTipo.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.btnAtualizar);
            this.panel2.Controls.Add(this.btnLoadAgenda);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnSalvar);
            this.panel2.Controls.Add(this.btnAdicionar);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 460);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 38);
            this.panel2.TabIndex = 11;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAtualizar.Enabled = false;
            this.btnAtualizar.Location = new System.Drawing.Point(526, 9);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(118, 23);
            this.btnAtualizar.TabIndex = 30;
            this.btnAtualizar.Text = "Aplicar Modificações";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnLoadAgenda
            // 
            this.btnLoadAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadAgenda.Location = new System.Drawing.Point(5, 9);
            this.btnLoadAgenda.Name = "btnLoadAgenda";
            this.btnLoadAgenda.Size = new System.Drawing.Size(108, 23);
            this.btnLoadAgenda.TabIndex = 12;
            this.btnLoadAgenda.Text = "Abrir Arquivo";
            this.btnLoadAgenda.UseVisualStyleBackColor = true;
            this.btnLoadAgenda.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(135, 14);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(132, 13);
            this.label21.TabIndex = 29;
            this.label21.Text = "Remove itens expirados ->";
            this.label21.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(273, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Remover Concluídos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(804, 9);
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
            this.btnAdicionar.Location = new System.Drawing.Point(397, 9);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(118, 23);
            this.btnAdicionar.TabIndex = 9;
            this.btnAdicionar.Text = "Criar Orçamento";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(928, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "<- Salva quaisquer alterações feitas.";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 525);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "<- Carrega para editar.";
            // 
            // frmControledeOrcamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 527);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmControledeOrcamentos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Orçamentos";
            this.Load += new System.EventHandler(this.frmClientControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdit)).EndInit();
            this.gbxCadastro.ResumeLayout(false);
            this.gbxCadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParc)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DataGridView dgvEdit;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.MaskedTextBox tbxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxNome;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox tbxNOrdem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpDataVal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox tbxValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox tbxParcela1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbxPagamento;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.MaskedTextBox tbxParcela3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox tbxParcela2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tbx1Entrada;
        private System.Windows.Forms.Button btnCalcularPar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numParc;
        private System.Windows.Forms.Label label20;
    }
}