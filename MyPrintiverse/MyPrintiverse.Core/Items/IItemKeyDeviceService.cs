namespace MyPrintiverse.Core.Items
{
    /// <summary>
    /// Interface with base methods for items groupped with 'key'. Designed for device service.
    /// </summary>
    public interface IItemKeyDeviceService<T>
    {
        /// <summary>
        /// Returns IEnumerable  with items with specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemsByKeyAsync(string key);

        /// <summary>
        /// Deletes All Items in _dataBaseConnection with specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task DeleteItemsByKeyAsync(string key);
    }
}
