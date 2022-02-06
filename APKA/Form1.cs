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

namespace APKA
{
    public partial class Form1 : Form
    {
        string dataOut;
        string DataIn;
        string Textval;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
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
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.AddRange(ports);
        }

        private void btnSEND_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                dataOut = trackBar1.Value.ToString();
                serialPort1.WriteLine(dataOut);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackbar_label.Text = trackBar1.Value.ToString();
        }

        private void cBoxCOMPORT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSTOP_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar.Value = 0;
            }
        }
        private void btnRECEIVE_Click(object sender, EventArgs e)
        {
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataIn = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(ShowData));
        }

        private void ShowData(object sender, EventArgs e)
        {
            //textBox.Text += DataIn +"\n";
            textBox.AppendText(DataIn);
            System.Threading.Thread.Sleep(20);
        }
    }
}
