using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmEditor : Form
    {
        //VARS
        public bool AdminLock = true;
        public frmEditor()
        {
            //MRecreateAllExecutableResources();
            InitializeComponent();
        }

        #region FrmUIControl
        //Carrega Info de Versao
        private void MainVerInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            tbxVer.Text = "Ver: " + fvi.ProductVersion;
            tbxPPVersion.Text = cEditor.GetPremiereVersion().Item3;
            if (CRegistros.Tecnico)
            {
                controleToolStripMenuItem.Visible = true;
                controleToolStripMenuItem.Enabled = true;
            }
        }

        private void SetUImode()
        {
            try
            {
                //458; 276
                //Premiere Apenas
                if (Program.PPInstalled && !Program.LTInstalled)
                {
                    //if (cEditor.GetInterfaceMode() != 0) return;
                    Size = new Size(592, 339);
                    if (!grpbxLightRoom.IsDisposed) 
                    { 
                        grpbxLightRoom.Controls.Clear();//Limpa controles dentro do group
                        grpbxLightRoom.Enabled = false; //desabilita o group
                        grpbxLightRoom.Visible = false; //Invisivel
                        grpbxLightRoom.Dispose();//Destroi
                    }
 
                }
                //Lightroom apenas
                if (!Program.PPInstalled && Program.LTInstalled)
                {
                    // if (cEditor.GetInterfaceMode() != 0) return;
                    Size = new Size(592, 339);
                    if (!grpbxPremiere.IsDisposed)
                    {
                        grpbxPremiere.Controls.Clear();
                        grpbxPremiere.Enabled = false;
                        grpbxPremiere.Visible = false;
                        grpbxPremiere.Dispose();
                        grpbxLightRoom.Location = new Point(306, 96);
                    }
                }
                
                //Ambos
                if (!Program.PPandLT) return;//Nao deveria acontecer isso...

                int mode = cEditor.GetInterfaceMode();//Tipo de interface simples ou completa

                //Tamanho do Form
                Size = mode == 0 ? new Size(890, 339) : new Size(592, 339);

                if (mode == 1)//1 = compacta ocultar Premiere
                {
                    compactaToolStripMenuItem.BackColor = Color.LightCyan;
                    completaToolStripMenuItem.BackColor = Color.White;
                    grpbxPremiere.Enabled = false;
                    grpbxPremiere.Visible = false;
                    grpbxLightRoom.Location = new Point(306, 96);
                }
                else//== 0 Full
                {
                    completaToolStripMenuItem.BackColor = Color.LightCyan;
                    compactaToolStripMenuItem.BackColor = Color.White;
                    grpbxPremiere.Enabled = true;
                    grpbxPremiere.Visible = true;
                }
            }
            catch (Exception)//Nenhum erro foi encotrado. ignorar por hora.
            {
            }
 
        }

        private void SetAppLocation()
        {
            string keyvalue = CRegistros.WindowLocation;
            TopMost = true;

            //Default rightCorner
            switch (keyvalue)
            {
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
        private void DisableButtons()
        {
            if (!CRegistros.Administrativo)//Desativa Pag se o PC nao é Administrativo
                btnPagamentos.Enabled = false;

            if (Program.PPInstalled) return;
            barPMediaCache.Enabled = false;
            tbxPMediaCache.Enabled = false;
        }
        #endregion

        #region Load Form Events
        //LOAD DO FORM
        private void frmEditor_Load(object sender, EventArgs e)//Evento 1
        {
            SetUImode();//0
            CRegistros.WriteFirstTimeCentralDef();//1
            MainVerInfo();//2
            CRegistros.WriteFirstTimeEditorKeys();
            DisableButtons();
            //Inicia os metodos principais
            cCommon.StartMethods();
        }

        private void frmEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Verificação se esta realmente saindo, apenas minimizando ou Atualizando.
            if (!Program.Quit) return;

            //Saindo completamente do aplicativo
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
           // GC.Collect();
          //  GC.WaitForPendingFinalizers();
        }

        private void frmEditor_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized != WindowState) return;
            Hide();
            notifyIcon.ShowBalloonTip(2);
            notifyIcon.Visible = true;
        }

        private void frmEditor_FormClosing(object sender, FormClosingEventArgs e)
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
            e.Cancel = true;
            Hide();
            notifyIcon.Visible = true;
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            SetUImode();//0
            SetAppLocation();//1
            notifyIcon.Visible = false; //2
            Show(); //3
            WindowState = FormWindowState.Normal; //4
            cEditor.StartWorker();//5
            if (CRegistros.Tecnico)//Se for Tecnico
                cMessenger.ReadAgendaStatus();
        }

        private void frmEditor_Shown(object sender, EventArgs e)
        {
            Close();
        } 
        #endregion

        #region Funções Iniciais

        //======================================================
        //Recreate all executable resources
        //======================================================
        private void MRecreateAllExecutableResources()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(GetType().Assembly.GetManifestResourceNames(),
                                             element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
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
            Close();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            using (frmValidar frmValidar = new frmValidar())
            {
                frmValidar.ShowDialog();
            }
        }

        private void btnPagamentos_Click(object sender, EventArgs e)
        {
            Close();
            frmControledoCliente frmControledoCliente = new frmControledoCliente();
            frmControledoCliente.Show();
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
            if (AdminLock) return;//Lock = True - Retorna
            Close();
            frmAdministrador frmAdm = new frmAdministrador();
            frmAdm.Show();
            
        }

        private void btnAdmin_MouseEnter(object sender, EventArgs e)
        {
            if (!AdminLock) return;
            if (CRegistros.Tecnico) //Se for True
            {
                AdminLock = false; //Locked = falso
                return;
            }
            frmPassword frmPassword = new frmPassword();
            frmPassword.ShowDialog();
        }

        private void btnLimparCaches_Click(object sender, EventArgs e)
        {
            cEditor.CleanPremiereCaches();
        }

        private void btnLimparPreviews_Click(object sender, EventArgs e)
        {
            cEditor.CleanPreviewFolder();
        }

        private void btnFerramentas_Click(object sender, EventArgs e)
        {
            Close();
            frmFerramentas frmFerramentas = new frmFerramentas();
            frmFerramentas.ShowDialog();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            if (CRegistros.Tecnico)
            {
                frmAgenda frmAgenda = new frmAgenda();
                frmAgenda.Show();
            }
            else
            {
                frmAgEventos frmAgenda = new frmAgEventos();
                frmAgenda.Show();
            }
            Close();
        }

        private void btnPresExec_Click(object sender, EventArgs e)
        {
            string FilterFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                      @"\Adobe\Lightroom\Filter Presets";
            string FilterBackup = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LTFiltersBackup";
            if(!Directory.Exists(FilterFolderPath))
                return;


            try
            {
                if (Directory.Exists(FilterBackup))
                    Directory.Delete(FilterBackup, true);

                cUtils.CopyFolderRecursive(FilterFolderPath, FilterBackup);
            }
            catch (Exception ex)
            {
                cUtils.LogSend(ex.ToString()+ "\n LT Bak");
            }
            tbxPresBak.Text = "Criado: " + DateTime.Now.ToShortDateString();

            MessageBox.Show("Backup Criado no Desktop");
        }

        private void btnPresRec_Click(object sender, EventArgs e)
        {
            string FilterFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                      @"\Adobe\Lightroom\Filter Presets";
            string FilterBackup = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LTFiltersBackup";

            if (!Directory.Exists(FilterBackup))
                return;
            
            if (!Directory.Exists(FilterFolderPath))
                Directory.CreateDirectory(FilterFolderPath);

            if (Directory.Exists(FilterBackup))
                Directory.Delete(FilterFolderPath, true);
            cUtils.CopyFolderRecursive(FilterBackup, FilterFolderPath);
            tbxPresBak.Text = "Restaurado: " + Directory.GetCreationTime(FilterBackup).ToShortDateString();
        }

        private void btnPrefsRepair_Click(object sender, EventArgs e)
        {
            DialogResult ASK = MessageBox.Show("Você tem certeza que deseja iniciar o reparo ?",
                                         "Resetar Definições", MessageBoxButtons.OKCancel);
            if (ASK != DialogResult.OK) return;
            string PrefFileOld = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +@"\Adobe\Lightroom\OldPrefsFile.old";
            string PrefFile = CRegistros.GetLtDefFile();
            try
            {
                if (File.Exists(PrefFile)) File.Delete(PrefFile);
                File.Move(PrefFileOld, PrefFile);
            }
            catch (Exception exception)
            {
                cUtils.LogSend("LT Prefs Repair:\n"+exception.ToString());
                return;
            }
            MessageBox.Show("Definições do LT foram restauradas.");
        }

        private void compactaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cEditor.SetInterfaceMode(1);
            Close();
        }

        private void completaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cEditor.SetInterfaceMode(0);
            Close();
        }

        private void controleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaineldeControle frmPaineldeControle = new frmPaineldeControle();
            frmPaineldeControle.Show();
            Close();
        }

        private void netfontesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.netfontes.com.br/");
        }

        private void dafontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.dafont.com/pt/");
        }

        private void actionfontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.actionfonts.com/");
        }

        private void gravadorDePassosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("C:\\windows\\system32\\psr.exe");
            }
            catch (Exception)
            {
            }
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/FIX-Tecnologias-693571370703483/timeline");
            Close();
        }
    }
}
