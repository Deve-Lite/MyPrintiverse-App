
using MyPrintiverse.FilamentsModule.Types.Services;

namespace MyPrintiverse.FilamentsModule.Types
{
    public class FilamentTypeService : BaseItemService<FilamentType>
    {
        public FilamentTypeService(FilamentTypeDeviceService filamentTypeDeviceService, FilamentTypeInternetService filamentTypeInternetService, IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
        {
            ItemInternetService = filamentTypeInternetService;
            ItemDeviceService = filamentTypeDeviceService;
        }
    }
}
