namespace MyPrintiverse.Tools.Settings;

public class Theme
{
    /// <summary>
    /// Sets App theme.
    /// </summary>
    /// <param name="theme">Theme to set.</param>
    public void SetTheme(AppTheme theme)
    {
	    if (Application.Current == null) 
		    return;

	    Application.Current.UserAppTheme = theme switch
	    {
		    AppTheme.Dark => AppTheme.Dark,
		    AppTheme.Unspecified => AppTheme.Light,
		    AppTheme.Light => AppTheme.Light,
		    _ => AppTheme.Light
	    };
    }
}
