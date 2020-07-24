using System.Text;
using JsonLogParser.Infrastructure.Dto;

namespace JsonLogParser.Infrastructure
{
    public static class FormattingExtensions
    {
        private static readonly string Separator = " ";

        public static string GetFormattedLog(this LogFormat bpsLogFormat) {
            var sb = new StringBuilder();

            AddProperty(bpsLogFormat.TimeStamp, nameof(LogFormat.TimeStamp), ref sb);
            AddSeparator(ref sb);
            AddProperty(bpsLogFormat.Level, nameof(LogFormat.Level), ref sb);
            AddSeparator(ref sb);
            AddProperty(bpsLogFormat.Message, nameof(LogFormat.Message), ref sb);
            AddSeparator(ref sb);
            AddProperty(bpsLogFormat.EventId, nameof(LogFormat.EventId), ref sb, true);
            return sb.ToString();
        }

        private static void AddProperty<T>(T input, string typeName, ref StringBuilder sb, bool appendName = false)
        {
            if (input == null)
            {
                return;
            }

            if (appendName)
            {
                sb.Append($"{typeName}:{input}");
            }
            else
            {
                sb.Append(input);
            }
        }

        private static void AddSeparator(ref StringBuilder sb) => sb.Append(Separator);
    }
}
