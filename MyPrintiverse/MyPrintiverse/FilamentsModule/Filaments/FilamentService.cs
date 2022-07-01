using MyPrintiverse.FilamentsModule.Filaments.Services;

namespace MyPrintiverse.FilamentsModule.Filaments
{
    public class FilamentService : BaseItemAsyncService<Filament>
	{
		public FilamentService(FilamentDeviceService filamentDeviceService, FilamentInternetService filamentInternetService,IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
		{
			//do poprawy base item service
		}
	}
}

