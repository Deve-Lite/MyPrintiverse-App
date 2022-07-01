

namespace MyPrintiverse.FilamentsModule.Types.Services
{
    public class FilamentTypeDeviceService : BaseItemDeviceService<FilamentType>
    {
        public FilamentTypeDeviceService()
        {
            dbName = $"{nameof(FilamentType)}.db";
        }
    }
}
