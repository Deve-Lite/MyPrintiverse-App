
using MyPrintiverse.FilamentsModule.Prints.Services;

namespace MyPrintiverse.FilamentsModule.Prints;

//TODO
public class PrintService : BaseItemAsyncService<Print>, IItemKeyService<Print>
{
	public PrintService(PrintDeviceService printDeviceService, PrintServiceService printServerService, IConfigService<Config> configService, IMessageService messageService, ISession session) : base(printServerService, printDeviceService, configService, messageService, session)
	{
	}

	public async Task<bool> DeleteItemsByKeyAsync(string key)
	{
		return false;
	}

	public async Task<IEnumerable<Print>> GetItemsByKeyAsync(string key)
	{
		return new List<Print>();
	}
}