using System.Net.Sockets;
using System.Net;

namespace ConsoleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IPAddress serverIp = IPAddress.Parse("127.0.0.1");
            IPAddress localAddress = IPAddress.Parse("127.0.0.1");
            int serverPort = 8888;
            int localPort = 0;


            Console.Write("Укажите локальный порт: ");
            if (!int.TryParse(Console.ReadLine(), out localPort))
            {
                localPort = 12345;
                Console.WriteLine($"некорректно введен порт. Будет использован {localPort}");
            }

            TcpClient client = new TcpClient(new IPEndPoint(localAddress, localPort));

            bool connected = false;

            while (!connected)
            {
                try
                {
                    await client.ConnectAsync(serverIp, serverPort);
                    connected = true;
                }
                catch (SocketException)
                {
                    Console.WriteLine("Не удалось подключиться к серверу. Повторная попытка...");
                    await Task.Delay(1000);
                }
            }

            Client clientHandler = new Client(client);
            await clientHandler.ProcessAsync();
        }
    }
}
