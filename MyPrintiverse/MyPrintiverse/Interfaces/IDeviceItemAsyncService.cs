namespace MyPrintiverse.Interfaces
{
    /// <summary>
    /// Default interface for device service with standard CRUD operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDeviceItemAsyncService<T>
    {
        /// <summary>
        /// Returns sqlite db item by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetItemAsync(string objectId);
        /// <summary>
        /// Returns IEnumerable of items from sqlite db.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemsAsync();

        /// <summary>
        /// Adds item to sqlite db.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task AddItemAsync(T item);

        /// <summary>
        /// Updates item in sqlite db. Should update only when exists! 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task UpdateItemAsync(T item);

        /// <summary>
        /// Deletes item by id in sqlite db.
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        Task DeleteItemAsync(string objectId);
        /// <summary>
        /// Methods drops table (item database).
        /// </summary>
        /// <returns></returns>
        Task DeleteAllAsync();
    }
}
