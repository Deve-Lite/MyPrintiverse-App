using MyPrintiverse.Core.Services.Device;
using MyPrintiverse.Core.Services.Server;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.Services;

public abstract class BaseItemService<T> : BaseService, IItemService<T> where T : BaseModel
{
    protected IServerItemService<T> ItemInternetService;
    protected IDeviceItemService<T> ItemDeviceService;

    protected BaseItemService(IServerItemService<T> itemInternetService, IDeviceItemService<T> itemDeviceService, IConfigService<Config> configService, IMessageService messageService, ISession session) : base(configService, messageService, session)
	{
        ItemInternetService = itemInternetService;
        ItemDeviceService = itemDeviceService;
    }

    public async Task<bool> AddItemAsync(T item)
    {
        if (Session.IsLogged)
        {
            var response = await ItemInternetService.AddItemAsync(item);

            if (response.IsSuccessful)
            {

                //await ItemDeviceService.AddItemAsync();
                return true;
            }

            return false;
        }
        else
        {
            FillBaseData(item);

            await ItemDeviceService.AddItemAsync(item);
            return true;
        }
    }
    public async Task<bool> DeleteAllAsync()
    {
        if (Session.IsLogged)
        {
            var response = await ItemInternetService.DeleteAllAsync();

            if (response)
            {
                await ItemDeviceService.DeleteAllAsync();
                return true;
            }

            return false;
        }
        else
        {
            await ItemDeviceService.DeleteAllAsync();
            return true;
        }
    }
    public async Task<bool> DeleteItemAsync(string objectId)
    {
        if (Session.IsLogged)
        {
            var response = await ItemInternetService.DeleteItemAsync(objectId);

            if (response)
            {
                await ItemDeviceService.DeleteItemAsync(objectId);
                return true;
            }

            return false;
        }
        else
        {
            await ItemDeviceService.DeleteItemAsync(objectId);
            return true;
        }
    }
    public async Task<bool> UpdateItemAsync(T item)
    {
        if (Session.IsLogged)
        {
            var response = await ItemInternetService.UpdateItemAsync(item);

            if (response.IsSuccessful)
            {
                //await ItemDeviceService.UpdateItemAsync(response.Item2);
                return true;
            }

            return false;
        }
        else
        {
            item.EditedAt = DateTime.Now;

            await ItemDeviceService.UpdateItemAsync(item);
            return true;
        }
    }

    // Do przemyslenia czy tutaj na szybko nie powinna pojsc jakas metoda do syncowania przy zalogowaniu 
    public async Task<T> GetItemAsync(string objectId)
    {
        if (Session.IsLogged)
        {
            return await ItemDeviceService.GetItemAsync(objectId);
        }
        else
        {
            return await ItemDeviceService.GetItemAsync(objectId);
        }
    }

    public async Task<IEnumerable<T>> GetItemsAsync()
    {
        if (Session.IsLogged)
        {
            return await ItemDeviceService.GetItemsAsync();
        }
        else
        {
            return await ItemDeviceService.GetItemsAsync();
        }
    }
}

