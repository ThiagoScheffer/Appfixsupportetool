using System;
using System.Drawing;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmAvisos : Form
    {
        public frmAvisos(string aviso)
        {
           InitializeComponent();
           textBox1.Text = aviso;

        }

        private void frmMessenger_Load(object sender, EventArgs e)
        {

            int y = Screen.PrimaryScreen.WorkingArea.Left;
            int x = Screen.PrimaryScreen.WorkingArea.Height - Height - 370;
            Location = new Point(y, x);
            //(Comp,altu)Screen.PrimaryScreen.WorkingArea.Width
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, 150);
            
        }

        private void btnAceito_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btmTermos_Click(object sender, EventArgs e)
        {
            TopMost = false;
            using (Garantia frmGarantia = new Garantia())
            {
                frmGarantia.ShowDialog();    
            }
        }
    }
}
