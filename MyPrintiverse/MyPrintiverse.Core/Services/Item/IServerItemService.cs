using MyPrintiverse.Core.Http;
using MyPrintiverse.Core.Services.Helpers;

namespace MyPrintiverse.Core.Services.Server;

/// <summary>
/// Base interface for Internet Service 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IServerItemService<T>
{
    /// <summary>
    /// Returns response with data about item specified with objectId (if succesfull).
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IHttpResponse<T>> GetItemAsync(string objectId);
    /// <summary>
    /// Returns response with items (if succesfull).
    /// </summary>
    /// <returns></returns>
    Task<IHttpResponse<IEnumerable<T>>> GetItemsAsync();

    /// <summary>
    /// Adds item to database and returns if action was succesfull.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task<IHttpResponse<PostRequestData>> AddItemAsync(T item);

    /// <summary>
    /// Updates item to database and returns if action was succesfull.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    Task<IHttpResponse<PostRequestData>> UpdateItemAsync(T item);

    /// <summary>
    /// Deletes item specified by objectId and returns if action was succesfull.
    /// </summary>
    /// <param name="objectId"></param>
    /// <returns></returns>
    Task<bool> DeleteItemAsync(string objectId);

    /// <summary>
    /// Deletes all items and returns if action was succesfull.
    /// </summary>
    /// <returns></returns>
    Task<bool> DeleteAllAsync();
}