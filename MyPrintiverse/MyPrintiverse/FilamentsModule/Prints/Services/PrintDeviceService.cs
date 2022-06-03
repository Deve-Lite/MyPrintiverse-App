
using MyPrintiverse.Base.Services;

namespace MyPrintiverse.FilamentsModule.Prints.Services;
public class PrintDeviceService : BaseDeviceService<Print>
{
    public PrintDeviceService()
    {
        dbName = $"{nameof(Print)}.db";
    }
}

