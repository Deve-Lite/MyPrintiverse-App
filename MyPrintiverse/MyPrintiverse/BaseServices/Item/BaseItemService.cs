using System;

namespace MyPrintiverse.BaseServices.Item;

public abstract class BaseItemService<T> : BaseService, IItemAsyncService<T> where T : BaseModel
{
    protected IInternetItemAsyncService<T> ItemInternetService;
    protected IDeviceItemAsyncService<T> ItemDeviceService;

    public BaseItemService(IConfigService<Config> configService, ILogger logger, IMessageService messageService) : base(configService, logger, messageService)
    {

    }

    public async Task<bool> AddItemAsync(T item)
    {
        if (Session.IsLogged)
        {
            // TODO
            // Tutaj wstępne sprawdzanie requesta
            // Jak error to messaging center wyswietla problem itd.
            return false;
        }
        else
        {
            item.CreatedAt = DateTime.Now;
            item.EditedAt = DateTime.Now;
            item.Id = ObjectId.GenerateNewId().ToString();

            await ItemDeviceService.AddItemAsync(item);
            return true;
        }
    }

    public async Task<bool> DeleteAllAsync()
    {
        if (Session.IsLogged)
        {
            // TODO
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
            // TODO
            return false;
        }
        else
        {
            await ItemDeviceService.DeleteItemAsync(objectId);
            return true;
        }
    }

    public async Task<T> GetItemAsync(string objectId)
    {
        if (Session.IsLogged)
        {
            // Quick request to check if updated ????
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
            // Quick request ??
            return await ItemDeviceService.GetItemsAsync();
        }
        else
        {
            return await ItemDeviceService.GetItemsAsync();
        }
    }

    public async Task<bool> UpdateItemAsync(T item)
    {
        if (Session.IsLogged)
        {
            // TODO
            return false;
        }
        else
        {
            item.EditedAt = DateTime.Now;

            await ItemDeviceService.UpdateItemAsync(item);
            return true;
        }
    }
}

