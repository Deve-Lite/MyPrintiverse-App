using MyPrintiverse.Core.Http;
using MyPrintiverse.Core.Services.Helpers;
using MyPrintiverse.Core.Utilities;
using System.Collections.Generic;

namespace MyPrintiverse.Core.Services.Server;

// TODO LINKING
// klasa ILink<T> brana z konstruktora na jej podstawie pobierane linki do metod bedzie trzeba wstawianie kilka ILinków  
// do metody get doronbic jakis ISync który wysyła przedmioty zaktualizowane / dodane po jakiejsc godzinie itd. - pomysł rozwiazuje 2 problemy aktualny co po dodaniu 
public abstract class BaseServerItemService<T> : BaseHttpService, IServerItemService<T> where T : BaseModel, new()
{
    protected BaseServerItemService(IConfigService<Config> configService, IMessageService messageService, IHttpService httpService, ISession sessionService) : base(configService, messageService, httpService, sessionService)
    {
    }

    public async Task<IHttpResponse<PostRequestData>> AddItemAsync(T item)
    {
        return await TryRun<PostRequestData>(async () => 
        {
            var url = "";

            var response = await HttpService.Post<PostRequestData, T>(url, item, Session.AccessToken);

            return response;
        });
    }

    public async Task<bool> DeleteAllAsync()
    {
        return await TryRun(async () =>
        {
            var url = "";

            var response = await HttpService.Delete<T>(url, Session.AccessToken);

            return response.IsSuccessful;
        });
    }

    public async Task<bool> DeleteItemAsync(string objectId)
    {
        return await TryRun(async () =>
        {
            var url = "";

            var response = await HttpService.Delete<T>(url, Session.AccessToken);

            return response.IsSuccessful;
        });
    }

    public async Task<IHttpResponse<T>> GetItemAsync(string objectId)
    {
        return await TryRun<T>(async () =>
        {
            var url = "";

            var response = await HttpService.Get<T>(url, Session.AccessToken);

            return response;
        });
    }

    public async Task<IHttpResponse<IEnumerable<T>>> GetItemsAsync()
    {
        return await TryRun<IEnumerable<T>>(async () =>
        {
            var url = "";

            var response = await HttpService.Get<IEnumerable<T>>(url, Session.AccessToken);

            return response;
        });
    }

    public async Task<IHttpResponse<PostRequestData>> UpdateItemAsync(T item)
    {
        return await TryRun<PostRequestData>(async () =>
        {
            var url = "";

            var response = await HttpService.Patch<PostRequestData, T>(url, item, Session.AccessToken);

            return response;
        });
    }
}