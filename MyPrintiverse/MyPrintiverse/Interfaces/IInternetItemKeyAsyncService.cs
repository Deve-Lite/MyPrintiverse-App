namespace MyPrintiverse.Interfaces
{
    public interface IInternetItemKeyAsyncService<T>
    {
        /// <summary>
        /// Returns IEnumerable with items with specified key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<RestResponse<IEnumerable<T>>> GetItemsByKeyAsync(string key);

        /// <summary>
        /// Deletes All Items in db with specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<RestResponse<T>> DeleteItemsByKeyAsync(string key);
    }
}
