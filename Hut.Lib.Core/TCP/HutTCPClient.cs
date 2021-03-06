/******************************************************************************
 * Hut Simple TCP Client
 *
 * - just basic client for easy using
 *
 * Author : Daegung Kim
 * Version: 1.0.0
 * Update : 2020-05-08
 ******************************************************************************/

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

        public void Connect(string address, int port)
        {
            try
            {
                client = new TcpClient(address, port)
                {
                    ReceiveTimeout = 5000
                };
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketExecption: {0}", e);
            }
        }

        public void Send(string message)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
        }

        public string Response()
        {
            Byte[] data = new Byte[1024];

            NetworkStream stream = client.GetStream();
            int bytes = stream.Read(data, 0, data.Length);

            return System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        }

        public void Disconnect()
        {
            client.Close();
        }

        public bool IsConnected
        {
            get
            {
                return (client == null) ? (false) : (true);
            }
        }

        public void Dispose()
        {
            ((IDisposable)client).Dispose();
            GC.SuppressFinalize(client);
        }
    }
}