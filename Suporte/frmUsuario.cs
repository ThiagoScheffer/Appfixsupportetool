using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmUsuario : Form
    {
        //VARS
        public bool AdminLock = true;

        public frmUsuario()
        {
            //MRecreateAllExecutableResources();
            InitializeComponent();
        }

        #region Load Form Events

        //Carrega Info de Versao
        private void MainVerInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            tbxVer.Text = @"Ver: " + fvi.ProductVersion;

            if (!CRegistros.Administrativo) //Desativa Pag se o PC nao é Administrativo
                btnControleClientes.Enabled = false;

            if (!CRegistros.Tecnico) return;
            controlesToolStripMenuItem.Visible = true;
            controlesToolStripMenuItem.Enabled = true;
            btnAgenda.Visible = true;

            if (Program.Debug)
                btnControleClientes.Enabled = true;

            //btnAtivar.Text = ;
        }

        private void SetAppLocation()
        {
            string keyvalue = CRegistros.WindowLocation;
            TopMost = true;

            //Default rightCorner
            switch (keyvalue)
            {

                //Forms.SystemInformation.PrimaryMonitorSize 
                case "0":
                    {
                    int y = Screen.PrimaryScreen.WorkingArea.Height - Height;
                    int x = Screen.PrimaryScreen.WorkingArea.Width - Width;
                    Location = new Point(x, y);
                }
                    break;
                case "1":
                {
                    int y = Screen.PrimaryScreen.WorkingArea.Top;
                    int x = Screen.PrimaryScreen.WorkingArea.Width - Width;
                    Location = new Point(x, y);
                }
                    break;
                case "2":
                    TopMost = false;
                    CenterToScreen();
                    break;
            }
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            CRegistros.WriteFirstTimeCentralDef(); //1
            MainVerInfo(); //2
            // Inicializa as funções comuns.
            cCommon.StartMethods(); //3

        }

        private void frmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Verificação se esta realmente saindo, apenas minimizando ou Atualizando.
            if (!Program.Quit) return;

            //Saindo completamente do aplicativo
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }

        private void frmUsuario_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized != WindowState) return; //Se for diferente de minimizado retorna
            Hide();
            notifyIcon.ShowBalloonTip(2);
            notifyIcon.Visible = true;
        }

        private void frmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Se estiver saindo, ir para Closed.
            if (Program.Quit)
            {
                notifyIcon.Icon = null;
                return;
            }
            //Outro, Minimizar.
            AdminLock = true;
            btnAdmin.Enabled = true;
            if (!Visible) return;
            e.Cancel = true; // Evita o sistema ficar preso
            Hide();
            notifyIcon.Visible = true;
        }

        //FUNÇOES AO ABRIR O FORM NOVAMENTE
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            notifyIcon.Visible = false; //1
           SetAppLocation(); //Dinamico 2
            WindowState = FormWindowState.Normal; //3
            Show(); //4
            //Qualquer outra funçao aqui.
            //cHDCheck.GetTempGarbage();// desativado por lentidao
            
            if (CRegistros.Tecnico) //Se for Tecnico
            cMessenger.ReadAgendaStatus();
            
        }

        private void frmUsuario_Shown(object sender, EventArgs e)
        {
            Close();
        }


        private class FormProvider
        {
            public static frmAutoShutdown FrmDesligar => AutoShutdown ?? (AutoShutdown = new frmAutoShutdown(null));

            private static frmAutoShutdown AutoShutdown;
        }

        #endregion

        private void btnInfoSistema_Click(object sender, EventArgs e)
        {
            using (frmInfoSistema frmnInfoSistema = new frmInfoSistema())
            {
                frmnInfoSistema.ShowDialog();
            }
        }

        private void btnSuporte_Click(object sender, EventArgs e)
        {
            using (frmEmail frmEmail = new frmEmail())
            {
                frmEmail.ShowDialog();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
            tbxAvisos.Text = "";
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            using (frmValidar frmValidar = new frmValidar())
            {
                frmValidar.ShowDialog();
            }
        }

        private void btnTermos_Click(object sender, EventArgs e)
        {
            using (Garantia frmGarantia = new Garantia())
            {
                frmGarantia.ShowDialog();
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (AdminLock) return;
            frmAdministrador frmAdm = new frmAdministrador();
            frmAdm.Show();
            Close();
        }

        private void btnAdmin_MouseEnter(object sender, EventArgs e)
        {
            if (!AdminLock) return;
            if (Program.Debug || CRegistros.Tecnico) //Se for True
            {
                AdminLock = false; //Locked = falso
                return;
            }
            frmPassword frmPassword = new frmPassword();
            frmPassword.ShowDialog();
        }

        private void controlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaineldeControle frmPaineldeControle = new frmPaineldeControle();
            frmPaineldeControle.Show();
            Close();
        }

        private void uSBScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUSBScan frmUsbScan = new frmUSBScan();
            frmUsbScan.ShowDialog();
        }

        private void autoDesligarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProvider.FrmDesligar.ShowDialog();
            tbxAvisos.Text = FormProvider.FrmDesligar.TValue;
            tbxAvisos.BackColor = tbxAvisos.Text == "Desligamento Ativado" ? Color.Khaki : Color.White;
        }


        private void btnControleClientes_Click(object sender, EventArgs e)
        {
              frmControledoCliente frmControledoCliente = new frmControledoCliente();
              Close();
              frmControledoCliente.ShowDialog();



            //debugggg
           // tbxAvisos.Text = CRegistros.LoadAdobeInfoFromReg("premierever");
            //tbxAvisos.Text = CRegistros.LoadAdobeInfoFromReg("photoshoppath");
            
        }

        private void gravadorDePassosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("C:\\windows\\system32\\psr.exe");
            }
            catch (Exception)
            {}
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            if (!cUtils.ConnectionAvailable()) return;
            frmAgenda frmAgenda = new frmAgenda();
            Close();
            frmAgenda.Show();
            
        }

        private void btnRunCCleaner_Click(object sender, EventArgs e)
        {
            cUtils.StartWithArgs("CCleaner.exe", "/AUTO");
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("xxxxxxxxxxx");
            Close();
        }
    }
}
