using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class TCPClient
    {
        int port;
        string address;

        string message = "";

        public void CreateClient(string ip_address, int ip_port)
        {
            port = ip_port;
            address = ip_address;
        }

        public void StartClient(string code)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();

                string message_client = code;
                // преобразуем сообщение в массив байтов
                byte[] data = Encoding.Unicode.GetBytes(message_client);
                // отправка сообщения
                stream.Write(data, 0, data.Length);

                // получаем ответ
                data = new byte[64]; // буфер для получаемых данных
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                message = builder.ToString();

                client.Close();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string GetMessage()
        {
            return message;
        }

    }
}