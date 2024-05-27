namespace Suporte
{
    partial class frmUsuario
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuario));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnControleClientes = new System.Windows.Forms.Button();
            this.btnSuporte = new System.Windows.Forms.Button();
            this.btnAtivar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnBanner = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxVer = new System.Windows.Forms.Label();
            this.lblFixtec = new System.Windows.Forms.Label();
            this.btnInfoSistema = new System.Windows.Forms.Button();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.tbxContato = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRunCCleaner = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlBARBACK = new System.Windows.Forms.Panel();
            this.pnlMeterBar = new System.Windows.Forms.Panel();
            this.chkbxAlterado = new System.Windows.Forms.CheckBox();
            this.chkbxDanificado = new System.Windows.Forms.CheckBox();
            this.chkbxComprometido = new System.Windows.Forms.CheckBox();
            this.btClose = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.btnTermos = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoDesligarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gravadorDePassosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxAvisos = new System.Windows.Forms.TextBox();
            this.pnBanner.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlBARBACK.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 255);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(460, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnControleClientes
            // 
            this.btnControleClientes.Location = new System.Drawing.Point(303, 101);
            this.btnControleClientes.Name = "btnControleClientes";
            this.btnControleClientes.Size = new System.Drawing.Size(143, 23);
            this.btnControleClientes.TabIndex = 2;
            this.btnControleClientes.Text = "Painel do Cliente";
            this.btnControleClientes.UseVisualStyleBackColor = true;
            this.btnControleClientes.Click += new System.EventHandler(this.btnControleClientes_Click);
            // 
            // btnSuporte
            // 
            this.btnSuporte.Location = new System.Drawing.Point(303, 159);
            this.btnSuporte.Name = "btnSuporte";
            this.btnSuporte.Size = new System.Drawing.Size(143, 23);
            this.btnSuporte.TabIndex = 3;
            this.btnSuporte.Text = "Email e Suporte remoto";
            this.btnSuporte.UseVisualStyleBackColor = true;
            this.btnSuporte.Click += new System.EventHandler(this.btnSuporte_Click);
            // 
            // btnAtivar
            // 
            this.btnAtivar.Enabled = false;
            this.btnAtivar.Location = new System.Drawing.Point(303, 215);
            this.btnAtivar.Name = "btnAtivar";
            this.btnAtivar.Size = new System.Drawing.Size(143, 23);
            this.btnAtivar.TabIndex = 4;
            this.btnAtivar.Text = "Sistema";
            this.btnAtivar.UseVisualStyleBackColor = true;
            this.btnAtivar.Click += new System.EventHandler(this.btnAtivar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 245);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 10);
            this.panel1.TabIndex = 5;
            // 
            // pnBanner
            // 
            this.pnBanner.BackColor = System.Drawing.Color.SteelBlue;
            this.pnBanner.Controls.Add(this.panel4);
            this.pnBanner.Controls.Add(this.label2);
            this.pnBanner.Controls.Add(this.panel2);
            this.pnBanner.Controls.Add(this.tbxVer);
            this.pnBanner.Controls.Add(this.lblFixtec);
            this.pnBanner.Location = new System.Drawing.Point(0, 24);
            this.pnBanner.Name = "pnBanner";
            this.pnBanner.Size = new System.Drawing.Size(458, 71);
            this.pnBanner.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel4.Location = new System.Drawing.Point(0, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(458, 5);
            this.panel4.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(306, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Central de Suporte";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Suporte.Properties.Resources.TransAppLogo;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(7, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(66, 61);
            this.panel2.TabIndex = 13;
            // 
            // tbxVer
            // 
            this.tbxVer.AutoSize = true;
            this.tbxVer.ForeColor = System.Drawing.Color.White;
            this.tbxVer.Location = new System.Drawing.Point(393, 48);
            this.tbxVer.Name = "tbxVer";
            this.tbxVer.Size = new System.Drawing.Size(40, 13);
            this.tbxVer.TabIndex = 2;
            this.tbxVer.Text = "Versão";
            // 
            // lblFixtec
            // 
            this.lblFixtec.AutoSize = true;
            this.lblFixtec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixtec.ForeColor = System.Drawing.Color.White;
            this.lblFixtec.Location = new System.Drawing.Point(68, 22);
            this.lblFixtec.Name = "lblFixtec";
            this.lblFixtec.Size = new System.Drawing.Size(149, 24);
            this.lblFixtec.TabIndex = 1;
            this.lblFixtec.Text = "FIX Tecnologias";
            // 
            // btnInfoSistema
            // 
            this.btnInfoSistema.Location = new System.Drawing.Point(303, 130);
            this.btnInfoSistema.Name = "btnInfoSistema";
            this.btnInfoSistema.Size = new System.Drawing.Size(143, 23);
            this.btnInfoSistema.TabIndex = 8;
            this.btnInfoSistema.Text = "Informações do sistema";
            this.btnInfoSistema.UseVisualStyleBackColor = true;
            this.btnInfoSistema.Click += new System.EventHandler(this.btnInfoSistema_Click);
            // 
            // tbxInfo
            // 
            this.tbxInfo.BackColor = System.Drawing.Color.White;
            this.tbxInfo.Enabled = false;
            this.tbxInfo.ForeColor = System.Drawing.Color.Black;
            this.tbxInfo.Location = new System.Drawing.Point(7, 256);
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.ReadOnly = true;
            this.tbxInfo.Size = new System.Drawing.Size(149, 20);
            this.tbxInfo.TabIndex = 10;
            this.tbxInfo.Text = "Informações";
            this.tbxInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxContato
            // 
            this.tbxContato.BackColor = System.Drawing.Color.White;
            this.tbxContato.Enabled = false;
            this.tbxContato.Location = new System.Drawing.Point(162, 256);
            this.tbxContato.Name = "tbxContato";
            this.tbxContato.ReadOnly = true;
            this.tbxContato.Size = new System.Drawing.Size(288, 20);
            this.tbxContato.TabIndex = 11;
            this.tbxContato.Text = "fix.tecnologias@outlook.com - (55) 996952571";
            this.tbxContato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Central de Suporte";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnRunCCleaner);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pnlBARBACK);
            this.groupBox1.Controls.Add(this.chkbxAlterado);
            this.groupBox1.Controls.Add(this.chkbxDanificado);
            this.groupBox1.Controls.Add(this.chkbxComprometido);
            this.groupBox1.Location = new System.Drawing.Point(7, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 109);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Integridade do Sistema";
            // 
            // btnRunCCleaner
            // 
            this.btnRunCCleaner.Location = new System.Drawing.Point(157, 74);
            this.btnRunCCleaner.Name = "btnRunCCleaner";
            this.btnRunCCleaner.Size = new System.Drawing.Size(106, 19);
            this.btnRunCCleaner.TabIndex = 20;
            this.btnRunCCleaner.Text = "Limpar";
            this.btnRunCCleaner.UseCompatibleTextRendering = true;
            this.btnRunCCleaner.UseVisualStyleBackColor = true;
            this.btnRunCCleaner.Click += new System.EventHandler(this.btnRunCCleaner_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Caches e Temporários";
            // 
            // pnlBARBACK
            // 
            this.pnlBARBACK.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBARBACK.Controls.Add(this.pnlMeterBar);
            this.pnlBARBACK.Location = new System.Drawing.Point(6, 74);
            this.pnlBARBACK.Name = "pnlBARBACK";
            this.pnlBARBACK.Size = new System.Drawing.Size(145, 19);
            this.pnlBARBACK.TabIndex = 15;
            // 
            // pnlMeterBar
            // 
            this.pnlMeterBar.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlMeterBar.Location = new System.Drawing.Point(3, 3);
            this.pnlMeterBar.Name = "pnlMeterBar";
            this.pnlMeterBar.Size = new System.Drawing.Size(5, 13);
            this.pnlMeterBar.TabIndex = 16;
            // 
            // chkbxAlterado
            // 
            this.chkbxAlterado.AutoSize = true;
            this.chkbxAlterado.Enabled = false;
            this.chkbxAlterado.Location = new System.Drawing.Point(14, 19);
            this.chkbxAlterado.Name = "chkbxAlterado";
            this.chkbxAlterado.Size = new System.Drawing.Size(65, 17);
            this.chkbxAlterado.TabIndex = 3;
            this.chkbxAlterado.Text = "Alterado";
            this.chkbxAlterado.UseVisualStyleBackColor = true;
            // 
            // chkbxDanificado
            // 
            this.chkbxDanificado.AutoSize = true;
            this.chkbxDanificado.Enabled = false;
            this.chkbxDanificado.Location = new System.Drawing.Point(86, 19);
            this.chkbxDanificado.Name = "chkbxDanificado";
            this.chkbxDanificado.Size = new System.Drawing.Size(77, 17);
            this.chkbxDanificado.TabIndex = 2;
            this.chkbxDanificado.Text = "Danificado";
            this.chkbxDanificado.UseVisualStyleBackColor = true;
            // 
            // chkbxComprometido
            // 
            this.chkbxComprometido.AutoSize = true;
            this.chkbxComprometido.Enabled = false;
            this.chkbxComprometido.Location = new System.Drawing.Point(170, 19);
            this.chkbxComprometido.Name = "chkbxComprometido";
            this.chkbxComprometido.Size = new System.Drawing.Size(93, 17);
            this.chkbxComprometido.TabIndex = 1;
            this.chkbxComprometido.Text = "Comprometido";
            this.chkbxComprometido.UseVisualStyleBackColor = true;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(430, 0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(27, 23);
            this.btClose.TabIndex = 13;
            this.btClose.Text = "X";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTermos,
            this.btnAdmin,
            this.ferramentasToolStripMenuItem,
            this.controlesToolStripMenuItem,
            this.facebookToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(460, 24);
            this.MainMenu.TabIndex = 14;
            this.MainMenu.Text = "menuStrip1";
            // 
            // btnTermos
            // 
            this.btnTermos.Name = "btnTermos";
            this.btnTermos.Size = new System.Drawing.Size(57, 20);
            this.btnTermos.Text = "Termos";
            this.btnTermos.Click += new System.EventHandler(this.btnTermos_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(95, 20);
            this.btnAdmin.Text = "Administrador";
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            this.btnAdmin.MouseEnter += new System.EventHandler(this.btnAdmin_MouseEnter);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSBScanToolStripMenuItem,
            this.autoDesligarToolStripMenuItem,
            this.gravadorDePassosToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // uSBScanToolStripMenuItem
            // 
            this.uSBScanToolStripMenuItem.Name = "uSBScanToolStripMenuItem";
            this.uSBScanToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.uSBScanToolStripMenuItem.Text = "USB Scan";
            this.uSBScanToolStripMenuItem.Click += new System.EventHandler(this.uSBScanToolStripMenuItem_Click);
            // 
            // autoDesligarToolStripMenuItem
            // 
            this.autoDesligarToolStripMenuItem.Name = "autoDesligarToolStripMenuItem";
            this.autoDesligarToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.autoDesligarToolStripMenuItem.Text = "AutoDesligar";
            this.autoDesligarToolStripMenuItem.Click += new System.EventHandler(this.autoDesligarToolStripMenuItem_Click);
            // 
            // gravadorDePassosToolStripMenuItem
            // 
            this.gravadorDePassosToolStripMenuItem.Name = "gravadorDePassosToolStripMenuItem";
            this.gravadorDePassosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.gravadorDePassosToolStripMenuItem.Text = "Gravador de Passos";
            this.gravadorDePassosToolStripMenuItem.Click += new System.EventHandler(this.gravadorDePassosToolStripMenuItem_Click);
            // 
            // controlesToolStripMenuItem
            // 
            this.controlesToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.controlesToolStripMenuItem.Name = "controlesToolStripMenuItem";
            this.controlesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.controlesToolStripMenuItem.Text = "Controles";
            this.controlesToolStripMenuItem.Visible = false;
            this.controlesToolStripMenuItem.Click += new System.EventHandler(this.controlesToolStripMenuItem_Click);
            // 
            // facebookToolStripMenuItem
            // 
            this.facebookToolStripMenuItem.Image = global::Suporte.Properties.Resources.FB_f_Logo__blue_29;
            this.facebookToolStripMenuItem.Name = "facebookToolStripMenuItem";
            this.facebookToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.facebookToolStripMenuItem.Click += new System.EventHandler(this.facebookToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(458, 5);
            this.panel3.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel5.Location = new System.Drawing.Point(292, 94);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 153);
            this.panel5.TabIndex = 16;
            // 
            // btnAgenda
            // 
            this.btnAgenda.Location = new System.Drawing.Point(303, 187);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(143, 23);
            this.btnAgenda.TabIndex = 17;
            this.btnAgenda.Text = "Agenda";
            this.btnAgenda.UseVisualStyleBackColor = true;
            this.btnAgenda.Visible = false;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Avisos:";
            // 
            // tbxAvisos
            // 
            this.tbxAvisos.BackColor = System.Drawing.Color.White;
            this.tbxAvisos.ForeColor = System.Drawing.Color.Black;
            this.tbxAvisos.Location = new System.Drawing.Point(65, 217);
            this.tbxAvisos.Name = "tbxAvisos";
            this.tbxAvisos.ReadOnly = true;
            this.tbxAvisos.Size = new System.Drawing.Size(198, 20);
            this.tbxAvisos.TabIndex = 18;
            this.tbxAvisos.Text = "-";
            this.tbxAvisos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 277);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxAvisos);
            this.Controls.Add(this.btnAgenda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbxContato);
            this.Controls.Add(this.tbxInfo);
            this.Controls.Add(this.btnInfoSistema);
            this.Controls.Add(this.pnBanner);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAtivar);
            this.Controls.Add(this.btnSuporte);
            this.Controls.Add(this.btnControleClientes);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuario";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Central de Suporte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUsuario_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUsuario_FormClosed);
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            this.Shown += new System.EventHandler(this.frmUsuario_Shown);
            this.Resize += new System.EventHandler(this.frmUsuario_Resize);
            this.pnBanner.ResumeLayout(false);
            this.pnBanner.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlBARBACK.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnControleClientes;
        private System.Windows.Forms.Button btnSuporte;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnBanner;
        private System.Windows.Forms.Button btnInfoSistema;
        private System.Windows.Forms.TextBox tbxContato;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFixtec;
        private System.Windows.Forms.Label tbxVer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem btnTermos;
        public System.Windows.Forms.CheckBox chkbxAlterado;
        public System.Windows.Forms.CheckBox chkbxDanificado;
        public System.Windows.Forms.CheckBox chkbxComprometido;
        protected internal System.Windows.Forms.NotifyIcon notifyIcon;
        protected internal System.Windows.Forms.Button btnAtivar;
        protected internal System.Windows.Forms.ToolStripMenuItem btnAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem controlesToolStripMenuItem;
        public System.Windows.Forms.TextBox tbxInfo;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSBScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoDesligarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gravadorDePassosToolStripMenuItem;
        private System.Windows.Forms.Panel pnlBARBACK;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Button btnRunCCleaner;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbxAvisos;
        public System.Windows.Forms.Panel pnlMeterBar;
        private System.Windows.Forms.ToolStripMenuItem facebookToolStripMenuItem;
    }
}

