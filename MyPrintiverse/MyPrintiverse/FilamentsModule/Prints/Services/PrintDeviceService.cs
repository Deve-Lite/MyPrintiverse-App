

namespace MyPrintiverse.FilamentsModule.Prints.Services;
public class PrintDeviceService : BaseItemDeviceService<Print>
{
    public PrintDeviceService()
    {
        dbName = $"{nameof(Print)}.db";
    }
}

