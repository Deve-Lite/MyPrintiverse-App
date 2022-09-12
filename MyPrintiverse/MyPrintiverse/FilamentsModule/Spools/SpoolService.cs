
using MyPrintiverse.Core.Services.Device;
using MyPrintiverse.Core.Services.Server;

namespace MyPrintiverse.FilamentsModule.Spools;

public class SpoolService : BaseItemKeyService<Spool>
{
	public SpoolService(IServerItemService<Spool> itemServerService, IDeviceItemKeyService<Spool> deviceItemKeyService, IConfigService<Config> configService, IMessageService messageService, ISession session) : base(itemServerService, deviceItemKeyService, configService, messageService, session)
	{
	}
}