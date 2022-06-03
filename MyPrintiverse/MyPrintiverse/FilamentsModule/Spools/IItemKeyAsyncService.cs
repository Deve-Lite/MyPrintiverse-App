
namespace MyPrintiverse.FilamentsModule.Spools
{
    /// <summary>
    /// Interface with base methods for groupped items with 'key'. (Designed for Groupped CollectionViews)
    /// </summary>
    public interface IItemKeyAsyncService<T>
    {
        /// <summary>
        /// Returns IEnumerable with items with specified key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemsByKeyAsync(string key);

        /// <summary>
        /// Deletes All Items in db with specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> DeleteItemsByKeyAsync(string key);
    }
}
