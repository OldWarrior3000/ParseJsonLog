using System;

namespace JsonLogParser.Infrastructure.Dto
{
    public class LogFormat
    {
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public string EventId { get; set; }
        public string Exception { get; set; }
    }
}
