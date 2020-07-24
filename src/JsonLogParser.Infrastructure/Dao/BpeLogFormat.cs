using System;
using System.Text.Json.Serialization;

namespace JsonLogParser.Infrastructure.Dao
{
    public class BpeLogFormat
    {
        [JsonPropertyName("timestamp")]
        public DateTime TimeStamp { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }        
        [JsonPropertyName("level")]
        public string Level { get; set; }
        [JsonPropertyName("correlationId")]
        public string EventId { get; set; }
        [JsonPropertyName("exception")]
        public string Exception { get; set; }
    }
}
