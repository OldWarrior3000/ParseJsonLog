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
                var log = DeserializeLog(line);

                if (log != null)
                    _consoleHandler.WriteConsole(log.GetFormattedLog());
            }
        }

        private Log DeserializeLog(string line)
        {
            try
            {
                return JsonSerializer.Deserialize<Log>(line);
            }
            catch (JsonException je)
            {
                _consoleHandler.WriteConsole($@"Json could not be parsed. Message {je.Message}");
                return null;
            }
        }
    }
}
