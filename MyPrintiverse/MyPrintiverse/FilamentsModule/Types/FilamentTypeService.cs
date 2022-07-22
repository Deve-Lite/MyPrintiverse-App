
using MyPrintiverse.FilamentsModule.Types.Services;

namespace MyPrintiverse.FilamentsModule.Types;

public class FilamentTypeService : BaseItemAsyncService<FilamentType>
{
	public FilamentTypeService(FilamentTypeDeviceService filamentTypeDeviceService, FilamentTypeServerService filamentTypeServerService, IConfigService<Config> configService, IMessageService messageService, ISession session) : base(filamentTypeServerService, filamentTypeDeviceService, configService, messageService, session)
	{
	}
}