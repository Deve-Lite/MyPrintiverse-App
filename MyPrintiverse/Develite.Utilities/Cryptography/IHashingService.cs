namespace Develite.Utilities.Cryptography;

/// <summary>
/// Algorithm with hashing functions.
/// </summary>
public interface IHashingService
{
	/// <summary>
	/// Compute hash from provided <paramref name="str"/>
	/// </summary>
	/// <param name="str"></param>
	/// <returns></returns>
	public string ComputeHash(string str);
}