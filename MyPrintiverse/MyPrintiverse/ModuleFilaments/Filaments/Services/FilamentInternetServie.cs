using System;
namespace MyPrintiverse.FilamentsModule.Filaments.Services
{
    public class FilamentInternetService : BaseItemInternetService<Filament>
    {
        public FilamentInternetService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
        {
        }
    }
}

