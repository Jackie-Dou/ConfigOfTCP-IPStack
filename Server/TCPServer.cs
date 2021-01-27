using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class TCPServer
    {
        static string IPaddress { get; set; }
        static int port { get; set; }
        static TcpListener listener;

        public void Create(string adress, int ip_port)
        {
            IPaddress = adress;
            port = ip_port;
        }
        public void InfoServer()
        {
            Console.WriteLine("IP-адрес server: " +  IPaddress);
            Console.WriteLine("Порт server: " + port);
            Console.WriteLine("");
        }
        public void StartServer()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse(IPaddress), port);
                listener.Start();
                Console.WriteLine("Ожидание подключений...");
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
    }
}