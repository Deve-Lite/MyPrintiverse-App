namespace MyPrintiverse.FilamentsModule.Spools.Services
{
    public class SpoolInternetService : BaseInternetService<Spool>, IInternetItemKeyAsyncService<Spool>
    {
        public SpoolInternetService()
        {
            BaseConnectionString = "";
        }

        public async Task<RestResponse<Spool>> DeleteItemsByKeyAsync(string key)
        {
            // TODO
            throw new NotImplementedException();
        }

        public async Task<RestResponse<IEnumerable<Spool>>> GetItemsByKeyAsync(string key)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
