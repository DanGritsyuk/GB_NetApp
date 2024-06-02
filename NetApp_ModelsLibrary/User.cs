namespace NetApp_ModelsLibrary
{
    public class User
    {
        public User(int id, string username, string connectionId)
        {
            Id = id;
            Username = username;
            ConnectionId = connectionId;
        }

        public int Id { get;}
        public string Username { get; set; }
        public string ConnectionId { get; set; }
    }
}
