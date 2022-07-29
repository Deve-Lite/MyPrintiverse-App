using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.Http;

public class BaseHttpService : BaseService, IBaseHttpService
{
	public IHttpService HttpService { get; set; }

	public BaseHttpService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, IHttpService httpService, ISession sessionService) : base(configService, logger, messageService, sessionService)
	{
		HttpService = httpService;
	}
}