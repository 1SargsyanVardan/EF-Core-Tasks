using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1
{
        
    public class MyLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger();
        }
        public void Dispose() { }

        private class MyLogger : ILogger, IDisposable
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return this;
            }

            public void Dispose() { }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId,
                    TState state, Exception? exception, Func<TState, Exception?, string> formatter)
            {
                string filePath = "C:\\Users\\User\\OneDrive\\Рабочий стол\\EFCore\\ConsoleApp1\\myLoggerProvider.txt";
                //File.AppendAllText("log.txt", formatter(state, exception));
                using (StreamWriter stream = new StreamWriter(filePath,true))
                {
                    stream.WriteLine($"Date : {DateTime.Now}" );
                    stream.WriteLine(formatter(state, exception));
                }
            }
        }
    }
}
