using System.Text.Json;

namespace JsonLogParser.Infrastructure
{
    public class LogParser
    {
        public readonly IConsoleHandler _consoleHandler;
        
        public LogParser(IConsoleHandler consoleHandler)
        {
            _consoleHandler = consoleHandler;
        }

        public void ReadLogs() {
            string line;
            while((line = _consoleHandler.ReadConsole()) != null) {                
                var log = JsonSerializer.Deserialize<Log>(line);
                _consoleHandler.WriteConsole(log.GetFormattedLog());
            }
        }
    }
}
