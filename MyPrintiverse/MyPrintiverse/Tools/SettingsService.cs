namespace MyPrintiverse.Tools;

public class SettingsService : ISettingsService
{
	private AppTheme _appTheme;
	public AppTheme AppTheme
	{
		get => _appTheme;
		set
		{
			_appTheme = value;

			if (App != null) 
				App.UserAppTheme = _appTheme;
		}
	}

	private static Application? App => Application.Current;

	//TODO: Use DI to inject SQLite connection and read saved settings
	public SettingsService()
	{
		AppTheme = new AppTheme();
	}
}

public interface ISettingsService
{
	public AppTheme AppTheme { get; set; }
}