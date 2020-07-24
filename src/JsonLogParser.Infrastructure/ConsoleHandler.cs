using System;

namespace JsonLogParser.Infrastructure
{
    public class ConsoleHandler : IConsoleHandler        
    {
        public string ReadConsole() => Console.ReadLine();        
        public void WriteConsole(string input) => Console.WriteLine(input); 
    }
}
