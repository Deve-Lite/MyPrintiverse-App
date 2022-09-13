#nullable enable
using MyPrintiverse.Core.Extensions;
using System.Net;

namespace MyPrintiverse.Core.Http;

public interface IHttpResponse<T>
{
	public T? Value { get; set; }
	public HttpStatusCode StatusCode { get; set; }
	public bool IsSuccessful { get; }
}