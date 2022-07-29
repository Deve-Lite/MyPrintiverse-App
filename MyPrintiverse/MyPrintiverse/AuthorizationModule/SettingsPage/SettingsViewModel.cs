namespace MyPrintiverse.AuthorizationModule.SettingsPage;

public class SettingsViewModel : BaseViewModel
{
	public AppTheme AppTheme { get; set; }

	public ICommand SaveSettingsCommand { get; }

	private readonly ISettingsService _settingsService;

	public SettingsViewModel(ISettingsService settingsService)
	{
		_settingsService = settingsService;

		SaveSettingsCommand = new AsyncCommand(SaveSettings, CanExecute, shellExecute: ExecuteBlockade);
	}

	private async Task SaveSettings()
	{
		var settings = new Settings()
		{
			AppTheme = AppTheme,
		};

		var isSuccess = await _settingsService.SaveSettings(settings);

		if (!isSuccess)
			await _settingsService.MessageService.ShowErrorAsync();
	}
}