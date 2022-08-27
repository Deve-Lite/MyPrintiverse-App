namespace MyPrintiverse.Core.Services;

/// <summary>
/// Generic service for device databases.
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
public abstract class BaseItemDeviceAsyncService<T> : IDeviceItemService<T> where T : BaseModel, new()
{
    /// <summary>
    /// Database name. (If not set it creates random database)
    /// </summary>
    protected string DatabasePath { get; }

    /// <summary>
    /// Database connection instance.
    /// </summary>
    protected SQLiteAsyncConnection? db;

    protected BaseItemDeviceAsyncService(string name)
    {
        if (!name.EndsWith(".db"))
            name += ".db";

        DatabasePath = Path.Combine(FileSystem.AppDataDirectory, name);

        db = new SQLiteAsyncConnection(DatabasePath);

        Task.Run(async () => { await db.CreateTableAsync<T>(); });
    }

    public virtual async Task AddItemAsync(T? item)
    {
        if (item == null || string.IsNullOrEmpty(item.Id))
            return;

        await db!.InsertAsync(item, typeof(T));
    }

    public virtual async Task DeleteAllAsync() => await db!.DeleteAllAsync<T>();
    public virtual async Task DeleteItemAsync(string objectId)
    {
        if (string.IsNullOrEmpty(objectId))
            return;

        await db!.DeleteAsync<T>(objectId);
    }

    public virtual async Task<T> GetItemAsync(string objectId) => await db!.GetAsync<T>(objectId);

    public virtual async Task<IEnumerable<T>> GetItemsAsync() => await db!.Table<T>().ToListAsync();

    public virtual async Task UpdateItemAsync(T? item)
    {
        if (item == null || string.IsNullOrEmpty(item.Id))
            return;

        await db!.UpdateAsync(item, typeof(T));
    }
}
