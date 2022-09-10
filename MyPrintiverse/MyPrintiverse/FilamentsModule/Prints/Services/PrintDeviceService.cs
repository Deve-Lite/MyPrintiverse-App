

using MyPrintiverse.Core.Services.Device;

namespace MyPrintiverse.FilamentsModule.Prints.Services;
public class PrintDeviceService : BaseDeviceItemService<Print>
{
    public PrintDeviceService() : base(nameof(Print))
    {
    }
}

