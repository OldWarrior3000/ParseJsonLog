using System.CommandLine;
using System.CommandLine.Invocation;
using JsonLogParser.Infrastructure;
using JsonLogParser.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace JsonLogParser
{
#pragma warning disable S1118 // Utility classes should not have public constructors
    internal class Program
#pragma warning restore S1118 // Utility classes should not have public constructors
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            var rootCommand = new RootCommand()
            {
                new Option<LogSource>(
                    "--source", 
                    description: "Source of the logs", 
                    getDefaultValue: () => LogSource.Bps)
            };

            rootCommand.Description = "Json Parser";
            rootCommand.Handler = CommandHandler.Create<LogSource>(StartProgram);
            rootCommand.InvokeAsync(args).Wait();
        }

        private static void StartProgram(LogSource logSource)
        {
            var logConfiguration = new LogConfiguration() {LogSource = logSource};
            new LogParser(new ConsoleHandler(), new LogFormatMapper(), Options.Create(logConfiguration))
                .ReadLogs();
        }
    }
}
