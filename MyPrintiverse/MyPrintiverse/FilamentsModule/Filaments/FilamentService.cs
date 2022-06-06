using MyPrintiverse.FilamentsModule.Filaments.Services;

namespace MyPrintiverse.FilamentsModule.Filaments
{
    public class FilamentService : BaseItemService<Filament>
	{
        public FilamentService(FilamentDeviceService filamentDeviceService, FilamentInternetService filamentInternetService)
		{
			ItemInternetService = filamentInternetService;
			ItemDeviceService = filamentDeviceService;
		}
    }
}

