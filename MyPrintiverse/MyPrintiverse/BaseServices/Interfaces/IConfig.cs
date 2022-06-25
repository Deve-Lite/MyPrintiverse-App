#nullable enable
using MyPrintiverse;

namespace MyPrintiverse.BaseServices.Interfaces;

public interface IConfig
{
    public string this[string propertyName] { get; set; }
}