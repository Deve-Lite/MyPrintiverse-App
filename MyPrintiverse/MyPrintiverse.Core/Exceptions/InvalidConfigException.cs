
namespace MyPrintiverse.Core.Exceptions;

public class InvalidConfigException : Exception
{
	public InvalidConfigException()
	{

	}

	public InvalidConfigException(string? message) : base(message)
	{

	}

	public InvalidConfigException(string? message, Exception? innerException) : base(message, innerException)
	{

	}
}