using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintiverse.FilamentsModule.Rolls
{
    /// <summary>
    /// Interface with base methods for groupped items with 'key'.
    /// </summary>
    public interface IItemKeyAsyncService<Item>
    {
        /// <summary>
        /// Returns IEnumerable  with items with specified key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<Item>> GetItemsByKeyAsync(string key);

        /// <summary>
        /// Deletes All Items in db with specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task DeleteItemsByKeyAsync(string key);
    }
}
