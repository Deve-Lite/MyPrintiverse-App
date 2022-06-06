using MyPrintiverse.Tools;
using MyPrintiverse.Tools.Exceptions;
using System.Net;

namespace MyPrintiverse.Base.Services
{
    //TODO Dziedziczenie z BaseService
    public class BaseInternetService<T> : IInternetItemAsyncService<T> where T : class, new()
    {
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
}

