using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Suporte
{
    partial class Garantia : Form
    {
        public Garantia()
        {
            InitializeComponent();
            btnClose.Enabled = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument p = new PrintDocument();
            p.PrintPage +=
                (sender1, e1) =>
                e1.Graphics.DrawString(richTextBox1.Text, new Font("Times New Roman", 12),
                                       new SolidBrush(Color.Black),
                                       new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width,
                                                      p.DefaultPageSettings.PrintableArea.Height));
            try
            {
                p.Print();
            }
            catch (Exception)
            {
                //throw new Exception("Falha ao acessar impressora.", ex);
                MessageBox.Show(@"Falha ao acessar impressora.");
            }
        }

        private void Garantia_Load(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

            //Aceito Termos?
            var regTrial = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\CentraldeSuporte", false);
            if (regTrial != null && regTrial.GetValue("Termos") != null)
            {
                chkbxTermos.CheckState = CheckState.Checked;
                chkbxTermos.Enabled = false;
                btnClose.Enabled = true;
            }
            else
            {
                btnClose.Enabled = false;
            }
        }

        private void chkbxTermos_CheckedChanged(object sender, EventArgs e)
        {
            var RegTrial = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\CentraldeSuporte", true);
            if (RegTrial != null)
            {
                RegTrial.SetValue("Termos", 1);
                RegTrial.Close();
                btnClose.Enabled = true;
            }
        }
    }
}