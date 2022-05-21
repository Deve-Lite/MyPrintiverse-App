

namespace MyPrintiverse.FilamentsModule.Rolls.Services;
public class SpoolDeviceService : BaseDeviceService<Spool>
{
    public SpoolDeviceService()
    {
        dbName = $"{nameof(Spool)}.db";
    }
}

