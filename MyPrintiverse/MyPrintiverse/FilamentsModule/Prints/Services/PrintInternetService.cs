﻿

namespace MyPrintiverse.FilamentsModule.Prints.Services;

public class PrintInternetService : BaseItemServerAsyncService<Print>
{
    public PrintInternetService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
    {
    }
}
