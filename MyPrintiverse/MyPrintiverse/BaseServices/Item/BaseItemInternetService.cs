using MyPrintiverse.Tools.Exceptions;
using System.Net;

namespace MyPrintiverse.BaseServices.Item;

/* Work In Progress ale to tez zalezne jak ten session service wyjdzie  */
public abstract class BaseItemInternetService<T> : BaseService, IInternetItemAsyncService<T> where T : BaseModel, new()
{
    public BaseItemInternetService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
    {
    }

    public Task<bool> AddItemAsync(T item, bool isFirst)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAllAsync(bool isFirst)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteItemAsync(string objectId, bool isFirst)
    {
        throw new NotImplementedException();
    }

    public Task<RestResponse<T>> GetItemAsync(string objectId, bool isFirst)
    {
        throw new NotImplementedException();
    }

    public Task<RestResponse<IEnumerable<T>>> GetItemsAsync(bool isFirst)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateItemAsync(T item, bool isFirst)
    {
        throw new NotImplementedException();
    }
}