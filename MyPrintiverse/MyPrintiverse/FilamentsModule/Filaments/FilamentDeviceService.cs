
using MyPrintiverse.Base.Services;

namespace MyPrintiverse.FilamentsModule.Filaments;

public class FilamentDeviceService : BaseDeviceService<Filament>
{
    public FilamentDeviceService()
    {
        dbName = $"{nameof(Filament)}.db";
    }


}

