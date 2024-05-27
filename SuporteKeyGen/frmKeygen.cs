using System;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace SuporteKeyGen
{
    public partial class frmKeygen : Form
    {
        private static readonly ManagementObjectSearcher _oSname = new ManagementObjectSearcher("select * from win32_operatingsystem");
        internal frmKeygen()
        {
            InitializeComponent();
        }

        public static string GetInstallDate()
        {
            string data = null;
            foreach (ManagementObject os in _oSname.Get())
            {
                data = ManagementDateTimeConverter.ToDateTime(os["InstallDate"].ToString()).ToString();
            }
            return data;
        }

        private static string EDCode(string Text, bool Encode)
        {
            return (Encode)//SE for True Converte , outro Decodifica
                       ? Convert.ToBase64String(Encoding.ASCII.GetBytes(Text))
                       : Encoding.ASCII.GetString(Convert.FromBase64String(Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = EDCode(maskedTextBox1.Text.ToLower(), true);
        }
    }
}