using System;
using System.Text.Json.Serialization;

namespace JsonLogParser.Infrastructure.Dao
{
    public class BpsLogFormat {
        [JsonPropertyName("@t")]
        public DateTime TimeStamp { get; set; }
        [JsonPropertyName("@m")]
        public string Message { get; set; }        
        [JsonPropertyName("@l")]
        public string Level { get; set; }
        [JsonPropertyName("@i")]
        public string EventId { get; set; }
        [JsonPropertyName("@x")]
        public string Exception { get; set; }
    }
}
