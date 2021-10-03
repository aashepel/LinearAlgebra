using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LinearAlgebraLogger
{
    enum LoggerColor
    {
        Info = ConsoleColor.Green,
        Warning = ConsoleColor.Yellow,
        Error = ConsoleColor.Red,
        Debug = ConsoleColor.Blue
    }
    public static class Logger
    {
        public static void LogInfo(string message)
        {
            WriteColor("Info: ", message, LoggerColor.Info);
        }
        public static void LogWarning(string message)
        {
            WriteColor("Warning: ", message, LoggerColor.Warning);
        }
        public static void LogError(string message)
        {
            WriteColor("Error: ", message, LoggerColor.Error);
        }
        public static void LogDebug(string message)
        {
            WriteColor("Error: ", message, LoggerColor.Error);
        }
        private static void WriteColor(string header, string message, LoggerColor color)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            Console.WriteLine(header);
            Console.ResetColor();
            Console.WriteLine(new string(' ', 6) + message);
        }
    }
}
