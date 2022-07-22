using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core;

/// <summary>
/// Service base.
/// </summary>
public interface IBaseService
{
	/// <summary>
	/// Message handler e.g alerts, prompts.
	/// </summary>
	public IMessageService MessageService { get; }

	/// <summary>
	/// Config handler.
	/// </summary>
	public IConfigService<Config> ConfigService { get; }

	/// <summary>
	/// Session handler.
	/// </summary>
	public ISession Session { get; }
}