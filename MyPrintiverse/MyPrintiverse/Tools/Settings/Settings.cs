namespace MyPrintiverse.Tools.Settings;

/// <inheritdoc />
public class Settings : ISettings
{
    public AppTheme AppTheme
    {
        get => _settingsService.Get<AppTheme>(nameof(AppTheme));
        set
        {
            if (App != null)
                App.UserAppTheme = value;

            _settingsService.Save(nameof(AppTheme), value);
        }
    }

    private static Application? App => Application.Current;
    private readonly ISettingsStorage _settingsService;

    public Settings(ISettingsStorage settingsStorage)
    {
        _settingsService = settingsStorage;
        AppTheme = new AppTheme();
    }
}