using System;

namespace Logger.Core
{
    public class FileLoggingStrategy : ILoggingStrategy
    {
        protected string FilePath;

        public FileLoggingStrategy(ILogOutputTarget target)
        {
            if (!(target is FileOutputTarget))
                throw new NotSupportedException("File logging requires file as a target");

            FilePath = (target as FileOutputTarget).Path;
        }

        public void Write(string message)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath, true))
            {
                file.WriteLine(message);
            }
        }
    }

    public class FileOutputTarget : ILogOutputTarget
    {
        public string Path { get; set; }
        public OutputMode Mode { get; } = OutputMode.File;
    }
}