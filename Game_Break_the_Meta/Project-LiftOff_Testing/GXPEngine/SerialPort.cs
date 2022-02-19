using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;

namespace GXPEngine
{
    /*internal class SerialReader : GameObject
    {
        private SerialPort port;
        private string data;
        private int[] incomingValues = new int [1];
        bool open;
        int leverValue;

        //BUTTON
        //bool[] IsButtonRealeased = new bool[3];

        //ANALOG
        int previousAnalog = 0;
        *//*int treshold = 30;
        int upperTreshold = 250;*//*
        int treshold = 100;
        int upperTreshold = 800;
        
        public SerialReader() {
            //Setup of the serial port connection:
            port = new SerialPort();
            port.PortName = "COM3";
            port.BaudRate = 9600;
            //port.BaudRate = 5600;
            FindPort();
        }
        void Update() {
            //int angle = incomingValues[0];
            //int left = incomingValues[1];
            //int jump = incomingValues[3];
            //int right = incomingValues[2];
           
            *//*foreach (bool val in IsButtonRealeased)
            {
                
            }*//*
                
            if (open)
            {
                //serialEvent(angle, left, right, jump);
                //Console.WriteLine(angle + ", " + left + ", " + right + ", " + jump);

                serialEvent();
                Console.WriteLine(leverValue);
                
            }
            else {

            }
        }

        private void FindPort() {
            try
            {
                port.Open();
                open = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Could not find serial port.");
                open = false;
            }
        }



        void serialEvent( *//*int angle, int left, int right, int jump*//*)
        {
            // reads multipe inputs from serial:
            if (port.BytesToRead > 0) {
                string incomingData = port.ReadLine();
                incomingData = incomingData.Trim();
                try
                {
                    leverValue = int.Parse(incomingData);
                }
                catch (Exception bruh)
                { }
            }
        }
    }*/
}
