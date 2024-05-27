using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmValidar : Form
    {
        private string username = CRegistros.GetComputerName();
        readonly string _date = cUtils.GetInstallDate();

        public frmValidar()
        {
            InitializeComponent();
        }
        private static string EdCode(string Text, bool Encode)
        {
            return (Encode)//SE for True Converte , outro Decodifica
           ? Convert.ToBase64String(Encoding.ASCII.GetBytes(Text))
           : Encoding.ASCII.GetString(Convert.FromBase64String(Text));
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (tbxSerial.Text == "") return;
            tbxinfo.Text = "VERIFICANDO...";
            if (tbxSerial.Text == EdCode(tbxCodMaquina.Text.ToLower(), true))
            {
               tbxinfo.Text = "OK";
               tbxinfo.BackColor = Color.Gold;
               cAtivacao.CriarChaveAtivada();
               Close();
            }
            else
                MessageBox.Show(@"Chave Inválida");
        }

        private void frmValidar_Load(object sender, EventArgs e)
        {
            tbxCodMaquina.Text = EdCode((username+_date).Trim(), true);
            if (!cUtils.ConnectionAvailable())
                btnValidarOnline.Enabled = false;
        }

        private void btnValidarOnline_Click(object sender, EventArgs e)
        {
          cAtivacao.DownloadActivationStatus();// utilizar funçoes de texto
        }

    }
}