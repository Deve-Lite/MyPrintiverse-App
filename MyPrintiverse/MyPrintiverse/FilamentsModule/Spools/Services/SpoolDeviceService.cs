namespace MyPrintiverse.FilamentsModule.Spools.Services;
public class SpoolDeviceService : BaseItemDeviceAsyncService<Spool>, IItemKeyDeviceService<Spool> 
{ 
    public SpoolDeviceService() : base(nameof(Spool))
    {
    }

    public async Task DeleteItemsByKeyAsync(string key)
    {
        /* Do sprawdzenia czy usuwa elementy */
        await db.Table<Spool>().DeleteAsync(x => x.FilamentId == key);
    }

    public async Task<IEnumerable<Spool>> GetItemsByKeyAsync(string key)
    {
        /* Do sprawdzenia czy zwraca wszystkie elementy*/
        return await db.Table<Spool>().Where(x => x.FilamentId == key).ToListAsync();
    }
}

