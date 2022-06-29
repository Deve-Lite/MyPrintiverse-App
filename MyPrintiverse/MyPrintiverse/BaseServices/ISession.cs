namespace MyPrintiverse.BaseServices;

public interface ISession
{
    public bool IsLogged { get; }
    public bool HasConnection { get; set; }
}
