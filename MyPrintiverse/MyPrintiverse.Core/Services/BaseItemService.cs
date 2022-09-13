using MongoDB.Bson;
using MyPrintiverse.Core.Services.Device;
using MyPrintiverse.Core.Services.Server;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.Services;

public abstract class BaseItemService<T> : BaseService, IItemService<T> where T : BaseModel
{
    protected  IServerItemService<T> ItemServerService;
    protected IDeviceItemService<T> ItemDeviceService;

    protected BaseItemService(IServerItemService<T> itemServerService, IDeviceItemService<T> itemDeviceService, IConfigService<Config> configService, IMessageService messageService, ISession session) : base(configService, messageService, session)
	{
        ItemServerService = itemServerService;
        ItemDeviceService = itemDeviceService;
    }

    public async Task<bool> AddItemAsync(T item)
    {
        if (Session.IsLogged)
        {
            var response = await ItemServerService.AddItemAsync(item);

            if (response.IsSuccessful)
            {
                var newItemResponse = await ItemServerService.GetItemAsync(response.Value.Id);
                if(newItemResponse.IsSuccessful)
                    await ItemDeviceService.AddItemAsync(newItemResponse.Value);
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
            var response = await ItemServerService.DeleteAllAsync();

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
            var response = await ItemServerService.DeleteItemAsync(objectId);

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
            var response = await ItemServerService.UpdateItemAsync(item);

            if (response.IsSuccessful)
            {
                var newItemResponse = await ItemServerService.GetItemAsync(response.Value.Id);
                if (newItemResponse.IsSuccessful)
                    await ItemDeviceService.UpdateItemAsync(newItemResponse.Value);
                return true;
            }

            return false;
        }
        else
        {
            item.EditedAtTicks = DateTime.Now.Ticks;

            await ItemDeviceService.UpdateItemAsync(item);
            return true;
        }
    }

    public async Task<T> GetItemAsync(string objectId)
    {
        if (Session.IsLogged)
        {
            var response = await ItemServerService.GetItemAsync(objectId);
            // TODO sync

            if (response.IsSuccessful)
            {
                return response.Value;
            }

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
            var items = await ItemDeviceService.GetItemsAsync();

            var newest_date = items.MaxBy(x=>x.EditedAtTicks);

            var response = await ItemServerService.GetItemsAsync();
            // TODO sync

            if (response.IsSuccessful)
            {
                // sync items 
                return response.Value;
            }

            return await ItemDeviceService.GetItemsAsync();
        }
        else
        {
            return await ItemDeviceService.GetItemsAsync();
        }
    }
}

