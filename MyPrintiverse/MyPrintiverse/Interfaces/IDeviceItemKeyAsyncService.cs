﻿namespace MyPrintiverse.Interfaces
{
    public interface IDeviceItemKeyAsyncService<T>
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
        Task DeleteItemsByKeyAsync(string key);
    }
}
