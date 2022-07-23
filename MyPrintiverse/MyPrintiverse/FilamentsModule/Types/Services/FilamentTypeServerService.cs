

namespace MyPrintiverse.FilamentsModule.Types.Services;

public class FilamentTypeServerService : BaseItemServerAsyncService<FilamentType>
{
	public FilamentTypeServerService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
	{
	}
}