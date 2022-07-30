

namespace MyPrintiverse.Core.Services;

/// <summary>
/// Generic service for device databases.
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
public abstract class BaseItemDeviceKeyAsyncService<T> : BaseItemDeviceAsyncService<T>, IItemKeyDeviceService<T> where T : BaseModel, new()
{
    protected BaseItemDeviceKeyAsyncService(string name) : base(name)
    {
        //DO PRZEMYSLENIA klasa
    }

    public async Task DeleteItemsByKeyAsync(string key)
    {
        
    }

    public async Task<IEnumerable<T>> GetItemsByKeyAsync(string key)
    {
        return null;
    }
}
