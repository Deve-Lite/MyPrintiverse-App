using System.Net;

namespace MyPrintiverse.Base.Services
{
    /// <summary>
    /// Base Service for managing Items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseInternetAsyncService<T> : IInternetItemAsyncService<T> where T : BaseModel
    {

        // Work in Progress
        

        protected string ModuleUrl;

        public virtual async Task<bool> AddItemAsync(T item)
        {
            string url = Path.Combine(ModuleUrl, "");

            RestResponse response = new RestResponse();

            if (ReturnStatus(response.StatusCode))
                return true;

            await DisplayMessage(response.Content);
            
            return false;
        }

        public virtual async Task<bool> DeleteAllAsync()
        {
            string url = Path.Combine(ModuleUrl, "");

            RestResponse response = new RestResponse();

            if (ReturnStatus(response.StatusCode))
                return true;

            await DisplayMessage(response.Content);

            return false;
        }

        public virtual async Task<bool> DeleteItemAsync(string objectId)
        {
            string url = Path.Combine(ModuleUrl, "", objectId);

            RestResponse response = new RestResponse();

            if (ReturnStatus(response.StatusCode))
                return true;

            await DisplayMessage(response.Content);

            return false;
        }

        public virtual async Task<(bool, T)> GetItemAsync(string objectId)
        {
            string url = Path.Combine(ModuleUrl, "", objectId);

            RestResponse response = new RestResponse();

            if (ReturnStatus(response.StatusCode))
            {
                // Parse response
                return (true, null);
            }

            await DisplayMessage(response.Content);

            return (false, null);
        }

        public virtual async Task<(bool, IEnumerable<T>)> GetItemsAsync()
        {
            string url = Path.Combine(ModuleUrl, "");

            RestResponse response = new RestResponse();

            if (ReturnStatus(response.StatusCode))
            {

                //Parse Response 

                return (true, null);
            }

            await DisplayMessage(response.Content);

            return (false, null);
        }

        public virtual async Task<bool> UpdateItemAsync(T item)
        {
            string url = Path.Combine(ModuleUrl, "", item.Id);

            RestResponse response = new RestResponse();

            if (ReturnStatus(response.StatusCode))
                return true;

            await DisplayMessage(response.Content);

            return false;
        }


        protected virtual bool ReturnStatus(HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.Continue || statusCode == HttpStatusCode.OK ||
                statusCode == HttpStatusCode.Created || statusCode == HttpStatusCode.NoContent)
                return true;


            return false;
        }

        protected virtual async Task DisplayMessage(string message)
        {
            //TODO
        }
    }
}

