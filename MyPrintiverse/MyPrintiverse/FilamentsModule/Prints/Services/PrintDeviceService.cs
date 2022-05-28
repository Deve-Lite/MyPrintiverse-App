
using MyPrintiverse.Base.Services;

namespace MyPrintiverse.FilamentsModule.Prints.Service;
public class PrintDeviceService : BaseDeviceService<Print>
{
    public PrintDeviceService()
    {
        dbName = $"{nameof(Print)}.db";
    }
}

