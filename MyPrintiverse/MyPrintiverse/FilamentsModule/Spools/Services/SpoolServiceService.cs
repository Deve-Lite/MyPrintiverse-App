namespace MyPrintiverse.FilamentsModule.Spools.Services
{
    public class SpoolServerService : BaseItemServerAsyncService<Spool>
    {
        public SpoolServerService(IConfigService<Config> configService, ILogger logger, IMessageService messageService, ISession session) : base(configService, logger, messageService, session)
        {
        }
    }
}
