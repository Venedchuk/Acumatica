using System;

namespace Logger.Core
{
    public class DatabaseLoggingStrategy : ILoggingStrategy
    {
        protected Action<string> WriteCallback;

        public DatabaseLoggingStrategy(ILogOutputTarget target)
        {
            if (!(target is DatabaseOutputTarget))
                throw new NotSupportedException("File logging requires file as a target");

            WriteCallback = (target as DatabaseOutputTarget).Callback;
        }

        public void Write(string message)
        {
            WriteCallback(message);
        }
    }

    public class DatabaseOutputTarget : ILogOutputTarget
    {
        public Action<string> Callback { get; set; }
        
        public OutputMode Mode { get; } = OutputMode.Database;
    }
}