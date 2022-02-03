using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; 


namespace PK_appxd
{

    public partial class Form1 : Form
    {
        string dataOut;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports =SerialPort.GetPortNames();
            cBoxCOMPORT.Items.AddRange(ports);

        }

        private void cBoxBAUDRATE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOPEN_Click(object sender, EventArgs e)
        {
            try
            {
                string parity1 = "0";
                string Stopbits = "1";
                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = Convert.ToInt32(cBoxBAUDRATE.Text);
                serialPort1.DataBits = 8;
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), parity1);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Stopbits);

                serialPort1.Open();
                progressBar.Value = 100;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar.Value = 0;
            }
        }

        private void btnSEND_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                dataOut = textBox.Text;
                serialPort1.WriteLine(dataOut);
            }
        }
    }
}
