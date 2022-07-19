

namespace MyPrintiverse.FilamentsModule.Prints.Services;

public class PrintServiceService : BaseItemServerAsyncService<Print>
{
    public PrintServiceService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
    {
    }
}
