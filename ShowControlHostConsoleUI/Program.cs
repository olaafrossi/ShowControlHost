using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreeByte;
using ThreeByte.Network;

namespace ShowControlHostConsoleUI
{
    class Program
    {
        private static ThreeByte.Network.AsyncNetworkLink link;

        public static void SetupSCS()
        {
            // this creates the TCP connection and event handler
            link = new ThreeByte.Network.AsyncNetworkLink("localhost", 8080, true);
            link.DataReceived += LinkOnDataReceived;
        }

        private static void LinkOnDataReceived(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        static void SendSCSSingleTime()
        {
            string message = string.Empty;
            message = "hello\r";
            Thread.Sleep(1000);
            if (link.Enabled && link.IsConnected)
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(message); // new byte array and feed it the input string
                link.SendMessage(inputBytes); // send the byte array
            }
            else
            {
                Console.WriteLine("SCS not connected");
            }

            Console.WriteLine($"Sent to SCS {message}");
        }

        static void SendSCSMultiTime()
        {
            string message = string.Empty;
            int messageAdder = 1;
            
            
            Thread.Sleep(1000);
            if (link.Enabled && link.IsConnected)
            {
                for (int i = 0; i < 200; i++)
                {
                    byte[] inputBytes = Encoding.ASCII.GetBytes(message); // new byte array and feed it the input string
                    link.SendMessage(inputBytes); // send the byte array
                    messageAdder++;
                    message = $"hello{messageAdder}\r";
                    Thread.Sleep(5);
                    Console.WriteLine($"Sent to SCS {message}");
                }
            }
            else
            {
                Console.WriteLine("SCS not connected");
            }

            // Console.WriteLine($"Sent to SCS {message}");
        }

        static void Main(string[] args)
        {
            SetupSCS();
            SendSCSMultiTime();
            //SendSCSSingleTime();

            //wait here
            Console.ReadLine();
        }
    }
}
