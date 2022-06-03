using MyPrintiverse.Base.Services;

namespace MyPrintiverse.FilamentsModule.Filaments.Services;

public class FilamentDeviceService : BaseDeviceService<Filament>
{
    public FilamentDeviceService()
    {
        dbName = $"{nameof(Filament)}.db";
    }


}

