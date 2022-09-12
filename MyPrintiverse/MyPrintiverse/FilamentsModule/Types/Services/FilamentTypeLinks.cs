using MyPrintiverse.Core.Services.Link;

namespace MyPrintiverse.FilamentsModule.Types.Services;

public class FilamentTypeLinks : BaseItemLink<FilamentType>
{
    public FilamentTypeLinks(IConfigService<Config> configService) : base(configService)
    {
    }
}
