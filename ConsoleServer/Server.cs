namespace ConsoleServer
{

    class Server
    {
        protected internal void RemoveConnection(string id)
        {
            throw new NotImplementedException();
        }
        // прослушивание входящих подключений
        protected internal async Task ListenAsync()
        {
            throw new NotImplementedException();
        }

        // трансляция сообщения подключенным клиентам
        protected internal async Task BroadcastMessageAsync(string message, string id)
        {
            throw new NotImplementedException();
        }
        // отключение всех клиентов
        protected internal void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}