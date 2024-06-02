using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApp_ModelsLibrary
{
    public class Message : IComparable<Message>
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


        /// <summary>
        /// Сравниваем сообщения по времени (сначала новые, потом старые)
        /// (Если other равен null, считаем объект большим)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Message? other) =>
            other?.Time.CompareTo(Time) ?? 1;


    }
}
