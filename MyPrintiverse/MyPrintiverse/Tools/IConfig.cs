#nullable enable
namespace MyPrintiverse.Tools;

public interface IConfig
{
    public string this[string propertyName] { get; set; }
}