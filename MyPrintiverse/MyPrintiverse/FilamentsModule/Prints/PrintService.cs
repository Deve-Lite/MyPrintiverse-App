
using MyPrintiverse.FilamentsModule.Prints.Services;

namespace MyPrintiverse.FilamentsModule.Prints;

public class PrintService : BaseItemAsyncService<Print>
{
	public PrintService(PrintDeviceService printDeviceService, PrintServiceService printServerService, IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(printServerService, printDeviceService, configService, logger, messageService, session)
	{
	}
}