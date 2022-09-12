using MyPrintiverse.Core.Http;
using MyPrintiverse.Core.Services.Link;
using MyPrintiverse.Core.Services.Server;

namespace MyPrintiverse.FilamentsModule.Spools.Services;

public class SpoolServerService : BaseServerItemService<Spool>
{
	public SpoolServerService(ILink<Spool> links, IConfigService<Config> configService, IMessageService messageService, IHttpService httpService, ISession sessionService) : base(links, configService, messageService, httpService, sessionService)
	{
	}
}