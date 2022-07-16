#nullable enable
namespace MyPrintiverse.Core.Utilities;


public class Config : IHttpConfig
{
	public bool IsDeveloperMode { get; set; }
	public string Culture { get; set; }
	public string Version { get; set; }
	public string BaseApiUrl { get; set; }
	public string ClientSecret { get; set; }
}

public interface IHttpConfig
{
	public string? BaseApiUrl { get; set; }
	public string? ClientSecret { get; set; }
}