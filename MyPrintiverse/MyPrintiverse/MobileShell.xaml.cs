using MongoDB.Bson;
using MyPrintiverse.Tools;

namespace MyPrintiverse;

public partial class MobileShell : Shell
{
    public MobileShell(IToast toast, ISession session)
    {
        InitializeComponent();
        _toast = toast;

        Items.Add(AddAuthorizationMenuitem(session.IsLogged));
    }

    #region Privates

    private MenuItem AddAuthorizationMenuitem(bool isLogged)
    {
        return new MenuItem
        {
            Text = isLogged ? "Logout" : "Login",
            Command = isLogged ? LogoutCommand : LoginCommand,
            CommandParameter = null
        };
    }

    [RelayCommand]
    private async Task Logout()
    {
        await _toast.Toast("Logout TODO");
        //TODO : Logout user and switch view to login page
    }

    [RelayCommand]
    private async Task Login()
    {
        await _toast.Toast("Login TODO");
        //TODO : Switch view to login page
    }

    #endregion

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
