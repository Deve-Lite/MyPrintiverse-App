
using Microsoft.Extensions.Logging;

namespace MyPrintiverse.Tools;

public class Logger : ILogger
{
	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
	{
	}

	public bool IsEnabled(LogLevel logLevel) => true;

	public IDisposable BeginScope<TState>(TState state) => null;
}