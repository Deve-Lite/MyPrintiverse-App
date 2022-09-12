

using System.Linq.Expressions;

namespace MyPrintiverse.Core.Services.Device;

public abstract class BaseDeviceItemKeyService<T> : BaseDeviceItemService<T>, IDeviceItemKeyService<T> where T : class, IBaseModel, new()
{
    public BaseDeviceItemKeyService(string name) : base(name)
    {
    }

    public async Task DeleteItemsByKeyAsync(string key)
    {
        if (key == null)
            return;

       await db!.Table<T>().DeleteAsync(ItemIsMatch(key));
    }

    public async Task<IEnumerable<T>> GetItemsByKeyAsync(string key) => await db!.Table<T>().Where(ItemIsMatch(key)).ToListAsync();

    public virtual Expression<Func<T, bool>> ItemIsMatch(string key)
    {
        throw new NotImplementedException("Method must be implemented");
    }
}
