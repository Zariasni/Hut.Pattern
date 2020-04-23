using System;
using System.Net.Sockets;

namespace Hut
{
    public class HutTCPClient : IDisposable
    {
        private TcpClient client;

        public HutTCPClient()
        {
            client = null;
        }

        public void connect(string address, int port)
        {
            try
            {
                client = new TcpClient(address, port);
                client.ReceiveTimeout = 5000;
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketExecption: {0}", e);
            }
        }

        public void send(string message)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
        }

        public string response()
        {
            Byte[] data = new Byte[1024];

            NetworkStream stream = client.GetStream();
            int bytes = stream.Read(data, 0, data.Length);

            return System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        }

        public void disconnect()
        {
            client.Close();
        }

        public bool isConnected()
        {
            return (client == null) ? (false) : (true);
        }

        public void Dispose()
        {
            ((IDisposable)client).Dispose();
            GC.SuppressFinalize(client);
        }
    }
}