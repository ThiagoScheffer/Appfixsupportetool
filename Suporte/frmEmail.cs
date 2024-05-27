using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmEmail : Form
    {
           private const string Filepath = @"C:\ProgramData\SuporteUpdater\suporteremoto.exe";
      //  private string _pTitle = "";

        public frmEmail()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tabPage1);//tab do suporte remoto, nao funciona
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (rtbxEmail.Text != "")
            {
                btnEnviar.Enabled = false;
                tbxEmailInfo.BackColor = Color.Gold;
                tbxEmailInfo.Text = @"Enviando Email...aguarde.";
                if (chkbxReposta.CheckState == CheckState.Checked && tbxResposta.Text != "")
                    rtbxEmail.Text += "\n \nContato: " + tbxResposta.Text;

                //Informações da Máquina
                rtbxEmail.Text += "\n \nEnviado: " + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString();
                rtbxEmail.Text += "\nVersão: " + cUtils.GetProductVersion(null);
                rtbxEmail.Text += "\nComputador: " + CRegistros.GetComputerName();
                cUtils.SendEmailAsync(rtbxEmail.Text);
                tbxEmailInfo.BackColor = Color.LimeGreen;               
                tbxEmailInfo.Text = @"Email enviado com sucesso.";
                MessageBox.Show(@"Email enviado com sucesso.");
                btnEnviar.Enabled = true;
            }
            else
            {
                MessageBox.Show(@"Digite a mensagem antes de enviar!");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            rtbxEmail.Clear();
        }

        #region Suporte

        private void btnSuporte_Click_1(object sender, EventArgs e)
        {
            //SE TEAM  ESTIVER ABERTO FECHAR!
            DialogResult SuporteRemoto = MessageBox.Show(@"Lembre-se que você está concordando com os termos de pagamento", @"Aviso de Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (SuporteRemoto == DialogResult.Cancel)
                return;
            btnSuporte.Enabled = false;

            // string LoginID = cUtils.GetLoginandId();
           // cUtils.GetLoginandId();
            // MessageBox.Show(LoginID);

            /*if (string.IsNullOrEmpty(LoginID) || LoginID.Contains("AlertsHubParent"))
            {
                tbxEmailInfo.Text = "Reenviando aguarde...";
                LoginID = cUtils.GetLoginandId();
                cUtils.EnviarEmail(LoginID);                
            }*/
            /*
                        // Process.EnterDebugMode();
                        cUtils.GetDesktopWindowsTitlesandClose("DWAgent");
                        tbxEmailInfo.Text = @"Verificando o aplicativo de suporte...";

                        if (File.Exists(Filepath))
                        {
                            try
                            {
                                tbxEmailInfo.Text = "Iniciando aplicativo de suporte...";
                                tbxEmailInfo.BackColor = System.Drawing.Color.Khaki;
                                Process.Start(Filepath);
                                Thread.Sleep(13000);
                                _pTitle = cUtils.GetDesktopWindowsTitles("DWAgent");
                                if (string.IsNullOrEmpty(_pTitle)) return;

                                tbxEmailInfo.Text = "Registrando dados para acesso...";
                                string LoginID = cUtils.GetLoginandId();
                                if (string.IsNullOrEmpty(LoginID) || LoginID.Contains("AlertsHubParent"))
                                {
                                    tbxEmailInfo.Text = "Reenviando aguarde...";
                                    LoginID = cUtils.GetLoginandId();
                                    cUtils.EnviarEmail(LoginID);
                                }
                                cUtils.TeamViewerMinimize();
                                Activate();
                                cUtils.EnviarEmail(LoginID);
                                tbxEmailInfo.Text = "Email enviado aguarde...";
                                tbxEmailInfo.BackColor = System.Drawing.Color.LightGreen;
                                btnSuporte.Enabled = true;
                               // Process.LeaveDebugMode();
                            }
                            catch (Exception error)
                            {
                               // Process.LeaveDebugMode();
                                btnSuporte.Enabled = true;
                                cUtils.EnviarEmail("Iniciando Suporte" + "\n" + error.ToString());
                                MessageBox.Show(@"Erro ao executar o TeamViewer, Tente novamente.");
                                File.Delete(Filepath);//Remover caso esteja corrompido
                            }
                        }
                        else
                        {
                            DownloadStart();
                            tbxEmailInfo.Text = @"Arquivo de suporte não existe, Aguarde um momento...";
                            tbxEmailInfo.BackColor = System.Drawing.Color.Orange;
                            btnSuporte.Enabled = true;
                        }*/
        }

        private void DownloadStart()
        {
            try
            {
                var webDown = new WebClient();
                webDown.DownloadFileAsync(new Uri("xxxxxx"),Filepath);//Versao 10 - 3090
                webDown.DownloadFileCompleted += WebDown_DownloadFileCompleted;
            }
            catch (WebException error)
            {
                cUtils.SendEmailAsync("Download Suporte" + "\n" + error.ToString());
                MessageBox.Show("Foi encotrado um problema. um Log foi enviado para o Técnico corrigir.");
            }
        }

        private void WebDown_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            tbxEmailInfo.Text = @"Download Concluído. Inicie novamente o Suporte.";
            tbxEmailInfo.BackColor = System.Drawing.Color.Gold;
            WindowState = FormWindowState.Normal;
        }

        #endregion

        private void frmEmail_Load(object sender, EventArgs e)
        {
            const string TVx86 = @"C:\Program Files (x86)\TeamViewer";
            const string TVx64 = @"C:\Program Files\TeamViewer";

            if (Directory.Exists(TVx86) || Directory.Exists(TVx64))
            {
                btnSuporte.Enabled = false;
                btnSuporte.Text = "Suporte já instalado.";
            }
        }

        private void chkbxReposta_CheckedChanged(object sender, EventArgs e)
        {
            tbxResposta.Enabled = chkbxReposta.CheckState == CheckState.Checked;
        }

    }
}