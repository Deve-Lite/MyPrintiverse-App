using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core;

public interface IBaseService
{
	/// <summary>
	/// 
	/// </summary>
	public IMessageService MessageService { get; }
	
	/// <summary>
	/// 
	/// </summary>
	public ILogger Logger { get; }
	
	/// <summary>
	/// 
	/// </summary>
	public IConfigService<Config> ConfigService { get; }

	/// <summary>
	/// 
	/// </summary>
	public ISession Session { get; }
}