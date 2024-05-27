namespace Suporte
{
    partial class FrmControledeClientes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCadNovo = new System.Windows.Forms.Button();
            this.btnCadSalvar = new System.Windows.Forms.Button();
            this.btnCadAplicar = new System.Windows.Forms.Button();
            this.btnCadAdd = new System.Windows.Forms.Button();
            this.dgvCadCliente = new System.Windows.Forms.DataGridView();
            this.grpCad = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbxCadEmail = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbxCadTel = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbxCadCPF = new System.Windows.Forms.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cbxCadTpCliente = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tbxCadEnd = new System.Windows.Forms.TextBox();
            this.tbxCadNome = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCadCliente)).BeginInit();
            this.grpCad.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 14);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.btnCadNovo);
            this.panel2.Controls.Add(this.btnCadSalvar);
            this.panel2.Controls.Add(this.btnCadAplicar);
            this.panel2.Controls.Add(this.btnCadAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 497);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(857, 39);
            this.panel2.TabIndex = 1;
            // 
            // btnCadNovo
            // 
            this.btnCadNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadNovo.Location = new System.Drawing.Point(12, 9);
            this.btnCadNovo.Name = "btnCadNovo";
            this.btnCadNovo.Size = new System.Drawing.Size(132, 23);
            this.btnCadNovo.TabIndex = 3;
            this.btnCadNovo.Text = "Novo";
            this.btnCadNovo.UseVisualStyleBackColor = true;
            this.btnCadNovo.Click += new System.EventHandler(this.btnCadNovo_Click);
            // 
            // btnCadSalvar
            // 
            this.btnCadSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadSalvar.Location = new System.Drawing.Point(713, 9);
            this.btnCadSalvar.Name = "btnCadSalvar";
            this.btnCadSalvar.Size = new System.Drawing.Size(132, 23);
            this.btnCadSalvar.TabIndex = 2;
            this.btnCadSalvar.Text = "Salvar Tudo";
            this.btnCadSalvar.UseVisualStyleBackColor = true;
            this.btnCadSalvar.Click += new System.EventHandler(this.btnCadSalvar_Click);
            // 
            // btnCadAplicar
            // 
            this.btnCadAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadAplicar.Location = new System.Drawing.Point(575, 9);
            this.btnCadAplicar.Name = "btnCadAplicar";
            this.btnCadAplicar.Size = new System.Drawing.Size(132, 23);
            this.btnCadAplicar.TabIndex = 1;
            this.btnCadAplicar.Text = "Aplicar Modificações";
            this.btnCadAplicar.UseVisualStyleBackColor = true;
            this.btnCadAplicar.Click += new System.EventHandler(this.btnCadAplicar_Click);
            // 
            // btnCadAdd
            // 
            this.btnCadAdd.Location = new System.Drawing.Point(150, 9);
            this.btnCadAdd.Name = "btnCadAdd";
            this.btnCadAdd.Size = new System.Drawing.Size(132, 23);
            this.btnCadAdd.TabIndex = 0;
            this.btnCadAdd.Text = "Cadastrar";
            this.btnCadAdd.UseVisualStyleBackColor = true;
            this.btnCadAdd.Click += new System.EventHandler(this.btnCadAdd_Click);
            // 
            // dgvCadCliente
            // 
            this.dgvCadCliente.AllowUserToAddRows = false;
            this.dgvCadCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCadCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCadCliente.Location = new System.Drawing.Point(0, 14);
            this.dgvCadCliente.Name = "dgvCadCliente";
            this.dgvCadCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCadCliente.Size = new System.Drawing.Size(857, 379);
            this.dgvCadCliente.TabIndex = 2;
            this.dgvCadCliente.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvCadCliente_MouseClick);
            // 
            // grpCad
            // 
            this.grpCad.Controls.Add(this.label28);
            this.grpCad.Controls.Add(this.tbxCadEmail);
            this.grpCad.Controls.Add(this.label27);
            this.grpCad.Controls.Add(this.tbxCadTel);
            this.grpCad.Controls.Add(this.label25);
            this.grpCad.Controls.Add(this.tbxCadCPF);
            this.grpCad.Controls.Add(this.label26);
            this.grpCad.Controls.Add(this.cbxCadTpCliente);
            this.grpCad.Controls.Add(this.label24);
            this.grpCad.Controls.Add(this.label23);
            this.grpCad.Controls.Add(this.tbxCadEnd);
            this.grpCad.Controls.Add(this.tbxCadNome);
            this.grpCad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCad.Location = new System.Drawing.Point(0, 393);
            this.grpCad.Name = "grpCad";
            this.grpCad.Size = new System.Drawing.Size(857, 104);
            this.grpCad.TabIndex = 3;
            this.grpCad.TabStop = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(562, 41);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(32, 13);
            this.label28.TabIndex = 48;
            this.label28.Text = "Email";
            // 
            // tbxCadEmail
            // 
            this.tbxCadEmail.Location = new System.Drawing.Point(565, 56);
            this.tbxCadEmail.Name = "tbxCadEmail";
            this.tbxCadEmail.Size = new System.Drawing.Size(287, 20);
            this.tbxCadEmail.TabIndex = 47;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(351, 63);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(60, 13);
            this.label27.TabIndex = 46;
            this.label27.Text = "Telefone(s)";
            // 
            // tbxCadTel
            // 
            this.tbxCadTel.Location = new System.Drawing.Point(354, 78);
            this.tbxCadTel.Name = "tbxCadTel";
            this.tbxCadTel.Size = new System.Drawing.Size(205, 20);
            this.tbxCadTel.TabIndex = 45;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(136, 18);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 13);
            this.label25.TabIndex = 44;
            this.label25.Text = "CPF/CNPJ";
            // 
            // tbxCadCPF
            // 
            this.tbxCadCPF.Location = new System.Drawing.Point(139, 33);
            this.tbxCadCPF.Mask = "000,000,000-00";
            this.tbxCadCPF.Name = "tbxCadCPF";
            this.tbxCadCPF.Size = new System.Drawing.Size(139, 20);
            this.tbxCadCPF.TabIndex = 43;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(31, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(78, 13);
            this.label26.TabIndex = 42;
            this.label26.Text = "Tipo de Cliente";
            // 
            // cbxCadTpCliente
            // 
            this.cbxCadTpCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCadTpCliente.FormattingEnabled = true;
            this.cbxCadTpCliente.Items.AddRange(new object[] {
            "Residencial",
            "Comercial",
            "Empresarial"});
            this.cbxCadTpCliente.Location = new System.Drawing.Point(7, 32);
            this.cbxCadTpCliente.Name = "cbxCadTpCliente";
            this.cbxCadTpCliente.Size = new System.Drawing.Size(121, 21);
            this.cbxCadTpCliente.TabIndex = 41;
            this.cbxCadTpCliente.SelectionChangeCommitted += new System.EventHandler(this.cbxTpCliente_SelectionChangeCommitted);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(4, 63);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 13);
            this.label24.TabIndex = 40;
            this.label24.Text = "Endereço";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(284, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 13);
            this.label23.TabIndex = 39;
            this.label23.Text = "Nome Completo";
            // 
            // tbxCadEnd
            // 
            this.tbxCadEnd.Location = new System.Drawing.Point(7, 78);
            this.tbxCadEnd.Name = "tbxCadEnd";
            this.tbxCadEnd.Size = new System.Drawing.Size(341, 20);
            this.tbxCadEnd.TabIndex = 38;
            // 
            // tbxCadNome
            // 
            this.tbxCadNome.Location = new System.Drawing.Point(287, 33);
            this.tbxCadNome.Name = "tbxCadNome";
            this.tbxCadNome.Size = new System.Drawing.Size(272, 20);
            this.tbxCadNome.TabIndex = 37;
            // 
            // FrmControledeClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 536);
            this.Controls.Add(this.dgvCadCliente);
            this.Controls.Add(this.grpCad);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmControledeClientes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Clientes";
            this.Load += new System.EventHandler(this.FrmControledeClientes_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCadCliente)).EndInit();
            this.grpCad.ResumeLayout(false);
            this.grpCad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCadAdd;
        private System.Windows.Forms.DataGridView dgvCadCliente;
        private System.Windows.Forms.GroupBox grpCad;
        private System.Windows.Forms.Button btnCadSalvar;
        private System.Windows.Forms.Button btnCadAplicar;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbxCadEmail;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbxCadTel;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.MaskedTextBox tbxCadCPF;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cbxCadTpCliente;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbxCadEnd;
        private System.Windows.Forms.TextBox tbxCadNome;
        private System.Windows.Forms.Button btnCadNovo;
    }
}