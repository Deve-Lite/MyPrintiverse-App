

namespace MyPrintiverse.Tools.Settings;

public class Theme
{
    /// <summary>
    /// Sets App theme.
    /// </summary>
    /// <param name="theme">Theme to set.</param>
    public void SetTheme(AppTheme theme)
    {

        switch (theme)
        {
            default:
            case AppTheme.Light:
                App.Current.UserAppTheme = AppTheme.Light;
                break;
            case AppTheme.Dark:
                App.Current.UserAppTheme = AppTheme.Dark;
                break;
        }
    }

}
