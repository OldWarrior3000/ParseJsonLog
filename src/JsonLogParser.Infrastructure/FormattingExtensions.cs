using System.Text;

namespace JsonLogParser.Infrastructure
{
    public static class FormattingExtensions
    {
        private static readonly string Separator = " ";

        public static string GetFormattedLog(this Log log) {
            var sb = new StringBuilder();

            AddProperty(log.TimeStamp, nameof(Log.TimeStamp), ref sb);
            AddSeparator(ref sb);
            AddProperty(log.Level, nameof(Log.Level), ref sb);
            AddProperty(log.Message, nameof(Log.Message), ref sb);
            AddProperty(log.EventId, nameof(Log.EventId), ref sb, true);
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
