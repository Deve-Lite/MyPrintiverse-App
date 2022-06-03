
using MyPrintiverse.FilamentsModule.Types.Services;

namespace MyPrintiverse.FilamentsModule.Types
{
    public class FilamentTypeService : BaseService<FilamentType>
    {
        public FilamentTypeService(FilamentTypeDeviceService filamentTypeDeviceService, FilamentTypeInternetService filamentTypeInternetService) 
        {
            ItemInternetService = filamentTypeInternetService;
            ItemDeviceService = filamentTypeDeviceService;
        }
    }
}
