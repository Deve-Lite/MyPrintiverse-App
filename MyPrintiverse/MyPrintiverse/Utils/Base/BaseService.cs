

namespace MyPrintiverse.Utils.Base
{
    /// <summary>
    /// Base service for device databases.
    /// </summary>
    public abstract class BaseService
    {
        protected SQLiteAsyncConnection db;

        /// <summary>
        /// Method creates and connects to <c> Item </c> database.
        /// </summary>
        /// <typeparam name="Item"></typeparam>
        /// <param name="dbName"></param>
        /// <returns> Nothing </returns>
        protected async Task ConnectToDatabase<Item>(string dbName) where Item : new()
        {
            if (db != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);
            db = new SQLiteAsyncConnection(dbPath);
            await db.CreateTableAsync<Item>();
        }
    }
}
