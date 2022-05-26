

using MyPrintiverse.Interfaces;

namespace MyPrintiverse.Utils.Base
{
    /// <summary>
    /// Generic service for device databases.
    /// </summary>
    public abstract class BaseDeviceService<Item> : IDeviceItemAsyncService<Item> where Item : class, new()
    {
        /// <summary>
        /// Database name. (If not set it creates random database)
        /// </summary>
        protected string dbName = DateTime.Now.Ticks.ToString() + ".db";

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

            db = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, dbName));
            await db.CreateTableAsync<Item>();
        }

        public async Task AddItemAsync(Item item)
        {
            if (item == null || string.IsNullOrEmpty((item as BaseModel).Id))
                return;

            await ConnectToDatabase();
            await db.InsertAsync(item,typeof(Item));
        }

        public async Task DeleteAllAsync()
        {
            await ConnectToDatabase();
            await db.DeleteAllAsync<Item>();
        }
        public async Task DeleteItemAsync(string objectId)
        {
            if (string.IsNullOrEmpty(objectId))
                return;

            await ConnectToDatabase();
            await db.DeleteAsync<Item>(objectId);
        }

        public async Task<Item> GetItemAsync(string objectId)
        {
            await ConnectToDatabase();
            return await db.GetAsync<Item>(objectId);
            /*Do sprawdzenia która metoda lepsza */
            //return await db.Table<Item>().FirstOrDefaultAsync(x => (x as BaseModel).Id == objectId);
        }
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            await ConnectToDatabase();
            return await db.Table<Item>().ToListAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            if (item == null || string.IsNullOrEmpty((item as BaseModel).Id))
                return;

            await ConnectToDatabase();
            await db.UpdateAsync(item, typeof(Item));
        }
    }
}
