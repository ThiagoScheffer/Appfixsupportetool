using System;
using System.Windows.Forms;

namespace Suporte
{
    public partial class frmControledoCliente : Form
    {
        public frmControledoCliente()
        {
            InitializeComponent();
        }

        private void btnControlePagamentos_Click(object sender, EventArgs e)
        {
            Program.PagButtonPressed = true;
            frmPagamento frmPagamento = new frmPagamento();
            Close();
            frmPagamento.ShowDialog();
       
        }

        private void btnControleSituacao_Click(object sender, EventArgs e)
        {
            frmControledeSituacao frmControledeSituacao = new frmControledeSituacao();
            frmControledeSituacao.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
