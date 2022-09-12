

using MyPrintiverse.Core.Services.Link;

namespace MyPrintiverse.FilamentsModule.Spools.Services;

public class SpoolLinks : BaseItemLink<Spool>
{
    public SpoolLinks(IConfigService<Config> configService) : base(configService)
    {
    }
}
