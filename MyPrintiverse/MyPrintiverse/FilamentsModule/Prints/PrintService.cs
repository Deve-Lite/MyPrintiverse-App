
using MyPrintiverse.FilamentsModule.Prints.Services;

namespace MyPrintiverse.FilamentsModule.Prints
{
    public class PrintService : BaseService<Print>
    {
        public PrintService(PrintDeviceService printDeviceService, PrintInternetService printInternetService)
        {
            ItemDeviceService = printDeviceService;
            ItemInternetService = printInternetService;
        }
    }
}
