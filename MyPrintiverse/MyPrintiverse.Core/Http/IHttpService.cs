#nullable enable

namespace MyPrintiverse.Core.Http;

public interface IHttpService
{
	public Task<IHttpResponse<T?>> Get<T>(string url);
	public Task<IHttpResponse<bool>> Delete(string url);
	public Task<IHttpResponse<bool>> Post<T>(string url, T obj);
	public Task<IHttpResponse<bool>> Put<T>(string url, T obj);
}