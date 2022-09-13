using MyPrintiverse.Core.Services.Link;

namespace MyPrintiverse.FilamentsModule.Types.Services;

public class FilamentTypeLinks : BaseItemLink<FilamentType>
{
    public FilamentTypeLinks(IConfigService<Config> configService) : base(configService)
    {
        BasePath = $"{configService.Config.Api.FullPath}/api/v1/filaments-types"; // Do zmiany po poprawce kamila
    }
}
