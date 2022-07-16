namespace MyPrintiverse.AuthorizationModule.SettingsPage;

public interface ISettingsService : IBaseService
{ 
	/// <summary>
	/// Save user settings.
	/// </summary>
	/// <param name="settings">Settings to save.</param>
	/// <returns><see langword="true"/> if operation is successful, otherwise <see langword="false"/>.</returns>
	public Task<bool> SaveSettings(Settings settings);
}