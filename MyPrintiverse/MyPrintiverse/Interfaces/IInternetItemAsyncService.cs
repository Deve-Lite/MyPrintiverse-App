using System;
namespace MyPrintiverse.Interfaces
{
	public interface IInternetItemAsyncService<Model>
	{
        /// <summary>
        /// Returns sqlite db item by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RestResponse<Model>> GetItemAsync(string objectId, bool isFirst);
        /// <summary>
        /// Returns IEnumerable of items from sqlite db.
        /// </summary>
        /// <returns></returns>
        Task<RestResponse<IEnumerable<Model>>> GetItemsAsync(bool isFirst);

        /// <summary>
        /// Adds item to sqlite db.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<RestResponse<Model>> AddItemAsync(Model item, bool isFirst);

        /// <summary>
        /// Updates item in sqlite db. Should update only when exists! 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<RestResponse<Model>> UpdateItemAsync(Model item, bool isFirst);

        /// <summary>
        /// Deletes item by id in sqlite db.
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        Task<RestResponse<bool>> DeleteItemAsync(string objectId, bool isFirst);

        /// <summary>
        /// Methods drops table (item database).
        /// </summary>
        /// <returns></returns>
        Task<RestResponse<bool>> DeleteAllAsync(bool isFirst);
    }
}

