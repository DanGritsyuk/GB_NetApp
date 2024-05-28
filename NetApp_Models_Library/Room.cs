namespace NetApp_ModelsLibrary
{
    public class Room
    {
        public Room(string roomName)
        {
            RoomName = roomName;
            RoomId = _roomId++;
            SecretKey = Guid.NewGuid();
            Messages = new List<Message>();
            CurrentUsers = new List<User>();
        }

        public int RoomId { get; set; }
        private static int _roomId = 0;
        public string RoomName { get; set; }
        public Guid SecretKey { get; set; }
        public List<Message> Messages { get; set; }
        public List<User> CurrentUsers { get; set; }
    }
}
