#nullable enable
using System.Net;

namespace MyPrintiverse.Tools.Http;

public interface IHttpResponse<T>
{
	public T? Value { get; set; }
	public HttpStatusCode StatusCode { get; set; }
}