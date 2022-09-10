

using MyPrintiverse.Core.Services.Device;

namespace MyPrintiverse.FilamentsModule.Filaments.Services;

public class FilamentDeviceService : BaseDeviceItemService<Filament>
{
    public FilamentDeviceService() : base(nameof(Filament))
    {
    }
}

