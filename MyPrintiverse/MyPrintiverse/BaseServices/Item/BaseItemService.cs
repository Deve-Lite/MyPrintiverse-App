using MyPrintiverse.BaseModels;
using System;

namespace MyPrintiverse.BaseServices.Item;

public abstract class BaseItemService<T> : BaseService, IItemService<T> where T : BaseModel
{
    protected IInternetItemService<T> ItemInternetService;
    protected IDeviceItemService<T> ItemDeviceService;

    public BaseItemService(IInternetItemService<T> itemInternetService, IDeviceItemService<T> itemDeviceService, IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
{
        var itemInternetServiceExceptionMessage = GetExceptionMessage<BaseItemService<T>>(nameof(itemInternetService));
        ItemInternetService = itemInternetService ?? throw new ArgumentNullException(itemInternetServiceExceptionMessage);

        var itemDeviceServiceExceptionMessage = GetExceptionMessage<BaseItemService<T>>(nameof(itemDeviceService));
        ItemDeviceService = itemDeviceService ?? throw new ArgumentNullException(itemDeviceServiceExceptionMessage);
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

