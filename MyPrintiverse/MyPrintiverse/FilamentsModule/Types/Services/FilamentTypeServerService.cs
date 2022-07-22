

namespace MyPrintiverse.FilamentsModule.Types.Services;

public class FilamentTypeServerService : BaseItemServerAsyncService<FilamentType>
{
	public FilamentTypeServerService(IConfigService<Config> configService, IMessageService messageService, ISession session) : base(configService, messageService, session)
	{
	}
}