#nullable enable

namespace MyPrintiverse.Core.Utilities;

/// <summary>
/// Session manager.
/// </summary>
public class Session : ISession
{
	public IToken? AccessToken { get; }
	public IToken? RefreshToken { get; }



	public bool IsLogged => throw new NotImplementedException();

	public bool HasConnection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public void AuthorizeUser()
	{
		
	}

	Token ISession.RefreshToken()
	{
		throw new NotImplementedException();
	}
}