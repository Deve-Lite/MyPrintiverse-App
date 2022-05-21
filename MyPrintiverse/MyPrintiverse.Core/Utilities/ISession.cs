namespace MyPrintiverse.Core.Utilities;

public interface ISession
{
	public bool IsLogged { get; }
	public bool HasConnection { get; set; }
}
