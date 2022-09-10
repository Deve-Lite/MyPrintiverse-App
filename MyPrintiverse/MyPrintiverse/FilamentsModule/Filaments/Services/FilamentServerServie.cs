using MyPrintiverse.Core.Services.Server;

namespace MyPrintiverse.FilamentsModule.Filaments.Services;

public class FilamentServerService : BaseServerItemService<Filament>
{
    public FilamentServerService(IConfigService<Config> configService, IMessageService messageService, ISession session) : base(configService, messageService, session)
    {
    }
}

