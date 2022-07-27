

namespace MyPrintiverse.FilamentsModule.Prints.Services;
public class PrintDeviceService : BaseItemDeviceAsyncService<Spool>
{
    public PrintDeviceService() : base(nameof(Spool))
    {
    }
}

