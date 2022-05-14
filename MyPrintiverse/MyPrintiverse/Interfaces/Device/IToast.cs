using System;
namespace MyPrintiverse.Interfaces.Device
{
    /// <summary>
    /// Interface to implement on mobile if not in MCT.
    /// </summary>
    public interface IToast
    {
        /// <summary>
        /// Device implemented Toast (2,5s).
        /// </summary>
        /// <param name="message"></param>
        public void ShortToast(string message);
        /// <summary>
        /// Device implemented toast (3,5s).
        /// </summary>
        /// <param name="message"></param>
        public void LongToast(string message);
    }
}
