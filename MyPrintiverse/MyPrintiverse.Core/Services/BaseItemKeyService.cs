
using MyPrintiverse.Core.Services.Device;
using MyPrintiverse.Core.Services.Server;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.Services
{
    public abstract class BaseItemKeyService<T> : BaseItemService<T>, IItemKeyService<T> where T : BaseModel
    {
        protected new IDeviceItemKeyService<T> ItemDeviceService;
        protected BaseItemKeyService(IServerItemService<T> itemServerService, IDeviceItemKeyService<T> deviceItemKeyService, IConfigService<Config> configService, IMessageService messageService, ISession session) : base(itemServerService, deviceItemKeyService, configService, messageService, session)
        {
            ItemDeviceService = deviceItemKeyService;
        }

        public async Task<IEnumerable<T>> GetItemsByKeyAsync(string key)
        {
            if (Session.IsLogged)
            {
                // TODO sync
                var response = await ItemServerService.GetItemAsync(key);

                return await ItemDeviceService.GetItemsByKeyAsync(key);
            }
            else
            {
                return await ItemDeviceService.GetItemsByKeyAsync(key);
            }
        }

        public async Task<bool> DeleteItemsByKeyAsync(string key)
        {
            await ItemDeviceService.DeleteItemsByKeyAsync(key);
            return true;
        }
    }
}
