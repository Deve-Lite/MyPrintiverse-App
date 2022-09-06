using MyPrintiverse.Core.Http;

namespace MyPrintiverse.Core.Utilities;

/// <summary>
/// Session manager.
/// </summary>
public interface ISession
{
	public IToken? AccessToken { get; }
	public IToken? RefreshToken { get; }
	
	public bool IsLogged { get; }
	public IConfigService<IConfig> Config { get; }

	/// <summary>
	/// Try to authorize user by setting <see cref="AccessToken" /> and <see cref="RefreshToken" />.
	/// </summary>
	/// <param name="httpService">Https service for handling requests.</param>
	/// <param name="login">User login.</param>
	/// <param name="password">User password.</param>
	/// <param name="url">Api url.</param>
	/// <returns><see langword="true" /> if operation went successful, otherwise <see langword="false" />.</returns>
	public Task<bool> Authorize<TToken>(IHttpService httpService, string url, string login, string password) where TToken : IToken, new();

	/// <summary>
	/// Try to reauthorize user using <see cref="RefreshToken" />
	/// </summary>
	/// <param name="httpService">Https service for handling requests.</param>
	/// <param name="url">Api url.</param>
	/// <returns><see langword="true" /> if operation went successful, otherwise <see langword="false" />.</returns>
	public Task<bool> ReAuthorize<TToken>(IHttpService httpService, string url) where TToken : IToken, new();
}
