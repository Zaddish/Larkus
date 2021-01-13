using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using Client.Commands;

namespace Client
{
    class Program
    {
        private static Socket s;
        private static CommandHandler ch;
        static void Main(string[] args)
        {
            ch = new CommandHandler();

            s = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
            s.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            s.Bind(new IPEndPoint(IPAddress.IPv6Any, 1234));

            Task t = Task.Factory.StartNew(ClientListen);

            Console.WriteLine("...");
            Console.ReadKey();


            static void ClientListen()
            {

                IPEndPoint ipep = new IPEndPoint(IPAddress.IPv6Any, 0);
                EndPoint ep = ipep as EndPoint;
                Byte[] data = new byte[65535];
                // storing all data from packet we're listening for
                s.ReceiveFrom(data, ref ep);
                List<Byte> bytes = new List<Byte>(data);
                bytes.RemoveAll(b => b == 0);
                Console.WriteLine(ch.RunCommand(Encoding.ASCII.GetString(bytes.ToArray())));
                ClientListen();




            }

        }
    }
}
