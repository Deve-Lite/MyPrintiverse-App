namespace MyPrintiverse.Admin;

public interface IAdminService : IBaseService
{
	/// <summary>
	/// Get all loaded resources by application.
	/// </summary>
	/// <returns>loaded resources.</returns>
	public Task<List<string>> GetAssets();

	/// <summary>
	/// Test connection between application and api.
	/// </summary>
	/// <returns></returns>
	public Task<bool> PingApi();

	/// <summary>
	/// Open test page called "Andromeda".
	/// </summary>
	public Task OpenAndromeda();

	/// <summary>
	/// Open test page called "Odyssey".
	/// </summary>
	public Task OpenOdyssey();

	/// <summary>
	/// Open test page called "Orion".
	/// </summary>
	public Task OpenOrion();

	/// <summary>
	/// Registers new user.
	/// </summary>
	/// <returns></returns>
	public Task<bool> Register(string email, string password, string username);
    /// <summary>
    /// Registers new user.
    /// </summary>
    /// <returns></returns>
    public Task<bool> ConfirmMail(string email, string code);
    /// <summary>
    /// Registers new user.
    /// </summary>
    /// <returns></returns>
    public Task<bool> LogIn(string email, string password);
}