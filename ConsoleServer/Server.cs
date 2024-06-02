using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleServer
{
    class Server
    {
        private List<TcpClient> _clients;
        private TcpListener _listener;
        private CancellationToken _cancellationToken;

        public Server()
        {
            _clients = new List<TcpClient>();
            _cancellationToken = CancellationToken.None;
            _listener = new TcpListener(IPAddress.Any, 8888);
        }

        protected internal void RemoveConnection(string id)
        {
            TcpClient? client = _clients.FirstOrDefault(c => c.Client.RemoteEndPoint!.ToString() == id);

            if (client != null)
            {
                _clients.Remove(client);
                client.Close();
            }
        }

        protected internal async Task ListenAsync()
        {
            try
            {
                _listener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                Task? processClientTask = null;

                while (!_cancellationToken.IsCancellationRequested)
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync();
                    _clients.Add(client);
                    Console.WriteLine("Подключен клиент: " + client.Client.RemoteEndPoint!.ToString());

                    processClientTask = Task.Run(() => ProcessClientAsync(client, _cancellationToken));
                }
                if (processClientTask != null)
                    await processClientTask;
            }
            catch (Exception ex) when (!_cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected internal async Task BroadcastMessageAsync(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            foreach (TcpClient client in _clients)
            {
                if (client.Client.RemoteEndPoint!.ToString() != id)
                {
                    try
                    {
                        await client.GetStream().WriteAsync(data, 0, data.Length);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при отправке сообщения: " + ex.Message);
                    }
                }
            }
        }

        protected internal void Disconnect()
        {
            _listener.Stop();

            foreach (TcpClient client in _clients)
            {
                client.Close();
            }
            _clients.Clear();
        }

        private async Task ProcessClientAsync(TcpClient client, CancellationToken cancellationToken)
        {
            try
            {
                NetworkStream stream = client.GetStream();

                while (!cancellationToken.IsCancellationRequested)
                {
                    byte[] data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;

                    do
                    {
                        bytes = await stream.ReadAsync(data, 0, data.Length, cancellationToken);
                        builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable && !cancellationToken.IsCancellationRequested);

                    string message = builder.ToString();
                    Console.WriteLine("Получено сообщение: " + message);
                    await BroadcastMessageAsync(message, client.Client.RemoteEndPoint!.ToString()!);
                }
            }
            catch (Exception ex) when (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}