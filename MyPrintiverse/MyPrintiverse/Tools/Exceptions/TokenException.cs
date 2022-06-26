using System.Runtime.Serialization;

namespace MyPrintiverse.Tools.Exceptions;

[Serializable]
internal class TokenException : Exception
{
	public TokenException()
	{
	}

	public TokenException(string message) : base(message)
	{
	}

	public TokenException(string message, Exception innerException) : base(message, innerException)
	{
	}

	protected TokenException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
}