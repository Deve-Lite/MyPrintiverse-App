

namespace MyPrintiverse.FilamentsModule.Prints.Services;

public class PrintServiceService : BaseItemServerAsyncService<Print>
{
    public PrintServiceService(IConfigService<Config> configService, IMessageService messageService, ISession session) : base(configService, messageService, session)
    {
    }
}
