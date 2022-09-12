

using MyPrintiverse.Core.Http;
using MyPrintiverse.Core.Services.Link;
using MyPrintiverse.Core.Services.Server;

namespace MyPrintiverse.FilamentsModule.Types.Services;

public class FilamentTypeServerService : BaseServerItemService<FilamentType>
{
	public FilamentTypeServerService(ILink<FilamentType> links, IConfigService<Config> configService, IMessageService messageService, IHttpService httpService, ISession sessionService) : base(links, configService, messageService, httpService, sessionService)
	{
	}
}