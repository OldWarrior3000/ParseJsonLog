using JsonLogParser.Infrastructure;

namespace JsonLogParser
{
#pragma warning disable S1118 // Utility classes should not have public constructors
    internal class Program
#pragma warning restore S1118 // Utility classes should not have public constructors
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
            => new LogParser(new ConsoleHandler()).ReadLogs();
    }
}
