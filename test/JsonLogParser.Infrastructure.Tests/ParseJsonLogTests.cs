using System.Text;
using FluentAssertions;
using JsonLogParser.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Xunit;
using Moq;
using Xunit.Abstractions;

namespace JsonLogParser.Infrastructure.Tests
{
    public class JsonParserTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public JsonParserTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ReadLogs_JsonInput_FormattedString()
        {
            const string logOutput = "{\"@t\":\"2020-07-10T16:45:14.4577649Z\",\"@m\":\"Request starting HTTP/1.1 GET http://192.168.5.55:80/health  \",\"@i\":\"ca22a1cb\",\"Protocol\":\"HTTP/1.1\",\"Method\":\"GET\",\"ContentType\":null,\"ContentLength\":null,\"Scheme\":\"http\",\"Host\":\"192.168.5.55:80\",\"PathBase\":\"\",\"Path\":\"/health\",\"QueryString\":\"\",\"HostingRequestStartingLog\":\"Request starting HTTP/1.1 GET http://192.168.5.55:80/health  \",\"EventId\":{\"Id\":1},\"SourceContext\":\"Microsoft.AspNetCore.Hosting.Diagnostics\",\"RequestId\":\"0HM13SKICOPD0:00000001\",\"RequestPath\":\"/health\",\"SpanId\":\"|7ec00257-47e3d483a345220f.\",\"TraceId\":\"7ec00257-47e3d483a345220f\",\"ParentId\":\"\",\"ConnectionId\":\"0HM13SKICOPD0\",\"MachineName\":\"fenergo-business-process-service-848d6f5c57-2nclq\",\"ProcessId\":1,\"ThreadId\":26,\"FenergoApp\":\"Fenergo Business Process Service API\",\"CorrelationId\":\"86f12346-7c75-4a00-b3d2-2005f995a6b5\"}";
            
            var sb = new StringBuilder();
            var consoleMock = new Mock<IConsoleHandler>();
            consoleMock.SetupSequence(x => x.ReadConsole()).Returns(logOutput);
            consoleMock.Setup(x => x.WriteConsole(It.IsAny<string>()))
                .Callback((string x) => sb.Append(x));
            var logConfiguration = new LogConfiguration() {LogSource = LogSource.Bps};
            var logParser = new LogParser(consoleMock.Object, new LogFormatMapper(), Options.Create(logConfiguration));

            logParser.ReadLogs();

            _testOutputHelper.WriteLine(sb.ToString());
            sb.ToString().Should().NotBeNull();
        }
    }
}
