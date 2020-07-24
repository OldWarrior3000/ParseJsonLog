namespace JsonLogParser.Infrastructure.Configuration
{
    public class LogConfiguration
    {
        public LogSource LogSource { get; set; }

        public override string ToString()
        {
            return $"{nameof(LogSource)}:{LogSource}";
        }
    }
}
