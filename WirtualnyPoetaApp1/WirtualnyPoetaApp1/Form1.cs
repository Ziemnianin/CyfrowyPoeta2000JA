using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace WirtualnyPoetaApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Client.checkbox1 = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Client.checkbox2 = checkBox2.Checked;

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Client.checkbox3 = checkBox3.Checked;

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Client.checkbox4 = checkBox4.Checked;

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Client.checkbox5 = checkBox5.Checked;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void connect_Click(object sender, EventArgs e)
        {
            textBox4.Text = "Próba połączenia";
            //TO DO client + messages load input output etc
            Client client = new Client();

            Client.StartClient();
            textBox4.Text = Client.message;
            textBox2.Text = Client.show;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Client.tekst = textBox1.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

            if (Regex.IsMatch(textBox3.Text, pattern))
            {
                //valid ip
                IPAddress.TryParse(textBox3.Text, out Client.ipAddress);
                textBox4.Text = "IP OK";
            }
            else
            {
                //is not valid ip

                textBox4.Text = "IP niepoprawne";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
