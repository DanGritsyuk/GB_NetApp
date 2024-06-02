using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using YY_Tasks.Extensions;

namespace ConsoleClient
{
    internal class ChatUI
    {
        private int _leftStartCursorPosition;
        private int _topStartCursorPosition;
        private int _lastMessageCount;

        public ChatUI()
        {
            (_leftStartCursorPosition, _topStartCursorPosition) = Console.GetCursorPosition();
            _lastMessageCount = 0;
        }

        public void StartRenderChat()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("Введите сообщение:");
        }

        public string RenderMessageInput()
        {
            var currentPosition = Console.GetCursorPosition();
            string message = Console.ReadLine()!;
            Console.SetCursorPosition(currentPosition.Left, currentPosition.Top);
            Console.WriteLine(" ".Repeat(message.Length));
            Console.SetCursorPosition(currentPosition.Left, currentPosition.Top);


            return message;
        }

        public void RenderReceiveMessage(string? text)
        {
            if (string.IsNullOrEmpty(text)) return;

            var currentPosition = Console.GetCursorPosition();

            Console.SetCursorPosition(_leftStartCursorPosition, _topStartCursorPosition);
            Console.WriteLine(" ".Repeat(_lastMessageCount));
            Console.SetCursorPosition(_leftStartCursorPosition, _topStartCursorPosition);
            Console.WriteLine(text);
            Console.SetCursorPosition(currentPosition.Left, currentPosition.Top);

            _lastMessageCount = text.Length;
        }
    }
}
