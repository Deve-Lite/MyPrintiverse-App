﻿#nullable enable

using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Tools.Http;

public class HttpService : IHttpService
{
	private readonly IConfigService<IHttpConfig> _configService;
	private readonly CancellationToken _cancellationToken;
	private readonly RestClient _restClient;

	public HttpService(IConfigService<IHttpConfig> configService)
		: this(configService, new RestClientOptions())
	{
	}

	public HttpService(IConfigService<IHttpConfig> configService, RestClientOptions options)
		: this(configService, options, new CancellationToken())
	{
	}

	public HttpService(IConfigService<IHttpConfig> configService, RestClientOptions options, CancellationToken cancellationToken)
	{
		_configService = configService;
		_cancellationToken = cancellationToken;

		var apiBaseUrl = _configService.Config.BaseApiUrl ?? throw new ArgumentNullException();
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
		var value = JsonConvert.DeserializeObject<T>(responseValue);

		return new HttpResponse<T>
		{
			Value = value,
			StatusCode = response.StatusCode
		};
	}
}