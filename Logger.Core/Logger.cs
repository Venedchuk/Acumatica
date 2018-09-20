using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core
{
    public class Logger : ILogger
    {
        public IList<ILogOutputTarget> Targets { get; set; } = new List<ILogOutputTarget>();

        public void Debug(string message)
        {
            WriteMessage(string.Format("{0} [{1}]: {2}", DateTime.Now.ToString(), "DEBUG", message));
        }

        public void Error(string message)
        {
            WriteMessage(string.Format("{0} [{1}]: {2}", DateTime.Now.ToString(), "ERROR", message));
        }

        public void Fatal(string message)
        {
            WriteMessage(string.Format("{0} [{1}]: {2}", DateTime.Now.ToString(), "FATAL", message));
        }

        public void Info(string message)
        {
            WriteMessage(string.Format("{0} [{1}]: {2}", DateTime.Now.ToString(), "INFO", message));
        }

        public void Warn(string message)
        {
            WriteMessage(string.Format("{0} [{1}]: {2}", DateTime.Now.ToString(), "WARN", message));
        }

        protected void WriteMessage(string formattedMessage)
        {
            foreach (var target in Targets)
            {
                var loggingStrategy = SelectStrategy(target);

                loggingStrategy.Write(formattedMessage);
            }
        }

        public ILoggingStrategy SelectStrategy(ILogOutputTarget target)
        {
            ILoggingStrategy result;

            switch (target.Mode)
            {
                case OutputMode.Console:
                    result = new ConsoleLoggingStrategy();
                    break;
                case OutputMode.File:
                    result = new FileLoggingStrategy(target);
                    break;
                case OutputMode.Database:
                    result = new DatabaseLoggingStrategy(target);
                    break;
                default:
                    throw new NotSupportedException(string.Format("Output mode {0} is not supported", target.Mode));
            }

            return result;
        }
    }
}
