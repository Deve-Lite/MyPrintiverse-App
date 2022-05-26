using System;
namespace MyPrintiverse.Interfaces
{
    /// <summary>
    /// Global Service 
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    public interface IItemAsyncService<Item>
    {

        Task<Item> GetItemAsync(string objectId);

        Task<IEnumerable<Item>> GetItemsAsync();

        Task<bool> AddItemAsync(Item item);

        Task<bool> UpdateItemAsync(Item item);

        Task<bool> DeleteItemAsync(string objectId);

        Task<bool> DeleteAllAsync();
    }
}

