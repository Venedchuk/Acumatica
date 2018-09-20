namespace Logger.Core
{
    public interface ILoggingStrategy
    {
        void Write(string message);
    }
}