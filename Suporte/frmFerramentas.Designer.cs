namespace Suporte
{
    partial class frmFerramentas
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkbxma = new System.Windows.Forms.CheckBox();
            this.chkbxdma = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOrgSelectFolder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxorgdata = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxorgext = new System.Windows.Forms.ComboBox();
            this.btnOrgStart = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.tbxOrgSelectedFolder = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAbrirCaminho = new System.Windows.Forms.Button();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciarAlterar = new System.Windows.Forms.Button();
            this.cbxExtensao = new System.Windows.Forms.ComboBox();
            this.ExtListView = new System.Windows.Forms.ListView();
            this.btnProcurarDir = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.autoDesligarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avançadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 312);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 18);
            this.panel2.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btnOrgSelectFolder);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cbxorgdata);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cbxorgext);
            this.tabPage2.Controls.Add(this.btnOrgStart);
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Controls.Add(this.tbxOrgSelectedFolder);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(670, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Organizar Arquivos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkbxma);
            this.groupBox1.Controls.Add(this.chkbxdma);
            this.groupBox1.Location = new System.Drawing.Point(506, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 66);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Método ao criar pastas:";
            // 
            // chkbxma
            // 
            this.chkbxma.AutoSize = true;
            this.chkbxma.Location = new System.Drawing.Point(6, 39);
            this.chkbxma.Name = "chkbxma";
            this.chkbxma.Size = new System.Drawing.Size(128, 17);
            this.chkbxma.TabIndex = 11;
            this.chkbxma.Text = "Arquivar por mês/ano";
            this.chkbxma.UseVisualStyleBackColor = true;
            this.chkbxma.CheckStateChanged += new System.EventHandler(this.chkbxma_CheckStateChanged);
            // 
            // chkbxdma
            // 
            this.chkbxdma.AutoSize = true;
            this.chkbxdma.Checked = true;
            this.chkbxdma.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxdma.Location = new System.Drawing.Point(6, 20);
            this.chkbxdma.Name = "chkbxdma";
            this.chkbxdma.Size = new System.Drawing.Size(147, 17);
            this.chkbxdma.TabIndex = 10;
            this.chkbxdma.Text = "Arquivar por dia/mês/ano";
            this.chkbxdma.UseVisualStyleBackColor = true;
            this.chkbxdma.CheckStateChanged += new System.EventHandler(this.chkbxdma_CheckStateChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(472, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "*Organiza os arquivos pela data selecionada no \"mais antigo que\", colocando-os na" +
    " pasta datada.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Selecionar pasta.";
            // 
            // btnOrgSelectFolder
            // 
            this.btnOrgSelectFolder.Location = new System.Drawing.Point(162, 37);
            this.btnOrgSelectFolder.Name = "btnOrgSelectFolder";
            this.btnOrgSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOrgSelectFolder.TabIndex = 10;
            this.btnOrgSelectFolder.Text = "Procurar...";
            this.btnOrgSelectFolder.UseVisualStyleBackColor = true;
            this.btnOrgSelectFolder.Click += new System.EventHandler(this.btnOrgSelectFolder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Mais antigo que:";
            // 
            // cbxorgdata
            // 
            this.cbxorgdata.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxorgdata.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxorgdata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxorgdata.FormattingEnabled = true;
            this.cbxorgdata.Items.AddRange(new object[] {
            "2 Meses",
            "4 Meses",
            "6 Meses",
            "10 Meses",
            "1 Ano"});
            this.cbxorgdata.Location = new System.Drawing.Point(248, 39);
            this.cbxorgdata.Name = "cbxorgdata";
            this.cbxorgdata.Size = new System.Drawing.Size(115, 21);
            this.cbxorgdata.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 26);
            this.label5.TabIndex = 16;
            this.label5.Text = "Selecionar o tipo de arquivo \r\na ser alterado.";
            // 
            // cbxorgext
            // 
            this.cbxorgext.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxorgext.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxorgext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxorgext.FormattingEnabled = true;
            this.cbxorgext.Items.AddRange(new object[] {
            ".prproj",
            ".aep",
            ".psd",
            ".jpg",
            ".png",
            ".avi",
            ".mov",
            ".mpg",
            ".flv",
            ".mp4",
            ".m4v"});
            this.cbxorgext.Location = new System.Drawing.Point(21, 39);
            this.cbxorgext.Name = "cbxorgext";
            this.cbxorgext.Size = new System.Drawing.Size(130, 21);
            this.cbxorgext.TabIndex = 15;
            // 
            // btnOrgStart
            // 
            this.btnOrgStart.Location = new System.Drawing.Point(374, 37);
            this.btnOrgStart.Name = "btnOrgStart";
            this.btnOrgStart.Size = new System.Drawing.Size(115, 23);
            this.btnOrgStart.TabIndex = 14;
            this.btnOrgStart.Text = "Iniciar";
            this.btnOrgStart.UseVisualStyleBackColor = true;
            this.btnOrgStart.Click += new System.EventHandler(this.btnOrgStart_Click);
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.Location = new System.Drawing.Point(16, 95);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(639, 146);
            this.listView2.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView2.TabIndex = 13;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            // 
            // tbxOrgSelectedFolder
            // 
            this.tbxOrgSelectedFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxOrgSelectedFolder.Location = new System.Drawing.Point(21, 69);
            this.tbxOrgSelectedFolder.Name = "tbxOrgSelectedFolder";
            this.tbxOrgSelectedFolder.ReadOnly = true;
            this.tbxOrgSelectedFolder.Size = new System.Drawing.Size(483, 20);
            this.tbxOrgSelectedFolder.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAbrirCaminho);
            this.tabPage1.Controls.Add(this.tbxPath);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnIniciarAlterar);
            this.tabPage1.Controls.Add(this.cbxExtensao);
            this.tabPage1.Controls.Add(this.ExtListView);
            this.tabPage1.Controls.Add(this.btnProcurarDir);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(670, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Alterar Extensão";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAbrirCaminho
            // 
            this.btnAbrirCaminho.Location = new System.Drawing.Point(587, 66);
            this.btnAbrirCaminho.Name = "btnAbrirCaminho";
            this.btnAbrirCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnAbrirCaminho.TabIndex = 10;
            this.btnAbrirCaminho.Text = "Abrir Direto";
            this.btnAbrirCaminho.UseVisualStyleBackColor = true;
            this.btnAbrirCaminho.Click += new System.EventHandler(this.btnAbrirCaminho_Click);
            // 
            // tbxPath
            // 
            this.tbxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPath.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbxPath.Location = new System.Drawing.Point(9, 68);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(572, 20);
            this.tbxPath.TabIndex = 9;
            this.tbxPath.Text = "(busque ou cole o caminho da pasta aqui.)";
            this.tbxPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbxPath_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Alterar extensões.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Selecionar a nova extensão.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Selecionar pasta.";
            // 
            // btnIniciarAlterar
            // 
            this.btnIniciarAlterar.Location = new System.Drawing.Point(471, 37);
            this.btnIniciarAlterar.Name = "btnIniciarAlterar";
            this.btnIniciarAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciarAlterar.TabIndex = 5;
            this.btnIniciarAlterar.Text = "Iniciar";
            this.btnIniciarAlterar.UseVisualStyleBackColor = true;
            this.btnIniciarAlterar.Click += new System.EventHandler(this.btnIniciarAlterar_Click);
            // 
            // cbxExtensao
            // 
            this.cbxExtensao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxExtensao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxExtensao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExtensao.FormattingEnabled = true;
            this.cbxExtensao.Items.AddRange(new object[] {
            ".mov",
            ".mpg",
            ".mp4",
            ".m4v",
            ".m2t"});
            this.cbxExtensao.Location = new System.Drawing.Point(284, 39);
            this.cbxExtensao.Name = "cbxExtensao";
            this.cbxExtensao.Size = new System.Drawing.Size(75, 21);
            this.cbxExtensao.TabIndex = 3;
            // 
            // ExtListView
            // 
            this.ExtListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ExtListView.Location = new System.Drawing.Point(9, 94);
            this.ExtListView.MultiSelect = false;
            this.ExtListView.Name = "ExtListView";
            this.ExtListView.Size = new System.Drawing.Size(653, 163);
            this.ExtListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ExtListView.TabIndex = 2;
            this.ExtListView.UseCompatibleStateImageBehavior = false;
            this.ExtListView.View = System.Windows.Forms.View.List;
            // 
            // btnProcurarDir
            // 
            this.btnProcurarDir.Location = new System.Drawing.Point(99, 37);
            this.btnProcurarDir.Name = "btnProcurarDir";
            this.btnProcurarDir.Size = new System.Drawing.Size(75, 23);
            this.btnProcurarDir.TabIndex = 0;
            this.btnProcurarDir.Text = "Procurar...";
            this.btnProcurarDir.UseVisualStyleBackColor = true;
            this.btnProcurarDir.Click += new System.EventHandler(this.btnProcurarDir_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(678, 288);
            this.tabControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoDesligarToolStripMenuItem,
            this.uSBScanToolStripMenuItem,
            this.avançadoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(678, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // autoDesligarToolStripMenuItem
            // 
            this.autoDesligarToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.autoDesligarToolStripMenuItem.Name = "autoDesligarToolStripMenuItem";
            this.autoDesligarToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.autoDesligarToolStripMenuItem.Text = "Auto Desligar";
            this.autoDesligarToolStripMenuItem.Click += new System.EventHandler(this.autoDesligarToolStripMenuItem_Click);
            // 
            // uSBScanToolStripMenuItem
            // 
            this.uSBScanToolStripMenuItem.Name = "uSBScanToolStripMenuItem";
            this.uSBScanToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.uSBScanToolStripMenuItem.Text = "USB Scan";
            this.uSBScanToolStripMenuItem.Click += new System.EventHandler(this.uSBScanToolStripMenuItem_Click);
            // 
            // avançadoToolStripMenuItem
            // 
            this.avançadoToolStripMenuItem.Name = "avançadoToolStripMenuItem";
            this.avançadoToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.avançadoToolStripMenuItem.Text = "Avançado";
            this.avançadoToolStripMenuItem.Click += new System.EventHandler(this.avançadoToolStripMenuItem_Click);
            // 
            // frmFerramentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(678, 330);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFerramentas";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ferramentas";
            this.Load += new System.EventHandler(this.frmFileTools_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkbxma;
        private System.Windows.Forms.CheckBox chkbxdma;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOrgSelectFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxorgdata;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxorgext;
        private System.Windows.Forms.Button btnOrgStart;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.TextBox tbxOrgSelectedFolder;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciarAlterar;
        private System.Windows.Forms.ComboBox cbxExtensao;
        private System.Windows.Forms.ListView ExtListView;
        private System.Windows.Forms.Button btnProcurarDir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem autoDesligarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSBScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avançadoToolStripMenuItem;
        private System.Windows.Forms.Button btnAbrirCaminho;
    }
}