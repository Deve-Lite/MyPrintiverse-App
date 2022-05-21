using MyPrintiverse.Tools.Http;

namespace MyPrintiverse;

public interface IBaseHttpService : IBaseService
{
	public IHttpService HttpService { get; set; }
}