
using MyPrintiverse.Core.Services.Device;
using MyPrintiverse.Core.Services.Server;

namespace MyPrintiverse.FilamentsModule.Types;

public class FilamentTypeService : BaseItemService<FilamentType>
{
	public FilamentTypeService(IDeviceItemService<FilamentType> filamentTypeDeviceService, IServerItemService<FilamentType> filamentTypeServerService, IConfigService<Config> configService, IMessageService messageService, ISession session) : base(filamentTypeServerService, filamentTypeDeviceService, configService, messageService, session)
	{
	}
}