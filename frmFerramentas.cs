using System;
using System.IO;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmFerramentas : Form
    {
        private readonly FolderBrowserDialog _folderBrowser = new FolderBrowserDialog();

        public frmFerramentas()
        {
            InitializeComponent();
        }

        #region Botoes
        //Selecinar pasta a alterar extensoes
        private void btnProcurarDir_Click(object sender, EventArgs e)
        {
            tbxPath.Text = "";
            ExtListView.Clear();
            _folderBrowser.Description = @"Selecionar a pasta...";
            if (_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                tbxPath.Text = _folderBrowser.SelectedPath;
                FillListExtension(_folderBrowser.SelectedPath);
                
            }
        }

        private void btnAbrirCaminho_Click(object sender, EventArgs e)
        {
            tbxPath.Text = "";
            ExtListView.Clear();
            if (tbxPath.Text == "")
            {
                MessageBox.Show(@"Nenhum diretório selecionado!");
                return;
            }

            FillListExtension(tbxPath.Text);
        }

        //Iniciar alterar extensões;
        private void btnIniciarAlterar_Click(object sender, EventArgs e)
        {
            ExtListView.Clear();
            if (tbxPath.Text == "")
            {
                MessageBox.Show(@"Nenhum diretório selecionado!");
                return;
            }
            try
            {
                foreach (var file in Directory.GetFiles(tbxPath.Text))
                {
                    if (Path.GetExtension(file) != ".xmp")
                    File.Move(file, Path.ChangeExtension(file, cbxExtensao.SelectedItem.ToString()));
                    //file.Replace(Path.GetExtension(file), cbxExtensao.SelectedItem.ToString());
                }

                foreach (var files in Directory.GetFiles(tbxPath.Text))
                {
                    if (Path.GetExtension(files) != ".xmp")
                    ExtListView.Items.Add(Path.ChangeExtension(Path.GetFileName(files),
                                                             cbxExtensao.SelectedItem.ToString()));
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(@"Falha ao ler arquivos. verifique se não estão sendo usados por outro aplicativo.");
                MessageBox.Show(ex.ToString());
            }
        }

        #region Arquivar
        //Selecionar pasta para Datar;
        private void btnOrgSelectFolder_Click(object sender, EventArgs e)
        {
            listView2.Clear();

            _folderBrowser.Description = @"Selecionar a pasta...";
            if (_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                tbxOrgSelectedFolder.Text = _folderBrowser.SelectedPath;
                LoadListViewOrg();
            }
        }
        private void btnOrgStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxOrgSelectedFolder.Text))
                return;
            var selectedDate = GetSelectedDatetoSubstract();
            var data2Meses = DateTime.Now.AddDays(selectedDate);
            var selectedext = GetExtfromCbx();
            var dir = new DirectoryInfo(tbxOrgSelectedFolder.Text);
            try
            {
                if (chkbxdma.CheckState == CheckState.Checked)
                {
                    foreach (var file in dir.GetFiles(selectedext))
                    {
                        if (file.LastWriteTime < data2Meses)
                        {
                            if (
                                !Directory.Exists(tbxOrgSelectedFolder.Text + "\\" +
                                                  file.LastWriteTime.Date.ToShortDateString().Replace("/", ".")))
                                Directory.CreateDirectory(tbxOrgSelectedFolder.Text + "\\" +
                                                          file.LastWriteTime.Date.ToShortDateString().Replace("/", "."));
                            File.Move(file.FullName,
                                      tbxOrgSelectedFolder.Text + "\\" +
                                      file.LastWriteTime.Date.ToShortDateString().Replace("/", ".") + "\\" + file.Name);
                        }
                    }
                }
                if (chkbxma.CheckState == CheckState.Checked)
                {
                    foreach (var file in dir.GetFiles(selectedext))
                    {
                        if (file.LastWriteTime < data2Meses)
                        {
                            if (
                                !Directory.Exists(tbxOrgSelectedFolder.Text + "\\" +
                                                  file.LastWriteTime.Date.ToString("MM/yyyy").Replace("/", ".")))
                                Directory.CreateDirectory(tbxOrgSelectedFolder.Text + "\\" +
                                                          file.LastWriteTime.Date.ToString("MM/yyyy").Replace("/", "."));
                            File.Move(file.FullName,
                                      tbxOrgSelectedFolder.Text + "\\" +
                                      file.LastWriteTime.Date.ToString("MM/yyyy").Replace("/", ".") + "\\" + file.Name);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                cUtils.SendEmailAsync("Datar Arquivos" + "\n" + error.ToString());
                MessageBox.Show("Foi encotrado um problema. um Log foi enviado para o Técnico corrigir.");
                return;
            }
            LoadListViewOrg();

        }
        private void chkbxma_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkbxma.CheckState == CheckState.Checked)
            {
                chkbxdma.CheckState = CheckState.Unchecked;
            }
        }

        private void chkbxdma_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkbxdma.CheckState == CheckState.Checked)
                chkbxma.CheckState = CheckState.Unchecked;
        }
        #endregion
        #endregion

        #region Funçoes

        private void FillListExtension(string path)
        {
            ExtListView.Clear();
            if (tbxPath.Text == "")
            {
                MessageBox.Show(@"Nenhum diretório selecionado!");
                return;
            }
            try
            {
                //Carrega cada arquivo na lista
                foreach (var files in Directory.GetFiles(tbxPath.Text))
                {
                    if (Path.GetExtension(files) != ".xmp")
                        ExtListView.Items.Add(Path.GetFileName(files));
                }
            }
            catch (Exception)
            {
               MessageBox.Show(@"Falha ao ler arquivos. verifique se não estão sendo usados por outro aplicativo.");
            }

        }
        private void LoadListViewOrg()
        {
            listView2.Clear();
            var dirinfo = new DirectoryInfo(tbxOrgSelectedFolder.Text);
            //foreach (var files in Directory.GetFiles(_folderBrowser.SelectedPath))
            foreach (var files in dirinfo.GetFiles(GetExtfromCbx()))
            {
                listView2.Items.Add(files.Name);
            }
        }

        private void frmFileTools_Load(object sender, EventArgs e)
        {
            cbxExtensao.SelectedIndex = 1;
            cbxorgext.SelectedIndex = 0;
            cbxorgdata.SelectedIndex = 0;
            //MessageBox.Show(cbxExtensao.SelectedItem.ToString());
        }
        private int GetSelectedDatetoSubstract()
        {
            switch (cbxorgdata.SelectedIndex)
            {
                case 0:
                    return -60;
                case 1:
                    return -120;
                case 2:
                    return -180;
                case 3:
                    return -360;
                case 4:
                    return -420;
                default:
                    return -60;
            }
        }
        private string GetExtfromCbx()
        {
            switch (cbxorgext.SelectedIndex)
            {
                case 0:
                    return "*.prproj";
                case 1:
                    return "*.aep";
                case 2:
                    return "*.psd";
                case 3:
                    return "*.jpg";
                case 4:
                    return "*.png";
                case 5:
                    return "*.avi";
                case 6:
                    return "*.mov";
                case 7:
                    return "*.mpg";
                case 8:
                    return "*.flv";
                case 9:
                    return "*.mp4";
                case 10:
                    return "*.m4v";
                default:
                    return "*.prproj";
            }
        }

        #endregion

        private void autoDesligarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditor fMain = (frmEditor)Application.OpenForms["frmEditor"];
            if (fMain == null) return;

            FormProvider.FrmDesligar.ShowDialog();
            fMain.tbxAvisos.Text = FormProvider.FrmDesligar.TValue;    
        }
        private class FormProvider
        {
            public static frmAutoShutdown FrmDesligar
            {
                get { return AutoShutdown ?? (AutoShutdown = new frmAutoShutdown(null)); }
            }

            private static frmAutoShutdown AutoShutdown;
        }

        private void uSBScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUSBScan frmUsbScan = new frmUSBScan();
            frmUsbScan.ShowDialog();
        }

        private void avançadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPremiereDef frmPremiereDef = new frmPremiereDef();
            frmPremiereDef.Show();
        }

        private void tbxPath_MouseClick(object sender, MouseEventArgs e)
        {
            if (tbxPath.ForeColor.Name == "InactiveCaption")
            {
                tbxPath.ResetForeColor();
                tbxPath.Text = "";
            }
        }


        }
}