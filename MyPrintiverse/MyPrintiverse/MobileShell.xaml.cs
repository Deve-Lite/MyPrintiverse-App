using MyPrintiverse.Tools;

namespace MyPrintiverse;

public partial class MobileShell : Shell
{
    public MobileShell(IToast toast)
    {
        InitializeComponent();
        _toast = toast;
    }

    #region Others

    long lastPressTime = 0;
    protected readonly IToast _toast;

    #endregion

    #region Overrides

    protected override bool OnBackButtonPressed()
    {
        if (Shell.Current.Navigation.NavigationStack.Count > 1)
            return base.OnBackButtonPressed();

        long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

        if (currentTime - lastPressTime < 1000)
            return base.OnBackButtonPressed();

        _toast.Toast("Press one more time to leave app.");
        lastPressTime = currentTime;
        return true;

    }

    #endregion
}
