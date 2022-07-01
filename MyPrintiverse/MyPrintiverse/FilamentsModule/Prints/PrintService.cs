
using MyPrintiverse.FilamentsModule.Prints.Services;

namespace MyPrintiverse.FilamentsModule.Prints
{
    public class PrintService : BaseItemService<Print>
    {
        public PrintService(PrintDeviceService printDeviceService, PrintInternetService printInternetService,IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
        {
        }
    }
}
