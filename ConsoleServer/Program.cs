using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Server server = new Server();

            Console.WriteLine("Запуск сервера...");
            Task listenTask = server.ListenAsync();

            //Console.WriteLine("Для остановки сервера нажмите любую клавишу...");
            //Console.ReadKey();
            
            await listenTask;

            server.Disconnect();

            Console.WriteLine("Сервер остановлен.");
        }
    }
}
