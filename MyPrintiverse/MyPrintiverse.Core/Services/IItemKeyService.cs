namespace MyPrintiverse.Core.Services;

/// <summary>
/// Interface with base methods for items groupped with 'key'.
/// </summary>
public interface IItemKeyService<T> : IItemService<T>
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
    Task<bool> DeleteItemsByKeyAsync(string key);
}
