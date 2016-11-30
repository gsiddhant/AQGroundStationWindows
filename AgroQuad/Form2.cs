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
using System.Timers;

namespace AgroQuad
{
    public partial class Form2 : Form
    {
        string Status, DataRequest;
        public Form2(string COMPort, int Baud_Rate)
        {
            InitializeComponent();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            Quad_SerialPort.PortName = COMPort;
            Quad_SerialPort.BaudRate = Baud_Rate;
            Quad_SerialPort.Open();
            if (Quad_SerialPort.IsOpen)
            {
                progressBar1.Value = 20;
                Connection_ListBox.Items.Add("Connected to the Device");
                Connection_ListBox.Items.Add("Trying to Communicate...");
                GetCommunicationStatus();
            }
            else
            {
                MessageBox.Show("An Error Occurred while Connecting to the Device", "Failed to Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            WelcomePage mainscrn = new WelcomePage();
            mainscrn.Show();
        }

        void GetCommunicationStatus()
        {
            Quad_SerialPort.Write("c");
            for (int i = 0; i < 100000; i++) ;
            try
            {
                Status = Quad_SerialPort.ReadLine();
                Status.Trim();
                Connection_ListBox.Items.Add("Data Received");
            }
            catch (TimeoutException)
            {
                Connection_ListBox.Items.Add("Timeout Exception Occurred");
            }
            //Connection_ListBox.Items.Add("Status:");
            Connection_ListBox.Items.Add("\n\n");
            Connection_ListBox.Items.Add(Status);
            Connection_ListBox.Items.Add("\n\n");
            if (Status == "Granted")
            {
                progressBar1.Value = 40;
                Connection_ListBox.Items.Add("Access Granted");
                Quad_SerialPort.Write("b");
                try
                {
                    DataRequest = Quad_SerialPort.ReadLine();
                    DataRequest.Trim();
                }
                catch(TimeoutException)
                {
                    Connection_ListBox.Items.Add("Timeout Exception Occurred");
                }
                if (DataRequest == "Request Granted")
                {
                    progressBar1.Value = 70;
                    Connection_ListBox.Items.Add("Exchanging Data");
                    /*

                        Check Code Here

                    */
                }
                else
                {
                    Connection_ListBox.Items.Add("Invalid Data");
                    //MessageBox.Show("An Error Occurred while Trying to Exchange Data with the Device", "Data Sharing Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.Close();
                }
            }
            else
            {
                Connection_ListBox.Items.Add("Invalid Data");
                //MessageBox.Show("An Error Occurred while Connecting to the Device", "Failed to Communicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Connection_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
