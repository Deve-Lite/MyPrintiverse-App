using System;
namespace MyPrintiverse.Interfaces.Device
{
    /// <summary>
    /// Interface to implement on mobile if not in MCT.
    /// </summary>
    public interface INotification
    {
        event EventHandler NotificationReceived;
        void Initialize();
        void SendNotification(string title, string message, DateTime? notifyTime = null);
        void ReceiveNotification(string title, string message);
    }
}
