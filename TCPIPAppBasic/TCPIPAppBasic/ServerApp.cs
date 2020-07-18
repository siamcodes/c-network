using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp
{
    //Server 
    class ServerApp
    {
        static void Main(string[] args)
        {
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"),9000));
            Console.WriteLine("Wait for Connection");
            sck.Listen(10);
            Socket acc = sck.Accept();
            Console.WriteLine("Connect Complete");
            string message = "Hello World";
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            acc.Send(buffer, 0, buffer.Length, 0);

            //Receive from Client
            buffer = new byte[1024];
            int rec = acc.Receive(buffer, 0, buffer.Length, 0);
            Array.Resize(ref buffer, rec);
            Console.WriteLine("Received: {0}",Encoding.Default.GetString(buffer));
            sck.Close();
            acc.Close();

        }
    }
}
