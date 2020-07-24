using JsonLogParser.Infrastructure.Dao;
using JsonLogParser.Infrastructure.Dto;

namespace JsonLogParser.Infrastructure
{
    public class LogFormatMapper : ILogFormatMapper
    {
        public LogFormat ConvertFromBpsLogFormat(BpsLogFormat bpsLogFormat)
            => new LogFormat
            {
                EventId = bpsLogFormat.EventId,
                Exception = bpsLogFormat.Exception,
                Level = bpsLogFormat.Level,
                Message = bpsLogFormat.Message,
                TimeStamp = bpsLogFormat.TimeStamp
            };

        public LogFormat ConvertFromBpeLogFormat(BpeLogFormat bpeLogFormat)
            => new LogFormat
            {
                EventId = bpeLogFormat.EventId,
                Exception = bpeLogFormat.Exception,
                Level = bpeLogFormat.Level,
                Message = bpeLogFormat.Message,
                TimeStamp = bpeLogFormat.TimeStamp
            };
    }
}
