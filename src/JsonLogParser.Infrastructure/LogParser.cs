using System;
using System.Text.Json;
using JsonLogParser.Infrastructure.Configuration;
using JsonLogParser.Infrastructure.Dao;
using JsonLogParser.Infrastructure.Dto;
using Microsoft.Extensions.Options;

namespace JsonLogParser.Infrastructure
{
    public class LogParser
    {
        public readonly IConsoleHandler _consoleHandler;
        private readonly ILogFormatMapper _logFormatMapper;
        private readonly IOptions<LogConfiguration> _logConfiguration;

        public LogParser(IConsoleHandler consoleHandler, ILogFormatMapper logFormatMapper, 
            IOptions<LogConfiguration> logConfiguration)
        {
            _consoleHandler = consoleHandler;
            _logFormatMapper = logFormatMapper;
            _logConfiguration = logConfiguration;
        }

        public void ReadLogs() {
            string line;
            while((line = _consoleHandler.ReadConsole()) != null) {                
                var log = DeserializeLog(line);

                if (log != null)
                    _consoleHandler.WriteConsole(log.GetFormattedLog());
            }
        }

        private LogFormat DeserializeLog(string line)
        {
            try
            {
                switch (_logConfiguration.Value.LogSource)
                {
                    case LogSource.Bps:
                    {
                        var log = JsonSerializer.Deserialize<BpsLogFormat>(line);
                        return _logFormatMapper.ConvertFromBpsLogFormat(log);
                    }
                    case LogSource.Bpe:
                    {
                        var log = JsonSerializer.Deserialize<BpeLogFormat>(line);
                        return _logFormatMapper.ConvertFromBpeLogFormat(log);
                    }
                    default:
                        throw new NotImplementedException($"LogSource {_logConfiguration.Value.LogSource} is not supported");
                }
            }
            catch (JsonException je)
            {
                _consoleHandler.WriteConsole($@"Json could not be parsed. Message {je.Message}");
                return null;
            }
        }
    }
}
