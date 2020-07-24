using JsonLogParser.Infrastructure.Dao;
using JsonLogParser.Infrastructure.Dto;

namespace JsonLogParser.Infrastructure
{
    public interface ILogFormatMapper
    {
        LogFormat ConvertFromBpsLogFormat(BpsLogFormat bpsLogFormat);
        LogFormat ConvertFromBpeLogFormat(BpeLogFormat bpeLogFormat);
    }
}
