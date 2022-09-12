using MyPrintiverse.Core.Services.Device;
using MyPrintiverse.Core.Services.Server;

namespace MyPrintiverse.FilamentsModule.Filaments;

public class FilamentService : BaseItemService<Filament>
{
	public FilamentService(IServerItemService<Filament> itemServerService, IDeviceItemService<Filament> itemDeviceService, IConfigService<Config> configService, IMessageService messageService, ISession session) : base(itemServerService, itemDeviceService, configService, messageService, session)
	{
	}
}