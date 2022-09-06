namespace MyPrintiverse.FilamentsModule.Spools.Services;

public class SpoolServerService : BaseItemServerAsyncService<Spool>
{
	public SpoolServerService(IConfigService<Config> configService, IMessageService messageService, ISession session) : base(configService, messageService, session)
	{
	}
}