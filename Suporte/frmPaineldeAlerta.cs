using System.Drawing;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmPaineldeAlerta : Form
    {
        public frmPaineldeAlerta()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            int y = Screen.PrimaryScreen.WorkingArea.Left;
            int x = Screen.PrimaryScreen.WorkingArea.Height - Height - 370;
            Location = new Point(y, x);
            //(Comp,altu)Screen.PrimaryScreen.WorkingArea.Width
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, 150);
        }

        private void btnAceito_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btmTermos_Click(object sender, System.EventArgs e)
        {
            TopMost = false;
            Garantia frmGarantia = new Garantia();
            frmGarantia.ShowDialog();
        }
    }
}
