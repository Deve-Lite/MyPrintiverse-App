namespace MyPrintiverse.FilamentsModule.Filaments.Services;

public class FilamentServerService : BaseItemServerAsyncService<Filament>
{
    public FilamentServerService(IConfigService<Config> configService, IMessageService messageService, ISession session) : base(configService, messageService, session)
    {
    }
}

