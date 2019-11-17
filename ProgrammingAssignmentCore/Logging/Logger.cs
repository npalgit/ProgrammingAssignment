using System;

namespace ProgrammingAssignmentCore
{
    public interface ILogger
    {
        void Log(LogLevel level, string message, Exception exception = null);
        void LogInfo(string message);
        void LogError(string message);
    }
    public class Logger : ILogger
    {
        public void Log(LogLevel level, string message, Exception exception = null)
        {
    
            switch(level)
            {
                case LogLevel.Info:
                    LogInfo(message);
                    break;
                case LogLevel.Error:
                    LogError(message);
                    break;
                default:
                    Console.WriteLine("Not a valid logLevel");
                    break;
            }
        }
        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#Info: {0}", message);
            Console.ResetColor();
        }
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("#Error: {0}", message);
            Console.ResetColor();
        }
    }
    public enum LogLevel : short
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Error = 3
    }
}
