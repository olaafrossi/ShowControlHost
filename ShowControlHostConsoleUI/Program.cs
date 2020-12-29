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
            link.DataReceived += Link_DataReceived;
        }

        private static void Link_DataReceived(object sender, EventArgs e)
        {
            // do something with event handler later
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

        static void Main(string[] args)
        {
            SetupSCS();
            SendSCSSingleTime();

            //wait here
            Console.ReadLine();
        }
    }
}
