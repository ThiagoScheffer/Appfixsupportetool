namespace Suporte
{
    partial class frmEmail
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
            this.tbxEmailInfo = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSuporte = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.chkbxReposta = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxResposta = new System.Windows.Forms.TextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbxEmail = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxEmailInfo
            // 
            this.tbxEmailInfo.BackColor = System.Drawing.SystemColors.Info;
            this.tbxEmailInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbxEmailInfo.Location = new System.Drawing.Point(0, 273);
            this.tbxEmailInfo.Name = "tbxEmailInfo";
            this.tbxEmailInfo.ReadOnly = true;
            this.tbxEmailInfo.Size = new System.Drawing.Size(349, 20);
            this.tbxEmailInfo.TabIndex = 10;
            this.tbxEmailInfo.TabStop = false;
            this.tbxEmailInfo.Text = "Status";
            this.tbxEmailInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(349, 273);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnSuporte);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(341, 247);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Suporte Remoto";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(36, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 91);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 65);
            this.label2.TabIndex = 0;
            this.label2.Text = "1. Por favor avise-nos antes de efetuar o \r\nacesso remoto antes de prosseguir.\r\n\r" +
    "\n2. O processo executado é quase todo automático\r\npor favor, aguarde até a barra" +
    " de Status ficar verde.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 222);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(335, 22);
            this.panel3.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 22);
            this.panel2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Para iniciar o suporte remoto, clique aqui.";
            // 
            // btnSuporte
            // 
            this.btnSuporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuporte.Location = new System.Drawing.Point(95, 184);
            this.btnSuporte.Name = "btnSuporte";
            this.btnSuporte.Size = new System.Drawing.Size(145, 24);
            this.btnSuporte.TabIndex = 5;
            this.btnSuporte.Text = "Iniciar";
            this.btnSuporte.UseVisualStyleBackColor = true;
            this.btnSuporte.Click += new System.EventHandler(this.btnSuporte_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(341, 247);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contato";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkbxReposta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbxResposta);
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Controls.Add(this.btnEnviar);
            this.panel1.Location = new System.Drawing.Point(18, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 106);
            this.panel1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Enviar mensagem";
            // 
            // chkbxReposta
            // 
            this.chkbxReposta.AutoSize = true;
            this.chkbxReposta.Location = new System.Drawing.Point(6, 3);
            this.chkbxReposta.Name = "chkbxReposta";
            this.chkbxReposta.Size = new System.Drawing.Size(232, 17);
            this.chkbxReposta.TabIndex = 2;
            this.chkbxReposta.Text = "Marque aqui para receber retorno por email.";
            this.chkbxReposta.UseVisualStyleBackColor = true;
            this.chkbxReposta.CheckedChanged += new System.EventHandler(this.chkbxReposta_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Digite aqui o e-mail para o retorno e depois aperte Enviar.";
            // 
            // tbxResposta
            // 
            this.tbxResposta.Enabled = false;
            this.tbxResposta.Location = new System.Drawing.Point(33, 39);
            this.tbxResposta.Name = "tbxResposta";
            this.tbxResposta.Size = new System.Drawing.Size(246, 20);
            this.tbxResposta.TabIndex = 3;
            // 
            // btnLimpar
            // 
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Location = new System.Drawing.Point(151, 75);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(112, 23);
            this.btnLimpar.TabIndex = 1;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Location = new System.Drawing.Point(33, 75);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(112, 23);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbxEmail);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 124);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mensagem";
            // 
            // rtbxEmail
            // 
            this.rtbxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbxEmail.Location = new System.Drawing.Point(6, 19);
            this.rtbxEmail.Name = "rtbxEmail";
            this.rtbxEmail.Size = new System.Drawing.Size(313, 99);
            this.rtbxEmail.TabIndex = 0;
            this.rtbxEmail.Text = "";
            // 
            // frmEmail
            // 
            this.AcceptButton = this.btnSuporte;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 293);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbxEmailInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contato e Suporte Remoto";
            this.Load += new System.EventHandler(this.frmEmail_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxEmailInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSuporte;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkbxReposta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxResposta;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbxEmail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}