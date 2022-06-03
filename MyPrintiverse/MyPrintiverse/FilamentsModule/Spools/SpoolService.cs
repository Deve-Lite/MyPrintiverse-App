using MyPrintiverse.FilamentsModule.Rolls.Services;
using MyPrintiverse.FilamentsModule.Spools.Services;

namespace MyPrintiverse.FilamentsModule.Spools
{
    public class SpoolService : BaseService<Spool>
    {
        public SpoolService(SpoolDeviceService spoolDeviceSerfice, SpoolInternetService spoolInternetService)
        {
            ItemDeviceService = spoolDeviceSerfice;
            ItemInternetService = spoolInternetService;
        }
    }
}
