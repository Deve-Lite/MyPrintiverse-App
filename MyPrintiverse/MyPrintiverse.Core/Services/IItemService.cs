namespace MyPrintiverse.Core.Services;

/// <summary>
/// Global service which connects Internet Service and Device Service.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IItemService<T>
{
    /// <summary>
    /// Gets item by objectId. (returns null if unsuccesful)
    /// </summary>
    /// <param name="objectId"></param>
    /// <returns></returns>
    Task<T> GetItemAsync(string objectId);

    /// <summary>
    /// Get all items from database. (returns null if unsuccesful)
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> GetItemsAsync();

    /// <summary>
    /// Adds new item and returns true if action was successful.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task<bool> AddItemAsync(T item);

    /// <summary>
    /// Updates item and returns true if action was successful)
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task<bool> UpdateItemAsync(T item);

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
