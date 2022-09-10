using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.Services.Server;

/* Work In Progress ale to tez zalezne jak ten session service wyjdzie  */
public abstract class BaseServerItemService<T> : BaseService, IServerItemService<T> where T : BaseModel, new()
{
    public BaseServerItemService(IConfigService<Config> configService, IMessageService messageService, ISession session) : base(configService, messageService, session)
    {
    }

    public Task<(bool, T)> AddItemAsync(T item)
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

    public Task<(bool, T)> GetItemAsync(string objectId)
    {
        throw new NotImplementedException();
    }

    public Task<(bool, IEnumerable<T>)> GetItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<(bool, T)> UpdateItemAsync(T item)
    {
        throw new NotImplementedException();
    }
}