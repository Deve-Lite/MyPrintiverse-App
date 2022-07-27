using System.Runtime.Serialization;

namespace MyPrintiverse.Core.Exceptions
{
    [Serializable]
    internal class InvalidTypeParameterException : Exception
    {
        public InvalidTypeParameterException()
        {
        }

        public InvalidTypeParameterException(string? message) : base(message)
        {
        }

        public InvalidTypeParameterException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidTypeParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}