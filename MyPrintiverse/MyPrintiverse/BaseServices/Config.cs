#nullable enable
namespace MyPrintiverse.BaseServices;

public class Config : IHttpConfig
{
	public bool IsDeveloperMode { get; set; }
	public string Culture { get; set; }
	public string Version { get; set; }
	public string BaseApiUrl { get; set; }
	public string? ClientSecret { get; set; }
}

public interface IHttpConfig
{
	public string? BaseApiUrl { get; set; }
	public string? ClientSecret { get; set; }
}