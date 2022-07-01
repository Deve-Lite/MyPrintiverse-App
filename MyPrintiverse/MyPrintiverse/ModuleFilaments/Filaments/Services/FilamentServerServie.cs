using System;
namespace MyPrintiverse.FilamentsModule.Filaments.Services;

public class FilamentServerService : BaseItemServerAsyncService<Filament>
{
    public FilamentServerService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
    {
    }
}

