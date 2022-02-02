using System;
using System.IO.Ports;
using System.Threading;

namespace PK_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnOPEN.Enabled = true;
            btnCLOSE.Enabled = false;
            progressBar1.Value = 0;
            cBoxCOMPORT.Text = "9600";


        }
    }
}