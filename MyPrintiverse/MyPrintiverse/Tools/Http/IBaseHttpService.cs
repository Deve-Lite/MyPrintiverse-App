namespace MyPrintiverse.Tools.Http;

public interface IBaseHttpService : IBaseService
{
    public IHttpService HttpService { get; set; }
}