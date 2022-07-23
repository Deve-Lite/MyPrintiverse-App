namespace MyPrintiverse.Core.Http;

public interface IBaseHttpService : IBaseService
{
    public IHttpService HttpService { get; set; }
}