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

namespace AgroQuad
{
    public partial class WelcomePage : Form
    {
        
        public WelcomePage()
        {
            InitializeComponent();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(getSerialPorts());
            BaudRateItemsList();
         }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        String[] getSerialPorts()
        {
            return SerialPort.GetPortNames();
        }

        void BaudRateItemsList()
        {
            BaudRate.Items.Add(300);
            BaudRate.Items.Add(600);
            BaudRate.Items.Add(1200);
            BaudRate.Items.Add(2400);
            BaudRate.Items.Add(9600);
            BaudRate.Items.Add(14400);
            BaudRate.Items.Add(19200);
            BaudRate.Items.Add(38400);
            BaudRate.Items.Add(57600);
            BaudRate.Items.Add(115200);
            BaudRate.Items.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(getSerialPorts());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                String Port_Name = comboBox1.Text;
                Quad_SerialPort.PortName = Port_Name;
                int BaudRate_Int = 0;
                if (BaudRate.SelectedIndex > -1)
                {
                    int.TryParse(BaudRate.Text, out BaudRate_Int);
                    Quad_SerialPort.BaudRate = BaudRate_Int;
                    Quad_SerialPort.Open();
                    if (Quad_SerialPort.IsOpen)
                    {
                        MessageBox.Show("Connection Established!");
                        Quad_SerialPort.Close();
                        this.Hide();
                        Form2 newscrn = new Form2(Port_Name, BaudRate_Int);
                        newscrn.Show();
                    }
                    else
                    {
                        MessageBox.Show("Check the COM Port Status Again.");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select the Baud Rate");
                }

            }

            else
            {
                MessageBox.Show("Please Select a COM Port");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
