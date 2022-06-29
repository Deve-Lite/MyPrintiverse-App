namespace MyPrintiverse.BaseServices;

public interface IBaseService
{
	public IMessageService MessageService { get; }
	public ILogger Logger { get; }
	public IConfigService<Config> ConfigService { get;  }

    public ISession Session { get; }
}