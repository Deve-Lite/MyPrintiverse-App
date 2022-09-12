using MyPrintiverse.Core.Http;
using MyPrintiverse.Core.Services.Helpers;
using MyPrintiverse.Core.Services.Link;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.Services.Server;

public abstract class BaseServerItemService<T> : BaseHttpService, IServerItemService<T> where T : BaseModel, new()
{
    protected ILink<T> Links;

    protected BaseServerItemService(ILink<T> links,IConfigService<Config> configService, IMessageService messageService, IHttpService httpService, ISession sessionService) : base(configService, messageService, httpService, sessionService)
    {
        Links = links;
    }

    public async Task<IHttpResponse<PostRequestData>> AddItemAsync(T item)
    {
        return await TryRun<PostRequestData>(async () => 
        {
            var url = Links.AddItem();

            var response = await HttpService.Post<PostRequestData, T>(url, item, Session.AccessToken);

            return response;
        });
    }

    public async Task<bool> DeleteAllAsync()
    {
        return await TryRun(async () =>
        {
            var url = Links.DeleteItems();

            var response = await HttpService.Delete<T>(url, Session.AccessToken);

            return response.IsSuccessful;
        });
    }

    public async Task<bool> DeleteItemAsync(string objectId)
    {
        return await TryRun(async () =>
        {
            var url = Links.DeleteItem(objectId);

            var response = await HttpService.Delete<T>(url, Session.AccessToken);

            return response.IsSuccessful;
        });
    }

    public async Task<IHttpResponse<T>> GetItemAsync(string objectId)
    {
        return await TryRun<T>(async () =>
        {
            var url = Links.GetItem(objectId);

            var response = await HttpService.Get<T>(url, Session.AccessToken);

            return response;
        });
    }

    public async Task<IHttpResponse<IEnumerable<T>>> GetItemsAsync()
    {
        return await TryRun<IEnumerable<T>>(async () =>
        {
            var url = Links.GetItems();

            var response = await HttpService.Get<IEnumerable<T>>(url, Session.AccessToken);

            return response;
        });
    }

    public async Task<IHttpResponse<PostRequestData>> UpdateItemAsync(T item)
    {
        return await TryRun<PostRequestData>(async () =>
        {
            var url = Links.UpdateItem(item.Id);

            var response = await HttpService.Patch<PostRequestData, T>(url, item, Session.AccessToken);

            return response;
        });
    }
}