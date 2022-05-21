
namespace MyPrintiverse.FilamentsModule.Types.Services;

public class FilamentTypeDeviceService : BaseDeviceService<FilamentType>
{
    public FilamentTypeDeviceService()
    {
        dbName = $"{nameof(FilamentType)}.db";
    }
}

