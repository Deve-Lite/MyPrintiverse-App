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

    protected BaseItemDeviceAsyncService(string name)
    {
        if (!name.EndsWith(".db"))
            name += ".db";

        DatabasePath = Path.Combine(FileSystem.AppDataDirectory, name);

        db = new SQLiteAsyncConnection(DatabasePath);

        Task.Run(async () => { await db.CreateTableAsync<T>(); });
    }

    protected SQLiteAsyncConnection? db;

    /// <summary>
    /// Method creates and connects to <c> Item </c> database.
    /// </summary>
    protected async Task ConnectToDatabase()
    {
        if (db != null)
            return;

        db = new SQLiteAsyncConnection(DatabasePath);
        await db.CreateTableAsync<T>();
    }

    public virtual async Task AddItemAsync(T? item)
    {
        if (item == null || string.IsNullOrEmpty(item.Id))
            return;

        await db?.InsertAsync(item, typeof(T))!;
    }

    public virtual async Task DeleteAllAsync()
    {
        await db?.DeleteAllAsync<T>()!;
    }
    public virtual async Task DeleteItemAsync(string objectId)
    {
        if (string.IsNullOrEmpty(objectId))
            return;

        await db?.DeleteAsync<T>(objectId)!;
    }

    public virtual async Task<T> GetItemAsync(string objectId)
    {
        return await db?.GetAsync<T>(objectId)!;
    }
    public virtual async Task<IEnumerable<T>> GetItemsAsync()
    {
        return await db.Table<T>().ToListAsync();
    }

    public virtual async Task UpdateItemAsync(T? item)
    {
        if (item == null || string.IsNullOrEmpty(item.Id))
            return;

        await db?.UpdateAsync(item, typeof(T))!;
    }
}
