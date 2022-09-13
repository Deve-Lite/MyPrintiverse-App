using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.Http;

/// <summary>
/// Service for handling communication with api.
/// </summary>
public interface IHttpService
{
	/// <summary>
	/// Get resource using api.
	/// </summary>
	/// <typeparam name="T">Resource type.</typeparam>
	/// <param name="url">Resource api link.</param>
	/// <returns>response with status code and value.</returns>
	public Task<IHttpResponse<T?>> Get<T>(string url);

	/// <summary>
	/// Get resource from api.
	/// </summary>
	/// <typeparam name="T">Resource type.</typeparam>
	/// <param name="url">Resource api link.</param>
	/// <param name="authenticationToken">Authentication token.</param>
	/// <returns>response with status code and value.</returns>
	public Task<IHttpResponse<T?>> Get<T>(string url, IToken? authenticationToken);

	/// <summary>
	/// Delete resource using api.
	/// </summary>
	/// <param name="url">Resource api link.</param>
	/// <returns>response with status code.</returns>
	public Task<IHttpResponse<TResponse?>> Delete<TResponse>(string url);

	/// <summary>
	/// Delete resource using api.
	/// </summary>
	/// <param name="url">Resource api link.</param>
	/// <param name="authenticationToken">Authentication token.</param>
	/// <returns>response with status code.</returns>
	public Task<IHttpResponse<TResponse?>> Delete<TResponse>(string url, IToken? authenticationToken);

	/// <summary>
	/// Post resource using api.
	/// </summary>
	/// <typeparam name="TSender">Object to send type.</typeparam>
	/// <typeparam name="TResponse">Response object type.</typeparam>
	/// <param name="url">Resource api link.</param>
	/// <param name="obj"></param>
	/// <returns></returns>
	public Task<IHttpResponse<TResponse?>> Post<TResponse, TSender>(string url, TSender obj);

	/// <summary>
	/// Post resource using api.
	/// </summary>
	/// <typeparam name="TSender">Object to send type.</typeparam>
	/// <typeparam name="TResponse">Response object type.</typeparam>
	/// <param name="url">Resource api link.</param>
	/// <param name="obj">Value to be send.</param>
	/// <param name="authenticationToken"></param>
	/// <returns></returns>
	public Task<IHttpResponse<TResponse?>> Post<TResponse, TSender>(string url, TSender obj, IToken? authenticationToken);

    /// <summary>
    /// Post resource using api.
    /// </summary>
    /// <typeparam name="TSender">Object to send type.</typeparam>
    /// <typeparam name="TResponse">Response object type.</typeparam>
    /// <param name="url">Resource api link.</param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public Task<IHttpResponse<TResponse?>> Post<TResponse, TSender>(string url, TSender obj, JsonSerializerSettings jsonSerializerSettings);

    /// <summary>
    /// Post resource using api.
    /// </summary>
    /// <typeparam name="TSender">Object to send type.</typeparam>
    /// <typeparam name="TResponse">Response object type.</typeparam>
    /// <param name="url">Resource api link.</param>
    /// <param name="obj">Value to be send.</param>
    /// <param name="authenticationToken"></param>
    /// <returns></returns>
    public Task<IHttpResponse<TResponse?>> Post<TResponse, TSender>(string url, TSender obj, IToken? authenticationToken, JsonSerializerSettings jsonSerializerSettings);


    /// <summary>
    /// Put resource using api.
    /// </summary>
    /// <typeparam name="TSender">Object to send type.</typeparam>
    /// <typeparam name="TResponse">Response object type.</typeparam>
    /// <param name="url"></param>
    /// <param name="obj">Value to be send.</param>
    /// <returns></returns>
    public Task<IHttpResponse<TResponse?>> Put<TResponse, TSender>(string url, TSender obj);

	/// <summary>
	/// Put resource using api.
	/// </summary>
	/// <typeparam name="TSender">Object to send type.</typeparam>
	/// <typeparam name="TResponse">Response object type.</typeparam>
	/// <param name="url">Resource api link.</param>
	/// <param name="obj">Value to be send.</param>
	/// <param name="authenticationToken">Authentication token.</param>
	/// <returns></returns>
	public Task<IHttpResponse<TResponse?>> Put<TResponse, TSender>(string url, TSender obj, IToken? authenticationToken);

    /// <summary>
    /// Patch resource using api.
    /// </summary>
    /// <typeparam name="TSender">Object to send type.</typeparam>
    /// <typeparam name="TResponse">Response object type.</typeparam>
    /// <param name="url"></param>
    /// <param name="obj">Value to be send.</param>
    /// <returns></returns>
    public Task<IHttpResponse<TResponse?>> Patch<TResponse, TSender>(string url, TSender obj);

    /// <summary>
    /// Patch resource using api.
    /// </summary>
    /// <typeparam name="TSender">Object to send type.</typeparam>
    /// <typeparam name="TResponse">Response object type.</typeparam>
    /// <param name="url">Resource api link.</param>
    /// <param name="obj">Value to be send.</param>
    /// <param name="authenticationToken">Authentication token.</param>
    /// <returns></returns>
    public Task<IHttpResponse<TResponse?>> Patch<TResponse, TSender>(string url, TSender obj, IToken? authenticationToken);

    /// <summary>
    /// Patch resource using api.
    /// </summary>
    /// <typeparam name="TSender">Object to send type.</typeparam>
    /// <typeparam name="TResponse">Response object type.</typeparam>
    /// <param name="url"></param>
    /// <param name="obj">Value to be send.</param>
    /// <returns></returns>
    public Task<IHttpResponse<TResponse?>> Patch<TResponse, TSender>(string url, TSender obj, JsonSerializerSettings jsonSerializerSettings);

    /// <summary>
    /// Patch resource using api.
    /// </summary>
    /// <typeparam name="TSender">Object to send type.</typeparam>
    /// <typeparam name="TResponse">Response object type.</typeparam>
    /// <param name="url">Resource api link.</param>
    /// <param name="obj">Value to be send.</param>
    /// <param name="authenticationToken">Authentication token.</param>
    /// <returns></returns>
    public Task<IHttpResponse<TResponse?>> Patch<TResponse, TSender>(string url, TSender obj, IToken? authenticationToken, JsonSerializerSettings jsonSerializerSettings);
}