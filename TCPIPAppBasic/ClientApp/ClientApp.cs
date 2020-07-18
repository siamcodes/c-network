using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientApp
{
    class ClientApp
    {
        static void Main(string[] args)
        {
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
            sck.Connect(endpoint);
            Console.Write("Enter Message: ");
            string msg = Console.ReadLine();
            byte[] msgBuffer = Encoding.ASCII.GetBytes(msg);
            sck.Send(msgBuffer,0,msgBuffer.Length,0);

            //รับมาจาก Server
            byte[] buffer = new byte[1024];
            int rec = sck.Receive(buffer, 0, buffer.Length, 0);
            Array.Resize(ref buffer, rec);
            Console.WriteLine("Receive: {0}", Encoding.Default.GetString(buffer));
            sck.Close();
            Console.Read();

        }
    }
}
