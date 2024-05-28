namespace NetApp_ModelsLibrary
{
    public class User
    {
        private readonly int _id;

        public User(int id, string username, string connectionId)
        {
            _id = id;
            Username = username;
            ConnectionId = connectionId;
        }

        public int Id { get => _id; }
        public string Username { get; set; }
        public string ConnectionId { get; set; }
    }
}
