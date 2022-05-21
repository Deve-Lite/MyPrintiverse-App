namespace MyPrintiverse.Core.Items;

/// <summary>
/// Generic service for device databases.
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
public abstract class BaseItemDeviceAsyncService<T> : IDeviceItemService<T> where T : BaseModel, new()
{
    /// <summary>
    /// Database name. (If not set it creates random database)
    /// </summary>
    protected string DatabasePath { get; private set; }

    public BaseItemDeviceAsyncService(string name)
    {
        if (!name.EndsWith(".db"))
            name += ".db";

        DatabasePath = Path.Combine(FileSystem.AppDataDirectory, name);
    }

    protected SQLiteAsyncConnection db;

    /// <summary>
    /// Method creates and connects to <c> Item </c> database.
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    /// <param name="dbName"></param>
    protected async Task ConnectToDatabase()
    {
        if (db != null)
            return;

        db = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DatabasePath));
        await db.CreateTableAsync<T>();
    }

    public virtual async Task AddItemAsync(T item)
    {
        if (item == null || string.IsNullOrEmpty(item.Id))
            return;

        await ConnectToDatabase();
        await db.InsertAsync(item, typeof(T));
    }

    public virtual async Task DeleteAllAsync()
    {
        await ConnectToDatabase();
        await db.DeleteAllAsync<T>();
    }
    public virtual async Task DeleteItemAsync(string objectId)
    {
        if (string.IsNullOrEmpty(objectId))
            return;

        await ConnectToDatabase();
        await db.DeleteAsync<T>(objectId);
    }

    public virtual async Task<T> GetItemAsync(string objectId)
    {
        await ConnectToDatabase();
        return await db.GetAsync<T>(objectId);
        /*Do sprawdzenia która metoda lepsza */
        //return await db.Table<Item>().FirstOrDefaultAsync(x => (x as BaseModel).Id == objectId);
    }
    public virtual async Task<IEnumerable<T>> GetItemsAsync()
    {
        await ConnectToDatabase();
        return await db.Table<T>().ToListAsync();
    }

    public virtual async Task UpdateItemAsync(T item)
    {
        if (item == null || string.IsNullOrEmpty(item.Id))
            return;

        await ConnectToDatabase();
        await db.UpdateAsync(item, typeof(T));
    }
}
