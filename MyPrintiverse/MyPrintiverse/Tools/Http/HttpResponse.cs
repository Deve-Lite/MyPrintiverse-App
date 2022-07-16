#nullable enable
using System.Net;

namespace MyPrintiverse.Tools.Http;

public class HttpResponse<T> : IHttpResponse<T?>
{
	public T? Value { get; set; }
	public HttpStatusCode StatusCode { get; set; }
}