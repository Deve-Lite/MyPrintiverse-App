using MyPrintiverse.FilamentsModule.Filaments.Services;

namespace MyPrintiverse.FilamentsModule.Filaments
{
    public class FilamentService : BaseItemService<Filament>
	{
		public FilamentService(FilamentDeviceService filamentDeviceService, FilamentInternetService filamentInternetService,IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
		{
		}
	}
}

