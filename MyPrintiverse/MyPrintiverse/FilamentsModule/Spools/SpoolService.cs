
using MyPrintiverse.FilamentsModule.Spools.Services;

namespace MyPrintiverse.FilamentsModule.Spools;

public class SpoolService : BaseItemAsyncService<Spool>, IItemKeyService<Spool>
{
	protected IItemKeyDeviceService<Spool> ItemDeviceKeyService;

	public SpoolService(SpoolServerService itemServerService, SpoolDeviceService itemDeviceService, IConfigService<Config> configService, IMessageService messageService, ISession session) : base(itemServerService, itemDeviceService, configService, messageService, session)
	{
		ItemDeviceKeyService = itemDeviceService;
    }


	public async Task<bool> DeleteItemsByKeyAsync(string key)
	{
		await ItemDeviceKeyService.GetItemsByKeyAsync(key);
        return true;
	}

	public async Task<IEnumerable<Spool>> GetItemsByKeyAsync(string key) => await ItemDeviceKeyService.GetItemsByKeyAsync(key);
}