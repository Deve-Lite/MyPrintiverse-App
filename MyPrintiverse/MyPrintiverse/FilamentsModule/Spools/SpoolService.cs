
using MyPrintiverse.FilamentsModule.Spools.Services;

namespace MyPrintiverse.FilamentsModule.Spools
{
    public class SpoolService : BaseItemService<Spool>, IItemKeyAsyncService<Spool>
    {
        private IInternetItemKeyAsyncService<Spool> InternetItemKeyAsyncService;
        private IDeviceItemKeyAsyncService<Spool> DeviceItemKeyAsyncService;

        public SpoolService(SpoolDeviceService spoolDeviceSerfice, SpoolInternetService spoolInternetService)
        {
            ItemDeviceService = spoolDeviceSerfice;
            ItemInternetService = spoolInternetService;
        }

        public async Task<bool> DeleteItemsByKeyAsync(string key)
        {
            if (GlobalConst.IsLogged)
            {
                //TODO
                await DeviceItemKeyAsyncService.GetItemsByKeyAsync(key);
                return true;
            }
            else
            {
                await DeviceItemKeyAsyncService.GetItemsByKeyAsync(key);
                return true;
            }
        }

        public async Task<IEnumerable<Spool>> GetItemsByKeyAsync(string key)
        {
            if (GlobalConst.IsLogged)
            {
                //TODO
                return await DeviceItemKeyAsyncService.GetItemsByKeyAsync(key);
            }
            else
            {
                return await DeviceItemKeyAsyncService.GetItemsByKeyAsync(key);
            }
        }
    }
}
