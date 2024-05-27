namespace Suporte
{
    partial class frmAgEventos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxViewMes = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxViewTipo = new System.Windows.Forms.ComboBox();
            this.dgvAgenda = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLoadAgenda = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpHour = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHoras = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxServico = new System.Windows.Forms.RichTextBox();
            this.lblContratante = new System.Windows.Forms.Label();
            this.tbxContratante = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxLocalXML = new System.Windows.Forms.TextBox();
            this.dgvEdit = new System.Windows.Forms.DataGridView();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterarLocal = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgenda)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 17);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 17);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(961, 617);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.dgvAgenda);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(953, 591);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agenda";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Location = new System.Drawing.Point(3, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(947, 18);
            this.panel3.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbxViewMes);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbxViewTipo);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 68);
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
            // cbxViewMes
            // 
            this.cbxViewMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxViewMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxViewMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxViewMes.FormattingEnabled = true;
            this.cbxViewMes.Items.AddRange(new object[] {
            "Todos",
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.cbxViewMes.Location = new System.Drawing.Point(8, 32);
            this.cbxViewMes.Name = "cbxViewMes";
            this.cbxViewMes.Size = new System.Drawing.Size(121, 21);
            this.cbxViewMes.TabIndex = 8;
            this.cbxViewMes.SelectionChangeCommitted += new System.EventHandler(this.cbxMes_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Por Mês";
            // 
            // cbxViewTipo
            // 
            this.cbxViewTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxViewTipo.FormattingEnabled = true;
            this.cbxViewTipo.Items.AddRange(new object[] {
            "Todos",
            "Formatura",
            "Casamento",
            "15 Anos",
            "1 Aninho",
            "Book",
            "Outro"});
            this.cbxViewTipo.Location = new System.Drawing.Point(135, 32);
            this.cbxViewTipo.Name = "cbxViewTipo";
            this.cbxViewTipo.Size = new System.Drawing.Size(121, 21);
            this.cbxViewTipo.TabIndex = 9;
            this.cbxViewTipo.SelectionChangeCommitted += new System.EventHandler(this.cbxTipo_SelectionChangeCommitted);
            // 
            // dgvAgenda
            // 
            this.dgvAgenda.AllowUserToAddRows = false;
            this.dgvAgenda.AllowUserToDeleteRows = false;
            this.dgvAgenda.AllowUserToOrderColumns = true;
            this.dgvAgenda.AllowUserToResizeColumns = false;
            this.dgvAgenda.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAgenda.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAgenda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAgenda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgenda.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAgenda.Location = new System.Drawing.Point(3, 97);
            this.dgvAgenda.Name = "dgvAgenda";
            this.dgvAgenda.ReadOnly = true;
            this.dgvAgenda.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvAgenda.Size = new System.Drawing.Size(947, 491);
            this.dgvAgenda.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAplicar);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnLoadAgenda);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.btnAdicionar);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.tbxLocalXML);
            this.tabPage2.Controls.Add(this.dgvEdit);
            this.tabPage2.Controls.Add(this.btnSalvar);
            this.tabPage2.Controls.Add(this.btnAlterarLocal);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(953, 591);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Agendar/Alterar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAplicar.Enabled = false;
            this.btnAplicar.Location = new System.Drawing.Point(130, 546);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(118, 23);
            this.btnAplicar.TabIndex = 28;
            this.btnAplicar.Text = "Aplicar Alterações";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "<- Carrega a Agenda para editar.";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(714, 551);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(233, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "<- Salva quaisquer alterações feitas na Agenda.";
            // 
            // btnLoadAgenda
            // 
            this.btnLoadAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadAgenda.Location = new System.Drawing.Point(8, 393);
            this.btnLoadAgenda.Name = "btnLoadAgenda";
            this.btnLoadAgenda.Size = new System.Drawing.Size(166, 23);
            this.btnLoadAgenda.TabIndex = 12;
            this.btnLoadAgenda.Text = "Abrir Agenda";
            this.btnLoadAgenda.UseVisualStyleBackColor = true;
            this.btnLoadAgenda.Click += new System.EventHandler(this.btnLoadAgenda_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 571);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(947, 17);
            this.panel2.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpHour);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblHoras);
            this.groupBox1.Controls.Add(this.dtpData);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxStatus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbxTipo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxServico);
            this.groupBox1.Controls.Add(this.lblContratante);
            this.groupBox1.Controls.Add(this.tbxContratante);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(8, 422);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(931, 118);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adicionar Dados";
            // 
            // dtpHour
            // 
            this.dtpHour.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHour.Location = new System.Drawing.Point(136, 84);
            this.dtpHour.Name = "dtpHour";
            this.dtpHour.ShowUpDown = true;
            this.dtpHour.Size = new System.Drawing.Size(97, 20);
            this.dtpHour.TabIndex = 26;
            this.dtpHour.Value = new System.DateTime(2014, 1, 1, 13, 44, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Data do Evento";
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Location = new System.Drawing.Point(136, 68);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(30, 13);
            this.lblHoras.TabIndex = 24;
            this.lblHoras.Text = "Hora";
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(9, 84);
            this.dtpData.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(121, 20);
            this.dtpData.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Status";
            // 
            // cbxStatus
            // 
            this.cbxStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
            "Concluído",
            "Agendado"});
            this.cbxStatus.Location = new System.Drawing.Point(239, 84);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(121, 21);
            this.cbxStatus.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tipo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 16;
            // 
            // cbxTipo
            // 
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "Formatura",
            "Casamento",
            "15 Anos",
            "1 Aninho",
            "Book",
            "Outro"});
            this.cbxTipo.Location = new System.Drawing.Point(239, 39);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(121, 21);
            this.cbxTipo.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Informações";
            // 
            // tbxServico
            // 
            this.tbxServico.Location = new System.Drawing.Point(377, 40);
            this.tbxServico.Name = "tbxServico";
            this.tbxServico.Size = new System.Drawing.Size(548, 65);
            this.tbxServico.TabIndex = 12;
            this.tbxServico.Text = "";
            // 
            // lblContratante
            // 
            this.lblContratante.AutoSize = true;
            this.lblContratante.Location = new System.Drawing.Point(6, 23);
            this.lblContratante.Name = "lblContratante";
            this.lblContratante.Size = new System.Drawing.Size(62, 13);
            this.lblContratante.TabIndex = 9;
            this.lblContratante.Text = "Contratante";
            // 
            // tbxContratante
            // 
            this.tbxContratante.Location = new System.Drawing.Point(9, 40);
            this.tbxContratante.Name = "tbxContratante";
            this.tbxContratante.Size = new System.Drawing.Size(224, 20);
            this.tbxContratante.TabIndex = 9;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdicionar.Location = new System.Drawing.Point(6, 546);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(118, 23);
            this.btnAdicionar.TabIndex = 9;
            this.btnAdicionar.Text = "Adicionar Evento";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(601, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Alterar local padrão do arquivo:";
            // 
            // tbxLocalXML
            // 
            this.tbxLocalXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLocalXML.Location = new System.Drawing.Point(601, 396);
            this.tbxLocalXML.Name = "tbxLocalXML";
            this.tbxLocalXML.Size = new System.Drawing.Size(338, 20);
            this.tbxLocalXML.TabIndex = 8;
            // 
            // dgvEdit
            // 
            this.dgvEdit.AllowUserToResizeColumns = false;
            this.dgvEdit.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEdit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEdit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEdit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEdit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEdit.Location = new System.Drawing.Point(3, 3);
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEdit.Size = new System.Drawing.Size(947, 374);
            this.dgvEdit.TabIndex = 6;
            this.dgvEdit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvEdit_MouseClick);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(590, 546);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(118, 23);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "Salvar Alterações";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAlterarLocal
            // 
            this.btnAlterarLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterarLocal.Location = new System.Drawing.Point(520, 394);
            this.btnAlterarLocal.Name = "btnAlterarLocal";
            this.btnAlterarLocal.Size = new System.Drawing.Size(75, 23);
            this.btnAlterarLocal.TabIndex = 7;
            this.btnAlterarLocal.Text = "Alterar...";
            this.btnAlterarLocal.UseVisualStyleBackColor = true;
            this.btnAlterarLocal.Click += new System.EventHandler(this.btnAlterarLocal_Click);
            // 
            // frmAgEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 634);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frmAgEventos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agendamentos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAgenda_FormClosed);
            this.Load += new System.EventHandler(this.frmAgenda_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgenda)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxLocalXML;
        private System.Windows.Forms.DataGridView dgvEdit;
        private System.Windows.Forms.Button btnAlterarLocal;
        private System.Windows.Forms.DataGridView dgvAgenda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox tbxServico;
        private System.Windows.Forms.Label lblContratante;
        private System.Windows.Forms.TextBox tbxContratante;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxViewMes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxViewTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadAgenda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpHour;
        private System.Windows.Forms.Button btnAplicar;
    }
}