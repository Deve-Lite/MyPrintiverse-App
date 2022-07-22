
using MyPrintiverse.FilamentsModule.Spools.Services;

namespace MyPrintiverse.FilamentsModule.Spools;

public class SpoolService : BaseItemAsyncService<Spool>, IItemKeyService<Spool>
{

	public SpoolService(SpoolServerService itemServerService, SpoolDeviceService itemDeviceService, IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(itemServerService, itemDeviceService, configService, logger, messageService, session)
	{
	}



	public async Task<bool> DeleteItemsByKeyAsync(string key)
	{
		//if (false)
		//{
		//    //TODO
		//    await ItemInternetService.GetItemsByKeyAsync(key);
		//    return true;
		//}
		//else
		//{
		//    await DeviceItemKeyAsyncService.GetItemsByKeyAsync(key);
		//    return true;
		//}

		return false;
	}

	public async Task<IEnumerable<Spool>> GetItemsByKeyAsync(string key)
	{
		//if (false)
		//{
		//    //TODO
		//    return await DeviceItemKeyAsyncService.GetItemsByKeyAsync(key);
		//}
		//else
		//{
		//    return await DeviceItemKeyAsyncService.GetItemsByKeyAsync(key);
		//}

		return null;
	}
}