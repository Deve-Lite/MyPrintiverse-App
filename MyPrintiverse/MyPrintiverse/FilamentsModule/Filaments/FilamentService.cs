using MyPrintiverse.FilamentsModule.Filaments.Services;

namespace MyPrintiverse.FilamentsModule.Filaments;

public class FilamentService : BaseItemAsyncService<Filament>
{
	public FilamentService(FilamentServerService itemServerService, FilamentDeviceService itemDeviceService, IConfigService<Config> configService, IMessageService messageService, ISession session) : base(itemServerService, itemDeviceService, configService, messageService, session)
	{
	}
}