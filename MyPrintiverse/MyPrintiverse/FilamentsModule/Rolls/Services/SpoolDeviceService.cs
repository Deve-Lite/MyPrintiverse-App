

namespace MyPrintiverse.FilamentsModule.Rolls.Services;
public class SpoolDeviceService : BaseDeviceService<Spool>, IItemKeyAsyncService<Spool>
{
    public SpoolDeviceService()
    {
        dbName = $"{nameof(Spool)}.db";
    }

    public async Task DeleteItemsByKeyAsync(string key)
    {
        await ConnectToDatabase();
        /* Do sprawdzenia czy usuwa elementy */
        await db.Table<Spool>().DeleteAsync(x => x.FilamentId == key);
    }

    public async Task<IEnumerable<Spool>> GetItemsByKeyAsync(string key)
    {

        await ConnectToDatabase();
        /* Do sprawdzenia czy zwraca wszystkie elementy*/
        return await db.Table<Spool>().Where(x => x.FilamentId == key).ToListAsync();
    }
}

