using System;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmPassword : Form
    {
        //static readonly frmUsuario fMain = (frmUsuario)Application.OpenForms["frmUsuario"];
        //static readonly frmMain fMain = (frmEditor)Application.OpenForms["frmEditor"];
        public frmPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Program.PPInstalled || Program.LTInstalled)
            {
                frmEditor fMain = (frmEditor)Application.OpenForms["frmEditor"];
                if (fMain == null) return;
                if (maskedTextBox1.Text == @"teste")
                {
                   // fMain.AdminLock = false; Close();
                    frmAdministrador frmAdministrador = new frmAdministrador();
                    frmAdministrador.Show();
                }
                else
                {
                    fMain.AdminLock = true; fMain.btnAdmin.Enabled = false; Close();
                }
            }
            else
            {
                frmUsuario fMain = (frmUsuario)Application.OpenForms["frmUsuario"];
                if (fMain == null) return;
                if (maskedTextBox1.Text == @"teste")
                {
                    //fMain.AdminLock = false;Close();
                    frmAdministrador frmAdministrador = new frmAdministrador();
                    frmAdministrador.Show();
                }
                else
                {
                    fMain.AdminLock = true;fMain.btnAdmin.Enabled = false;Close();
                }
            }
        }
    }
}
