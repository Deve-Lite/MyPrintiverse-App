

using MyPrintiverse.Core.Services.Server;

namespace MyPrintiverse.FilamentsModule.Types.Services;

public class FilamentTypeServerService : BaseServerItemService<FilamentType>
{
	public FilamentTypeServerService(IConfigService<Config> configService, IMessageService messageService, ISession session) : base(configService, messageService, session)
	{
	}
}