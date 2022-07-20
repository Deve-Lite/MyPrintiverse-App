using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.Services;

/* Work In Progress ale to tez zalezne jak ten session service wyjdzie  */
public abstract class BaseItemServerAsyncService<T> : BaseService, IServerItemService<T> where T : BaseModel, new()
{
    public BaseItemServerAsyncService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
    {
    }

    public Task<bool> AddItemAsync(T item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteItemAsync(string objectId)
    {
        throw new NotImplementedException();
    }

    public Task<RestResponse<T>> GetItemAsync(string objectId)
    {
        throw new NotImplementedException();
    }

    public Task<RestResponse<IEnumerable<T>>> GetItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateItemAsync(T item)
    {
        throw new NotImplementedException();
    }
}