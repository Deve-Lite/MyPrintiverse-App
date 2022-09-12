using MyPrintiverse.Core.Http;
using MyPrintiverse.Core.Services.Link;
using MyPrintiverse.Core.Services.Server;

namespace MyPrintiverse.FilamentsModule.Filaments.Services;

public class FilamentServerService : BaseServerItemService<Filament>
{
    public FilamentServerService(ILink<Filament> links, IConfigService<Config> configService, IMessageService messageService, IHttpService httpService, ISession sessionService) : base(links, configService, messageService, httpService, sessionService)
    {
    }
}

