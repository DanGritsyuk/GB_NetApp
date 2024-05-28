namespace NetApp_ModelsLibrary
{
    public class Message
    {
        public Message(int userId, string text)
        {
            UserId = userId;
            MessageText = text;
            Time = DateTime.Now;
        }

        public int UserId { get; }
        public string MessageText { get; set; }
        public DateTime Time { get; }
    }
}
