using System;
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
            var rootCommand = new RootCommand();
            rootCommand.AddOption(new Option<string>(
                "--log-source", 
                description: "Source of the logs",
                getDefaultValue: () => "bps"
                ));
            rootCommand.Description = "Json Parser";
            rootCommand.Handler = CommandHandler.Create<string>(StartProgram);
            rootCommand.InvokeAsync(args).Wait();
        }

        private static void StartProgram(string logSource)
        {
            var source = (LogSource)Enum.Parse(typeof(LogSource), logSource,true);
            var logConfiguration = new LogConfiguration() {LogSource = source};
            new LogParser(new ConsoleHandler(), new LogFormatMapper(), Options.Create(logConfiguration))
                .ReadLogs();
        }
    }
}
