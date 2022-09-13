using MyPrintiverse.Core.Extensions;
using MyPrintiverse.Core.Http;
using Newtonsoft.Json.Serialization;

namespace MyPrintiverse.Core.Utilities;

/// <inheritdoc />
public class Session : ISession
{
	public IToken? AccessToken { get; private set; }
	public IToken? RefreshToken { get; private set; }

	public bool IsLogged
	{
		get
		{
			if (AccessToken == null || RefreshToken == null)
				return false;

			if (AccessToken?.IsValid == false)
				return false;

			if (RefreshToken?.IsValid == false)
				return false;

			return true;
		}
	}

	public IConfigService<IConfig> Config { get; }

	public delegate void LoggoutHandler();
	public event LoggoutHandler? OnAuthorizationFail;

	public Session(IConfigService<IConfig> config)
	{
		Config = config;
	}

	private record LogInDTO([property:JsonProperty("login")] string Login, [property: JsonProperty("password")] string Password);
	private record TokensDTO([property: JsonProperty("accessToken")] string AccessToken, [property: JsonProperty("refreshToken")] string RefreshToken);

	public async Task<bool> Authorize<TToken>(IHttpService httpService, string url, string login, string password) where TToken : IToken, new()
	{
		var data = new LogInDTO(login, password);
		var result = await httpService.Post<TokensDTO, LogInDTO>(url, data);

		if (!CheckTokens<TToken>(result)) 
			return false;

		OnAuthorizationFail?.Invoke();
		return true;

	}

	public async Task<bool> ReAuthorize<TToken>(IHttpService httpService, string url) where TToken : IToken, new()
	{
		if (string.IsNullOrEmpty(RefreshToken?.Value)) 
			return false;

		var result = await httpService.Post<TokensDTO, IToken>(url, RefreshToken);

		return CheckTokens<TToken>(result);
	}

	private bool CheckTokens<TToken>(IHttpResponse<TokensDTO?> apiResponse) where TToken : IToken, new()
	{
		if (!apiResponse.StatusCode.IsSuccessful())
			return false;

		if (apiResponse?.Value?.AccessToken is null)
			return false;

		if (apiResponse?.Value?.RefreshToken is null)
			return false;

		var accessToken = new TToken();
		accessToken.Set(apiResponse.Value.AccessToken);

		var refreshToken = new TToken();
		refreshToken.Set(apiResponse.Value.RefreshToken);

		AccessToken = accessToken;
		RefreshToken = refreshToken;

		return true;
	}
}