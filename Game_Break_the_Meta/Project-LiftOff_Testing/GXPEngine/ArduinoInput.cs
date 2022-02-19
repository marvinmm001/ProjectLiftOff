using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;

namespace GXPEngine
{ 
   public class ArduinoInput : GameObject
    {
        private SerialPort port;
        public static int leverValue;
            
        bool open;
        
        public ArduinoInput() {
            //Setup of the serial port connection:
            port = new SerialPort();
            port.PortName = "COM3";
            port.BaudRate = 9600;
            port.DataReceived += new SerialDataReceivedEventHandler(serialEvent);
            
            FindPort();
        }
        void Update() {
                
            if (open)
            {
               // serialEvent();
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


        public float GetLeverValue()
        {
            return leverValue;
        }



        private static void serialEvent(
                          object sender,
                          SerialDataReceivedEventArgs e)
        {
            // reads multipe inputs from serial:
            SerialPort port = (SerialPort)sender;
            //Console.WriteLine("port.BytesToRead = {0}", port.BytesToRead);
             if (port.BytesToRead > 0) {
                string incomingData = port.ReadLine();
                incomingData = incomingData.Trim();
                try
                {
                    ArduinoInput.leverValue = int.Parse(incomingData);
                    Console.WriteLine(leverValue);
                }
                catch (Exception bruh)
                { }
            }
        }
    }
}
