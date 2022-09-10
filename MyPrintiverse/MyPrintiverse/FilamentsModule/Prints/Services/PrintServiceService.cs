

using MyPrintiverse.Core.Services.Server;

namespace MyPrintiverse.FilamentsModule.Prints.Services;

public class PrintServiceService : BaseServerItemService<Print>
{
    public PrintServiceService(IConfigService<Config> configService, IMessageService messageService, ISession session) : base(configService, messageService, session)
    {
    }
}
