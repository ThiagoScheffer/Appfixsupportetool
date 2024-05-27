using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * DispatcherTimer timer;
        private int counter = 60;
        public MainPage()
        {
            this.InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, object e)
        {

            textbox.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, () => { textbox.Text = counter.ToString(); ; });
            counter--;
        }
 */
using System.Windows.Threading;
namespace Suporte
{

    //Usar uma thread para iniciar a contagem = bgroundworker
    //hide no form atual ao fechar.
    //se for abrir novamente verificar se esta null ou ja existe o form e entao abrir novamente/unhide
    public partial class frmAutoShutdown : Form
    {
        private string ShutdownValue = "Desligamento Desativado";
        private DispatcherTimer mainTimer;
        public frmAutoShutdown(string value)
        {
            InitializeComponent();
        }

        public string TValue
        {
            get { return ShutdownValue; }
            private set { ShutdownValue = value; }
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (mainTimer != null && mainTimer.IsEnabled)
                return;

            mainTimer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
            TValue = "Desligamento Ativado";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (mainTimer != null) mainTimer.Stop();
            mainTimer = null;

            Process.Start("shutdown", "/a");
            TValue = "-";
            tbxContador.Text = " ";
            MessageBox.Show(@"Desligamento cancelado.");
            //Close();
        }

        private void frmAutoShutdown_Load(object sender, EventArgs e)
        {
            if (TValue == "Desligamento Desativado")
            {
                dtpSetTime.Value = DateTime.Now;
            }
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(dtpSetTime.Value);
            tbxContador.Text = string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            if (tbxContador.Text == @"00:00:00")
            {
                Process.Start("shutdown", "/s /t 20 /f");
                if (mainTimer != null) mainTimer.Stop();
                //MessageBox.Show(@"Desligando");
            }
        }

        private void frmAutoShutdown_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (mainTimer != null && mainTimer.IsEnabled)
            //{
            //    e.Cancel = true;
            //    Close();
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private void WorkerAlarm_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    if (WorkerAlarm.CancellationPending)
        //    {
        //        e.Cancel = true;
        //    }else
        //    {
        //        TValue = "Desligamento Ativado";
        //        MainTimer.Enabled = true;
        //    }
        //}

    }
}
