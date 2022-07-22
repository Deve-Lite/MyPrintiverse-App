namespace MyPrintiverse.Authorization.Login;

public interface ILoginService : IBaseService
{
	/// <summary>
	/// Login/Authorize user.
	/// </summary>
	/// <param name="username">User name.</param>
	/// <param name="password">User password.</param>
	/// <returns><see langword="true"/> if operation is successful, otherwise <see langword="false"/>.</returns>
	public Task<bool> LogInAsync(string username, string password);
}