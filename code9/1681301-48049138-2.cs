    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO.Ports;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                SerialPort _serialPort = new SerialPort("COM5");
                _serialPort.BaudRate = 115200;
                _serialPort.Parity = Parity.None;
                _serialPort.StopBits = StopBits.One;
                _serialPort.DataBits = 8;
                _serialPort.Handshake = Handshake.None;
                _serialPort.DtrEnable = true;
                _serialPort.RtsEnable = true;
                _serialPort.DataReceived += (AsyncRead);
                _serialPort.Open();
            }
            string inputData = "";
            private void AsyncRead(object sender, SerialDataReceivedEventArgs e)
            {
                SerialPort serialPort = sender as SerialPort;
                string inData = serialPort.ReadExisting();
                inputData += inData;
                int returnIndex = inputData.IndexOf('\n');
                if(returnIndex >= 0)
                {
                    string command = inputData.Substring(0, returnIndex);
                    //remove command from inputData
                    inputData = inputData.Substring(returnIndex + 1);
                    
                    //test if command is just a return
                    if (command.Length > 0)
                    {
                        ProcessCommand(command);
                    }
                }
            }
            private void ProcessCommand(string inputLine)
            {
            }
        }
    }
