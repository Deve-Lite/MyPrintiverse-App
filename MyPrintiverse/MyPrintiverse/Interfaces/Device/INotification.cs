using System;
namespace MyPrintiverse.Interfaces.Device
{
    /// <summary>
    /// Interface to implement on mobile if not in MCT.
    /// </summary>
    public interface INotification
    {
        event EventHandler NotificationReceived;
        INotification Initialize();
        INotification SendNotification(string title, string message, DateTime? notifyTime = null);
        INotification ReceiveNotification(string title, string message);
    }
}
