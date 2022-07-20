namespace MyPrintiverse.Core.Utilities;

/// <summary>
/// Session manager.
/// </summary>
public interface ISession
{
	public IToken? AccessToken { get; }
	public IToken? RefreshToken { get; }
	
	public bool IsLogged { get; }
	public bool HasConnection { get; set; }

	/// <summary>
	/// Try to authorize user by setting <see cref="AccessToken" /> and <see cref="RefreshToken" />.
	/// </summary>
	/// <param name="login">User login.</param>
	/// <param name="password">User password.</param>
	/// <returns><see langword="true" /> if operation went successful, otherwise <see langword="false" />.</returns>
	public bool Authorize(string login, string password);
	
	/// <summary>
	/// Try to reauthorize user using <see cref="RefreshToken" />
	/// </summary>
	/// <returns><see langword="true" /> if operation went successful, otherwise <see langword="false" />.</returns>
	public bool ReAuthorize();
}
