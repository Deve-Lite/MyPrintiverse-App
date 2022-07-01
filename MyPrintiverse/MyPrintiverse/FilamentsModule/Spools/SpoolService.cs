
using MyPrintiverse.FilamentsModule.Spools.Services;

namespace MyPrintiverse.FilamentsModule.Spools
{
    public class SpoolService : BaseItemService<Spool>//, IItemKeyAsyncService<Spool>
    {

        public SpoolService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
        {
        }
        //public SpoolService(SpoolDeviceService spoolDeviceSerfice, SpoolInternetService spoolInternetService)
        //{
        //    ItemDeviceService = spoolDeviceSerfice;
        //    ItemInternetService = spoolInternetService;
        //}

        //public async Task<bool> DeleteItemsByKeyAsync(string key)
        //{
        //    if (false)
        //    {
        //        //TODO
        //        await DeviceItemKeyAsyncService.GetItemsByKeyAsync(key);
        //        return true;
        //    }
        //    else
        //    {
        //        await DeviceItemKeyAsyncService.GetItemsByKeyAsync(key);
        //        return true;
        //    }
        //}

        //public async Task<IEnumerable<Spool>> GetItemsByKeyAsync(string key)
        //{
        //    if (false)
        //    {
        //        //TODO
        //        return await DeviceItemKeyAsyncService.GetItemsByKeyAsync(key);
        //    }
        //    else
        //    {
        //        return await DeviceItemKeyAsyncService.GetItemsByKeyAsync(key);
        //    }
        //}
    }
}
