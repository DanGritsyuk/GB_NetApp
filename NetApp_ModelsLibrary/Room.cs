using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApp_ModelsLibrary
{
    public class Room
    {
        public Room(int id, string roomName)
        {
            RoomName = roomName;
            Id = id;
            SecretKey = Guid.NewGuid();
            Messages = new List<Message>();
            CurrentUsers = new List<User>();
        }

        public int Id { get;  }
        public string RoomName { get; set; }
        public Guid SecretKey { get; set; }
        public List<Message> Messages { get; private set; }
        public List<User> CurrentUsers { get; private set; }
    }
}
