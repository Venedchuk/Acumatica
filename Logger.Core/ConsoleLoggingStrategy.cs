using System;

namespace Logger.Core
{
    public class ConsoleLoggingStrategy : ILoggingStrategy
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
    }

    public class ConsoleOutputTarget : ILogOutputTarget
    {
        public OutputMode Mode { get; } = OutputMode.Console;
    }
}