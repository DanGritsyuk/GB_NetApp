using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApp_ModelsLibrary
{
    public class Room
    {
        private readonly int _id;

        public Room(int id, string roomName)
        {
            RoomName = roomName;
            _id = id;
            SecretKey = Guid.NewGuid();
            Messages = new List<Message>();
            CurrentUsers = new List<User>();
        }

        public int Id { get => _id;  }
        public string RoomName { get; set; }
        public Guid SecretKey { get; set; }
        public List<Message> Messages { get; set; }
        public List<User> CurrentUsers { get; set; }
    }
}
