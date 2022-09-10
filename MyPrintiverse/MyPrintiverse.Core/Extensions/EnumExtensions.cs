using System.Net;

namespace MyPrintiverse.Core.Extensions
{
    public static class EnumExtensions
    {
        public static bool IsSuccessful(this HttpStatusCode @this)
        {
            var statusCode = (int)@this;

            return statusCode is >= 200 and < 300;
        }
    }
}
