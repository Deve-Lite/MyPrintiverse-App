namespace MyPrintiverse.Tools;
using CommunityToolkit.Maui.Core;

/// <summary>
/// Service for creating toast message on all devices.
/// </summary>
public class ToastService : IToast
{
    public async Task Toast(string message, ToastDuration duration = ToastDuration.Short, double fontSize = 14)
        => await CommunityToolkit.Maui.Alerts.Toast.Make(message, duration, fontSize).Show();
}
