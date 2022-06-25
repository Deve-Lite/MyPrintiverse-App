namespace MyPrintiverse.BaseServices.Interfaces
{
    /// <summary>
    /// Global service which connects Internet Service and Device Service.
    /// </summary>
    /// <typeparam name="Model"></typeparam>
    public interface IItemAsyncService<Model>
    {
        /// <summary>
        /// Gets item by objectId. (returns null if unsuccesful)
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        Task<Model> GetItemAsync(string objectId);

        /// <summary>
        /// Get all items from database. (returns null if unsuccesful)
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Model>> GetItemsAsync();

        /// <summary>
        /// Adds new item and returns true if action was successful.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> AddItemAsync(Model item);

        /// <summary>
        /// Updates item and returns true if action was successful)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> UpdateItemAsync(Model item);

        /// <summary>
        /// Deletes item and returns true if action was successful.
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        Task<bool> DeleteItemAsync(string objectId);

        /// <summary>
        /// Deletes items and returns true if action was successful.
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteAllAsync();
    }
}

