using NetApp_ModelsLibrary;
using System.Net.Sockets;
using System.Text;

namespace ConsoleClient
{
    class Client
    {
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;
        private ChatUI _chatUI;

        public Client(TcpClient client)
        {
            _client = client;
            NetworkStream stream = _client.GetStream();
            _reader = new StreamReader(stream, Encoding.UTF8);
            _writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
            _chatUI = new ChatUI();
        }

        public async Task ProcessAsync()
        {
            try
            {
                //Task? ReceiveMessageTask = null;                
                var startProcess = true;
                _chatUI.StartRenderChat();

                while (startProcess)
                {
                    string message = _chatUI.RenderMessageInput();
                    await SendMessageAsync(message);

                    Task ReceiveMessageTask = ReceiveMessageAsync();
                }
                //if (ReceiveMessageTask != null)
                //    await ReceiveMessageTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            finally
            {

                _client.Close();
            }
        }

        private async Task SendMessageAsync(string? message)
        {
            await _writer.WriteLineAsync(message);
            await _writer.FlushAsync();

        }



        private async Task ReceiveMessageAsync() =>
            _chatUI.RenderReceiveMessage(await _reader.ReadLineAsync());
    }
}