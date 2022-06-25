using MyPrintiverse.Tools;
using MyPrintiverse.Tools.Exceptions;
using System.Net;

namespace MyPrintiverse.Base.Services
{
    /* Work In Progress ale to tez zalezne jak ten session service wyjdzie  */
    public class BaseItemInternetService<T> //: IInternetItemAsyncService<Item> where Item : class, new()
    {
        // protected static string ConnectionString { get; set; } = "http://localhost:3000/api/";
        // protected string ConnectionString { get; set; } = "http://10.0.2.2:3000/api/";
        protected string BaseConnectionString { get; set; }

        protected RestClient Client;

        protected int Timeout = 10000;

        protected virtual void InitializeClient()
        {
            /* Do wywołania raz w konstruktorze */
            Client = new RestClient(BaseConnectionString);
            Client.AddDefaultHeader("Authorization", Token.AccessToken);
            Client.AddDefaultHeader("Accept", "application/json");
            Client.Timeout = Timeout;
        }

        // Do przemyślenia 
        public async Task<bool> RefreshTokenAsync()
        {
            int Count = 0;

            while (true)
            {
                InitializeClient();
                Client.AddDefaultHeader("Refresh-Token", Token.RefreshToken);
                RestRequest request = new RestRequest("auth/token/renew", Method.POST);
                try
                {
                    RestResponse response = (RestResponse)Client.Execute(request);
                    ValidateResponseStatus(response);

                    var headers = response.Headers.ToList();
                    bool a = Token.GetAccessToken(headers);
                    bool b = Token.GetRefreshToken(headers);

                    return true;
                }
                catch (TimeoutException)
                {
                    if (Count < 6)
                    {
                        Count++;
                        continue;
                    }

                    return false;
                }
                catch (RefreshTokenException)
                {
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        protected void ValidateResponseStatus(ResponseStatus status)
        {
            if (status == ResponseStatus.TimedOut)
                throw new TimeoutException();
        }
        protected void ValidateResponseStatus(HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.Unauthorized)
                throw new TokenException();
        }
        protected void ValidateResponseStatus(RestResponse response)
        {
            if (response.ResponseStatus == ResponseStatus.TimedOut)
                throw new TimeoutException();

            if (response.Content.Contains("issues") && response.Content.Contains("RefreshToken"))
                throw new RefreshTokenException();
        }
        protected void ValidateResponseStatus(ResponseStatus responseStatus, HttpStatusCode statusCode)
        {
            if (responseStatus == ResponseStatus.TimedOut)
                throw new TimeoutException();

            if (statusCode == HttpStatusCode.Unauthorized)
                throw new TokenException();
        }

        public async Task<RestResponse<T>> ExecuteRequest<Param>(RestRequest request, bool isFirst = true)
        {
            RestResponse<T> response = new RestResponse<T>();
            try
            {
                response = (RestResponse<T>)await Client.ExecuteAsync(request);

                return response;
            }
            catch (TokenException)
            {
                if (isFirst)
                {
                    await RefreshTokenAsync();
                    return await ExecuteRequest(request, false);
                }

                return response;
            }
            catch (TimeoutException)
            {
                return response;
            }
            catch
            {
                return response;
            }
        }
        public async Task<RestResponse<T>> ExecuteRequest<Param>(RestRequest request, Param param, bool isFirst = true)
        {
            RestResponse<T> response = new RestResponse<T>();
            try
            {
                response = (RestResponse<T>)await Client.ExecuteAsync(request);

                return response;
            }
            catch (TokenException)
            {
                if (isFirst)
                {
                    await RefreshTokenAsync();
                    return await ExecuteRequest(request, param, false);
                }

                return response;
            }
            catch (TimeoutException)
            {
                return response;
            }
            catch
            {
                return response;
            }
        }

        public async Task<RestResponse<T>> GetItemAsync(string objectId, bool isFirst = true)
        {
            InitializeClient();
            RestRequest request = new RestRequest("Link");
            RestResponse<T> response = new RestResponse<T>();
            try
            {
                response = (RestResponse<T>)await Client.ExecuteAsync(request);

                return response;
            }
            catch (TokenException)
            {
                if (isFirst)
                    return await GetItemAsync(objectId, false);

                return response;
            }
            catch (TimeoutException)
            {
                return response;
            }
            catch
            {
                return response;
            }
        }

    }
}

