using MyPrintiverse.Core.Services.Helpers;
using MyPrintiverse.Core.Services.Link;

namespace MyPrintiverse.FilamentsModule.Filaments.Services;

public class FilamentLinks : BaseItemLink<Filament>
{
	public FilamentLinks(IConfigService<Config> configService) : base(configService)
	{
	}
}
