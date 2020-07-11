namespace JsonLogParser.Infrastructure
{
    public interface IConsoleHandler
    {
        string ReadConsole();
        void WriteConsole(string input);
    }
}