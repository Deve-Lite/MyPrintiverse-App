using MyPrintiverse.Core.Services.Server;

namespace MyPrintiverse.FilamentsModule.Spools.Services;

public class SpoolServerService : BaseServerItemService<Spool>
{
	public SpoolServerService(IConfigService<Config> configService, IMessageService messageService, ISession session) : base(configService, messageService, session)
	{
	}
}