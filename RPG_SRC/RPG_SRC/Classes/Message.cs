using System;

namespace RPG_SRC.Classes
{
    public static class Message
    {
        public static void Danger(this string message)
        {
            Log(message, ConsoleColor.Red);
        }

        public static void Warning(this string message)
        {
            Log(message, ConsoleColor.Yellow);
        }

        public static void Success(this string message)
        {
            Log(message, ConsoleColor.Green);
        }

        private static void Log(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
