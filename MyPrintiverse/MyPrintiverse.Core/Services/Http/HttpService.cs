#nullable enable

using MyPrintiverse.Core.Services.Helpers;
using MyPrintiverse.Core.Utilities;
using RestSharp;
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

		_restClient = new RestClient(options);
    }

    #region Get Request

    public async Task<IHttpResponse<T?>> Get<T>(string url, IToken? authenticationToken)
	{
        var restRequest = new RestRequest(url);
        restRequest.Timeout = TIMEOUT;

        await AuthenticateRequest(restRequest, authenticationToken);
		var response = await _restClient.GetAsync(restRequest, _cancellationToken);
        var result = GetHttpResponse<T>(response);
		
		return result;
	}

    public async Task<IHttpResponse<T?>> Get<T>(string url) => await Get<T>(url, null);

    #endregion

    #region Delete Request

    public async Task<IHttpResponse<TResponse?>> Delete<TResponse>(string url, IToken? authenticationToken)
	{
		var restRequest = new RestRequest(url, Method.Delete);
        restRequest.Timeout = TIMEOUT;

        await AuthenticateRequest(restRequest, authenticationToken);
        var response = await _restClient.DeleteAsync(restRequest, _cancellationToken);
        var result = GetHttpResponse<TResponse?>(response);

		return result;
	}

	public async Task<IHttpResponse<TResponse?>> Delete<TResponse>(string url) => await Delete<TResponse?>(url, null);

    #endregion

    #region Patch Request

    public async Task<IHttpResponse<TResponse?>> Patch<TResponse, TSender>(string url, TSender obj, IToken? authenticationToken)
    {
        var json = JsonConvert.SerializeObject(obj);

        var restRequest = new RestRequest(url, Method.Patch)
            .AddStringBody(json, DataFormat.Json);
        restRequest.Timeout = TIMEOUT;

        await AuthenticateRequest(restRequest, authenticationToken);

        var response = await _restClient.PatchAsync(restRequest, _cancellationToken);

        var result = GetHttpResponse<TResponse?>(response);

        return result;
    }

    public async Task<IHttpResponse<TResponse?>> Patch<TResponse, TSender>(string url, TSender obj) => await Patch<TResponse?, TSender>(url, obj, authenticationToken: null);

    public async Task<IHttpResponse<TResponse?>> Patch<TResponse, TSender>(string url, TSender obj, IToken? authenticationToken, JsonSerializerSettings jsonSerializerSettings)
    {
        var json = JsonConvert.SerializeObject(obj, jsonSerializerSettings);

        var restRequest = new RestRequest(url, Method.Patch)
            .AddStringBody(json, DataFormat.Json);
        restRequest.Timeout = TIMEOUT;

        await AuthenticateRequest(restRequest, authenticationToken);

        var response = await _restClient.PatchAsync(restRequest, _cancellationToken);

        var result = GetHttpResponse<TResponse?>(response);

        return result;
    }

    public async Task<IHttpResponse<TResponse?>> Patch<TResponse, TSender>(string url, TSender obj, JsonSerializerSettings jsonSerializerSettings) => await Patch<TResponse?, TSender>(url, obj, null, jsonSerializerSettings);
    #endregion


    #region Post Request


    // TODO : metoda Post która przyjmuje parametr JsonSerializerSettings a z tej metody usunięcie JsonSerializerSettings
    public async Task<IHttpResponse<TResponse?>> Post<TResponse, TSender>(string url, TSender obj, IToken? authenticationToken, JsonSerializerSettings jsonSerializerSettings)
    {
        var json = JsonConvert.SerializeObject(obj, jsonSerializerSettings);

        var restRequest = new RestRequest(url, Method.Post)
            .AddJsonBody(json);
        restRequest.Timeout = TIMEOUT;

        await AuthenticateRequest(restRequest, authenticationToken);

        var response = await _restClient.PostAsync(restRequest, _cancellationToken);

        var result = GetHttpResponse<TResponse?>(response);

        return result;
    }

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

	public async Task<IHttpResponse<TResponse?>> Post<TResponse, TSender>(string url, TSender obj) => await Post<TResponse?, TSender>(url, obj, authenticationToken: null);

    public async Task<IHttpResponse<TResponse?>> Post<TResponse, TSender>(string url, TSender obj, JsonSerializerSettings jsonSerializerSettings) => await Post<TResponse?, TSender>(url, obj, null, jsonSerializerSettings);
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

	public async Task<IHttpResponse<TResponse?>> Put<TResponse, TSender>(string url, TSender obj) => await Put<TResponse?, TSender>(url, obj, authenticationToken:null);

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
		//TODO: Do zmiany działanie -> wyrzuciło bład czy potwierdzeniu maila NullRefrence
		var responseValue = response.Content;
		T value;

		if (!string.IsNullOrEmpty(responseValue))
		{
			value = typeof(T) == typeof(bool)
			? (T)(object)response.StatusCode.IsSuccessful()
			: responseValue != null
				? JsonConvert.DeserializeObject<RequestData<T>>(responseValue).Value
				: default;
		}
		else
			value = default;

		return new HttpResponse<T>
		{
			Value = value,
			StatusCode = response.StatusCode
        };
	}
}