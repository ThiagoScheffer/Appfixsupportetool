namespace Suporte
{
    partial class frmValidar
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
            this.btnValidar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSerial = new System.Windows.Forms.TextBox();
            this.tbxCodMaquina = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnValidarOnline = new System.Windows.Forms.Button();
            this.tbxinfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(4, 158);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(86, 23);
            this.btnValidar.TabIndex = 0;
            this.btnValidar.Text = "Validar Chave";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Insira a chave recebida:";
            // 
            // tbxSerial
            // 
            this.tbxSerial.Location = new System.Drawing.Point(5, 132);
            this.tbxSerial.Name = "tbxSerial";
            this.tbxSerial.Size = new System.Drawing.Size(306, 20);
            this.tbxSerial.TabIndex = 2;
            // 
            // tbxCodMaquina
            // 
            this.tbxCodMaquina.Location = new System.Drawing.Point(4, 76);
            this.tbxCodMaquina.Name = "tbxCodMaquina";
            this.tbxCodMaquina.ReadOnly = true;
            this.tbxCodMaquina.Size = new System.Drawing.Size(307, 20);
            this.tbxCodMaquina.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Código da Máquina";
            // 
            // btnValidarOnline
            // 
            this.btnValidarOnline.Location = new System.Drawing.Point(219, 158);
            this.btnValidarOnline.Name = "btnValidarOnline";
            this.btnValidarOnline.Size = new System.Drawing.Size(86, 23);
            this.btnValidarOnline.TabIndex = 5;
            this.btnValidarOnline.Text = "Validar Online";
            this.btnValidarOnline.UseVisualStyleBackColor = true;
            this.btnValidarOnline.Click += new System.EventHandler(this.btnValidarOnline_Click);
            // 
            // tbxinfo
            // 
            this.tbxinfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxinfo.Location = new System.Drawing.Point(4, 29);
            this.tbxinfo.Name = "tbxinfo";
            this.tbxinfo.ReadOnly = true;
            this.tbxinfo.Size = new System.Drawing.Size(306, 20);
            this.tbxinfo.TabIndex = 6;
            this.tbxinfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Informações";
            // 
            // frmValidar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 191);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxinfo);
            this.Controls.Add(this.btnValidarOnline);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxCodMaquina);
            this.Controls.Add(this.tbxSerial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnValidar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmValidar";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ativar Sistema";
            this.Load += new System.EventHandler(this.frmValidar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSerial;
        private System.Windows.Forms.TextBox tbxCodMaquina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnValidarOnline;
        public System.Windows.Forms.TextBox tbxinfo;
        private System.Windows.Forms.Label label3;
    }
}