using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintiverse.Interfaces.DeviceService
{
    /// <summary>
    /// Default interface for internet service.
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    public interface IItemAsyncService<Item>
    {
        /// <summary>
        /// Returns sqlite db item by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Item> GetItemAsync(string objectId);
        /// <summary>
        /// Returns IEnumerable of items from sqlite db.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Item>> GetItemsAsync();
        /// <summary>
        /// Adds item to sqlite db.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task AddItemAsync(Item item);
        /// <summary>
        /// Updates item in sqlite db. Should update only when exists! 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task UpdateItemAsync(Item item);
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
