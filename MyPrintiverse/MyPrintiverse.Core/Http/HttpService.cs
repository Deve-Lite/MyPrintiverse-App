#nullable enable

using MyPrintiverse.Core.Extensions;
using MyPrintiverse.Core.Utilities;
using RestSharp.Authenticators;

namespace MyPrintiverse.Core.Http;

public class HttpService : IHttpService
{
	/// <summary>
	/// Maximal length of operation
	/// </summary>
	private readonly int TIMEOUT = 10000;

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
	}

	#region Get Request

	public async Task<IHttpResponse<T?>> Get<T>(string url, IToken? authenticationToken)
	{
        var restClient = new RestClient(url);
        var restRequest = new RestRequest();
		restRequest.Timeout = TIMEOUT;
		
		await AuthenticateRequest(restRequest, authenticationToken);
		var response = await restClient.GetAsync(restRequest, _cancellationToken);
        var result = GetHttpResponse<T>(response);
		
		return result;
	}


	public async Task<IHttpResponse<T?>> Get<T>(string url) => await Get<T>(url, null);

	#endregion

	#region Delete Request

	public async Task<IHttpResponse<TResponse?>> Delete<TResponse>(string url, IToken? authenticationToken)
	{
		var restRequest = new RestRequest(url, Method.Delete);
		var response = await _restClient.DeleteAsync(restRequest, _cancellationToken);
        restRequest.Timeout = TIMEOUT;

        await AuthenticateRequest(restRequest, authenticationToken);

		var result = GetHttpResponse<TResponse?>(response);

		return result;
	}

	public async Task<IHttpResponse<TResponse?>> Delete<TResponse>(string url) => await Delete<TResponse?>(url, null);

	#endregion

	#region Post Request

	public async Task<IHttpResponse<TResponse?>> Post<TResponse, TSender>(string url, TSender obj, IToken? authenticationToken)
	{
		var json = JsonConvert.SerializeObject(obj);

		var restRequest = new RestRequest(url, Method.Post)
			.AddJsonBody(json);
        restRequest.Timeout = TIMEOUT;

        await AuthenticateRequest(restRequest, authenticationToken);

		var response = await _restClient.PostAsync(restRequest, _cancellationToken);

		var result = GetHttpResponse<TResponse?>(response);

		return result;
	}

	public async Task<IHttpResponse<TResponse?>> Post<TResponse, TSender>(string url, TSender obj) => await Post<TResponse?, TSender>(url, obj, null);

	#endregion

	#region Put Request

	public async Task<IHttpResponse<TResponse?>> Put<TResponse, TSender>(string url, TSender obj, IToken? authenticationToken)
	{
		var json = JsonConvert.SerializeObject(obj);

		var restRequest = new RestRequest(url, Method.Post)
			.AddStringBody(json, DataFormat.Json);
        restRequest.Timeout = TIMEOUT;

        await AuthenticateRequest(restRequest, authenticationToken);

		var response = await _restClient.PutAsync(restRequest, _cancellationToken);

		var result = GetHttpResponse<TResponse?>(response);

		return result;
	}

	public async Task<IHttpResponse<TResponse?>> Put<TResponse, TSender>(string url, TSender obj) => await Put<TResponse?, TSender>(url, obj, null);

	#endregion

	private async Task AuthenticateRequest(RestRequest request, IToken? authenticationToken)
	{
		if (authenticationToken?.Value == null)
			return;

		var authentication = new JwtAuthenticator(authenticationToken.Value);

		await authentication.Authenticate(_restClient, request);
	}
	private static HttpResponse<T> GetHttpResponse<T>(RestResponseBase response)
	{
		var responseValue = response.Content;

		var value = JsonConvert.DeserializeObject<RequestParsator<T>>(responseValue).Value;

		/*TODO Parsator
		var value = typeof(T) == typeof(bool)
			? (T)(object)response.StatusCode.IsSuccessful()
			: responseValue != null 
				? JsonConvert.DeserializeObject<T>(responseValue) 
				: default;*/

		return new HttpResponse<T>
		{
			Value = value,
			StatusCode = response.StatusCode,
            IsSuccessful = response.IsSuccessful
        };
	}
}