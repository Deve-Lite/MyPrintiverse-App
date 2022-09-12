using System.Linq.Expressions;

namespace MyPrintiverse.Core.Services.Device;

/// <summary>
/// Interface with base methods for items groupped with 'key'. Designed for device service.
/// </summary>
public interface IDeviceItemKeyService<TModel> : IDeviceItemService<TModel>
{
    /// <summary>
    /// Returns IEnumerable  with items with specified key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<IEnumerable<TModel>> GetItemsByKeyAsync(string key);

    /// <summary>
    /// Deletes All Items in _dataBaseConnection with specified key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task DeleteItemsByKeyAsync(string key);

    /// <summary>
    /// Function checks if item matches key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Expression<Func<TModel, bool>> ItemIsMatch(string key);
}
