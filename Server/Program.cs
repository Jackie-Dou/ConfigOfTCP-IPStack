using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string adrress = null;
            int port = 0;
            string temp = null;
            bool flag = false;
            Console.WriteLine("Введите IP-адрес:");
            temp = Console.ReadLine();
            if (IsDigitsAndDotOnly(temp)) { 
                adrress = temp;
                flag = true;
            }
            Console.WriteLine("Введите порт:");
            temp = Console.ReadLine();
            if (IsDigitsOnly(temp)) { 
                port = int.Parse(temp);
                flag = true;
            }
            if (flag == true) { 
                TCPServer server = new TCPServer();
                server.Create(adrress, port);
                server.InfoServer();
                server.StartServer();
            }
        }

        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        static bool IsDigitsAndDotOnly(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && c!='.')
                    return false;
            }

            return true;
        }
    }
}