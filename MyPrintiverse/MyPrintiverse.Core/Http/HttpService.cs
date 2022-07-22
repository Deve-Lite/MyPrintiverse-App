#nullable enable

using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.Http;

public class HttpService : IHttpService
{
	protected IConfigService<IServerConfig> ConfigService { get; }

	private readonly CancellationToken _cancellationToken;
	private readonly RestClient _restClient;

	public HttpService(IConfigService<IServerConfig> configService)
		: this(configService, new RestClientOptions())
	{
	}

	public HttpService(IConfigService<IServerConfig> configService, RestClientOptions options)
		: this(configService, options, new CancellationToken())
	{
	}

	public HttpService(IConfigService<IServerConfig> configService, RestClientOptions options, CancellationToken cancellationToken)
	{
		ConfigService = configService;
		_cancellationToken = cancellationToken;

		var apiBaseUrl = ConfigService.Config.BaseApiUrl ?? throw new ArgumentNullException();
		_restClient = new RestClient(apiBaseUrl);
	}

	public async Task<IHttpResponse<T?>> Get<T>(string url)
	{
		var restRequest = new RestRequest(url);
		var response = await _restClient.GetAsync(restRequest, _cancellationToken);

		var result = GetHttpResponse<T>(response);

		return result;
	}

	public async Task<IHttpResponse<bool>> Delete(string url)
	{
		var restRequest = new RestRequest(url, Method.Delete);
		var response = await _restClient.DeleteAsync(restRequest, _cancellationToken);

		var result = GetHttpResponse<bool>(response);

		return result;
	}

	public async Task<IHttpResponse<bool>> Post<T>(string url, T obj)
	{
		var json = JsonConvert.SerializeObject(obj);

		var restRequest = new RestRequest(url, Method.Post)
			.AddStringBody(json, DataFormat.Json);
			
		var response = await _restClient.PostAsync(restRequest, _cancellationToken);

		var result = GetHttpResponse<bool>(response);

		return result;
	}

	public async Task<IHttpResponse<bool>> Put<T>(string url, T obj)
	{
		var json = JsonConvert.SerializeObject(obj);

		var restRequest = new RestRequest(url, Method.Post)
			.AddStringBody(json, DataFormat.Json);
			
		var response = await _restClient.PutAsync(restRequest, _cancellationToken);

		var result = GetHttpResponse<bool>(response);

		return result;
	}

	private static HttpResponse<T> GetHttpResponse<T>(RestResponseBase response)
	{
		var responseValue = response.Content;
		var value = responseValue != null ? JsonConvert.DeserializeObject<T>(responseValue) : default;

		return new HttpResponse<T>
		{
			Value = value,
			StatusCode = response.StatusCode
		};
	}
}