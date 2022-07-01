

namespace MyPrintiverse.FilamentsModule.Types.Services
{
    public class FilamentTypeInternetService : BaseItemInternetService<FilamentType>
    {
        public FilamentTypeInternetService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
        {
        }
    }
}
