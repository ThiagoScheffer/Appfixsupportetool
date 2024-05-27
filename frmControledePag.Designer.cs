namespace Suporte
{
    partial class frmControledePag
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCarregarGrid = new System.Windows.Forms.Button();
            this.tbxLocalXML = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.chkbxPerStatus = new System.Windows.Forms.CheckBox();
            this.chkbxFilterbyName = new System.Windows.Forms.CheckBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxValorRestante = new System.Windows.Forms.MaskedTextBox();
            this.tbxValores = new System.Windows.Forms.MaskedTextBox();
            this.lblValores = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxValorPago = new System.Windows.Forms.MaskedTextBox();
            this.btnConverter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxValor = new System.Windows.Forms.MaskedTextBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxPC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.cbxAno = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxServico = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(958, 483);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // btnCarregarGrid
            // 
            this.btnCarregarGrid.Location = new System.Drawing.Point(3, 6);
            this.btnCarregarGrid.Name = "btnCarregarGrid";
            this.btnCarregarGrid.Size = new System.Drawing.Size(126, 23);
            this.btnCarregarGrid.TabIndex = 2;
            this.btnCarregarGrid.Text = "Carregar DataGrid...";
            this.btnCarregarGrid.UseVisualStyleBackColor = true;
            this.btnCarregarGrid.Click += new System.EventHandler(this.btnCarregarGrid_Click);
            // 
            // tbxLocalXML
            // 
            this.tbxLocalXML.Location = new System.Drawing.Point(3, 35);
            this.tbxLocalXML.Name = "tbxLocalXML";
            this.tbxLocalXML.Size = new System.Drawing.Size(546, 20);
            this.tbxLocalXML.TabIndex = 3;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(837, 18);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(118, 23);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "Salvar Tudo";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.btnAplicar);
            this.panel1.Controls.Add(this.chkbxPerStatus);
            this.panel1.Controls.Add(this.tbxLocalXML);
            this.panel1.Controls.Add(this.chkbxFilterbyName);
            this.panel1.Controls.Add(this.btnAdicionar);
            this.panel1.Controls.Add(this.btnCarregarGrid);
            this.panel1.Controls.Add(this.cbxFilter);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 649);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 58);
            this.panel1.TabIndex = 6;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicar.Location = new System.Drawing.Point(589, 18);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(118, 23);
            this.btnAplicar.TabIndex = 25;
            this.btnAplicar.Text = "Aplicar Alterações";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // chkbxPerStatus
            // 
            this.chkbxPerStatus.AutoSize = true;
            this.chkbxPerStatus.Location = new System.Drawing.Point(393, 9);
            this.chkbxPerStatus.Name = "chkbxPerStatus";
            this.chkbxPerStatus.Size = new System.Drawing.Size(156, 17);
            this.chkbxPerStatus.TabIndex = 11;
            this.chkbxPerStatus.Text = "Ativar Filtrar por Pagamento";
            this.chkbxPerStatus.UseVisualStyleBackColor = true;
            this.chkbxPerStatus.CheckStateChanged += new System.EventHandler(this.chkbxPerStatus_CheckStateChanged);
            // 
            // chkbxFilterbyName
            // 
            this.chkbxFilterbyName.AutoSize = true;
            this.chkbxFilterbyName.Location = new System.Drawing.Point(263, 9);
            this.chkbxFilterbyName.Name = "chkbxFilterbyName";
            this.chkbxFilterbyName.Size = new System.Drawing.Size(130, 17);
            this.chkbxFilterbyName.TabIndex = 10;
            this.chkbxFilterbyName.Text = "Ativar Filtrar por Nome";
            this.chkbxFilterbyName.UseVisualStyleBackColor = true;
            this.chkbxFilterbyName.CheckStateChanged += new System.EventHandler(this.chkbxFilterbyName_CheckStateChanged);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.Location = new System.Drawing.Point(713, 18);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(118, 23);
            this.btnAdicionar.TabIndex = 9;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // cbxFilter
            // 
            this.cbxFilter.Enabled = false;
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Location = new System.Drawing.Point(135, 6);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(121, 21);
            this.cbxFilter.Sorted = true;
            this.cbxFilter.TabIndex = 9;
            this.cbxFilter.SelectedIndexChanged += new System.EventHandler(this.cbxFilterNames_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbxValorRestante);
            this.groupBox1.Controls.Add(this.tbxValores);
            this.groupBox1.Controls.Add(this.lblValores);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxValorPago);
            this.groupBox1.Controls.Add(this.btnConverter);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbxValor);
            this.groupBox1.Controls.Add(this.dtpData);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbxPC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxStatus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbxTipo);
            this.groupBox1.Controls.Add(this.cbxAno);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxServico);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxCliente);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 494);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 155);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adicionar Dados";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(166, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Valor Restante";
            // 
            // tbxValorRestante
            // 
            this.tbxValorRestante.AllowPromptAsInput = false;
            this.tbxValorRestante.Location = new System.Drawing.Point(168, 122);
            this.tbxValorRestante.Name = "tbxValorRestante";
            this.tbxValorRestante.Size = new System.Drawing.Size(75, 20);
            this.tbxValorRestante.TabIndex = 31;
            // 
            // tbxValores
            // 
            this.tbxValores.AllowPromptAsInput = false;
            this.tbxValores.Location = new System.Drawing.Point(366, 122);
            this.tbxValores.Name = "tbxValores";
            this.tbxValores.Size = new System.Drawing.Size(128, 20);
            this.tbxValores.TabIndex = 30;
            // 
            // lblValores
            // 
            this.lblValores.AutoSize = true;
            this.lblValores.Location = new System.Drawing.Point(363, 106);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(31, 13);
            this.lblValores.TabIndex = 29;
            this.lblValores.Text = "Total";
            this.lblValores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Valor Pago";
            // 
            // tbxValorPago
            // 
            this.tbxValorPago.AllowPromptAsInput = false;
            this.tbxValorPago.Location = new System.Drawing.Point(87, 122);
            this.tbxValorPago.Name = "tbxValorPago";
            this.tbxValorPago.Size = new System.Drawing.Size(75, 20);
            this.tbxValorPago.TabIndex = 27;
            this.tbxValorPago.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // btnConverter
            // 
            this.btnConverter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConverter.Enabled = false;
            this.btnConverter.Location = new System.Drawing.Point(807, 13);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(118, 23);
            this.btnConverter.TabIndex = 26;
            this.btnConverter.Text = "Converter";
            this.btnConverter.UseVisualStyleBackColor = true;
            this.btnConverter.Visible = false;
            this.btnConverter.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Valor";
            // 
            // tbxValor
            // 
            this.tbxValor.AllowPromptAsInput = false;
            this.tbxValor.Location = new System.Drawing.Point(6, 122);
            this.tbxValor.Name = "tbxValor";
            this.tbxValor.Size = new System.Drawing.Size(75, 20);
            this.tbxValor.TabIndex = 23;
            this.tbxValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxValor_KeyPress);
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(366, 84);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(121, 20);
            this.dtpData.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "PC";
            // 
            // tbxPC
            // 
            this.tbxPC.Location = new System.Drawing.Point(9, 83);
            this.tbxPC.Name = "tbxPC";
            this.tbxPC.Size = new System.Drawing.Size(224, 20);
            this.tbxPC.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 67);
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
            "Pago",
            "Não Pago"});
            this.cbxStatus.Location = new System.Drawing.Point(239, 83);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(121, 21);
            this.cbxStatus.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 23);
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
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Ano";
            // 
            // cbxTipo
            // 
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "Venda",
            "Remoto",
            "Atendimento",
            "Serviço"});
            this.cbxTipo.Location = new System.Drawing.Point(366, 39);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(121, 21);
            this.cbxTipo.TabIndex = 15;
            // 
            // cbxAno
            // 
            this.cbxAno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxAno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAno.FormattingEnabled = true;
            this.cbxAno.Location = new System.Drawing.Point(239, 39);
            this.cbxAno.Name = "cbxAno";
            this.cbxAno.Size = new System.Drawing.Size(121, 21);
            this.cbxAno.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(528, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Serviço";
            // 
            // tbxServico
            // 
            this.tbxServico.Location = new System.Drawing.Point(531, 39);
            this.tbxServico.Name = "tbxServico";
            this.tbxServico.Size = new System.Drawing.Size(394, 103);
            this.tbxServico.TabIndex = 12;
            this.tbxServico.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cliente/Empresa";
            // 
            // tbxCliente
            // 
            this.tbxCliente.Location = new System.Drawing.Point(9, 40);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(224, 20);
            this.tbxCliente.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 483);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(958, 11);
            this.panel2.TabIndex = 8;
            // 
            // frmControledePag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 707);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "frmControledePag";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle dos Pagamentos";
            this.Load += new System.EventHandler(this.frmAdmPag_Load);
            this.Resize += new System.EventHandler(this.frmControledePag_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCarregarGrid;
        private System.Windows.Forms.TextBox tbxLocalXML;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox tbxServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.ComboBox cbxAno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxPC;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox tbxValor;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.CheckBox chkbxFilterbyName;
        private System.Windows.Forms.CheckBox chkbxPerStatus;
        private System.Windows.Forms.Button btnConverter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox tbxValorPago;
        private System.Windows.Forms.MaskedTextBox tbxValores;
        private System.Windows.Forms.Label lblValores;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox tbxValorRestante;
    }
}