namespace MyPrintiverse.BaseServices.Item;

/// <summary>
/// Interface with base methods for groupped items with 'key'.
/// </summary>
public interface IItemKeyAsyncService<TItem>
{
    /// <summary>
    /// Returns IEnumerable  with items with specified key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<IEnumerable<TItem>> GetItemsByKeyAsync(string key);

    /// <summary>
    /// Deletes All Items in _dataBaseConnection with specified key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task DeleteItemsByKeyAsync(string key);
}
