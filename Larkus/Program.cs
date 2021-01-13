using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Larkus
{
    class Program
    {
        static void Main(string[] args){
            Console.WriteLine("Welcome to your control panel!");

        sendCmd:
            sendCmd(Console.ReadLine());
            //Console.ReadKey();
            goto sendCmd;
        }

        public static void sendCmd(string cmd)
        {
            Socket s = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
            s.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            Byte[] data = Encoding.ASCII.GetBytes(cmd);
            s.SendTo(data, ipep);


        }

    }
    
}
