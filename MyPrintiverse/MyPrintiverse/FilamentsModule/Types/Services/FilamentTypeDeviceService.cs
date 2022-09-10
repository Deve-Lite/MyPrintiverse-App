

using MyPrintiverse.Core.Services.Device;

namespace MyPrintiverse.FilamentsModule.Types.Services;

public class FilamentTypeDeviceService : BaseDeviceItemService<FilamentType>
{ 
    public FilamentTypeDeviceService() : base(nameof(FilamentType))
    {
    }
}
