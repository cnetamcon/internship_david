using Core.Logs;
using System;

namespace Core.Managers
{
    public class ConsoleMessagePrinter
    {
        ConsoleColor _defaultColor;
        object _consoleLocker;

        public ConsoleMessagePrinter()
        {
            _defaultColor = Console.ForegroundColor;
            _consoleLocker = new object();
        }

        public void Print(string message, Core.Logs.TypeMessage type)
        {
            lock (_consoleLocker)
            {
                Console.ForegroundColor = GetColor(type);
                Console.WriteLine(message);
                Console.ForegroundColor = _defaultColor;
            }
        }

        private ConsoleColor GetColor(TypeMessage type)
        {
            switch (type)
            {
                case TypeMessage.Message: return ConsoleColor.Gray;
                case TypeMessage.Error: return ConsoleColor.Red;
                case TypeMessage.Warning: return ConsoleColor.Magenta;
                case TypeMessage.Request: return ConsoleColor.Blue;
                case TypeMessage.Success: return ConsoleColor.Green;

                default: return ConsoleColor.Gray;
            }
        }
    }
}
