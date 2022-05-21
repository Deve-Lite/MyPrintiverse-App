
namespace MyPrintiverse.Core.Exceptions;

public class NotInitializeException : Exception
{
	public NotInitializeException()
	{

	}

	public NotInitializeException(string? message) : base(message)
	{

	}

	public NotInitializeException(string? message, Exception? innerException) : base(message, innerException)
	{

	}
}