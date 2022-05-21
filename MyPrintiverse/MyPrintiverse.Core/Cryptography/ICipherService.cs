namespace MyPrintiverse.Core.Cryptography;

/// <summary>
/// Algorithm (Cipher) with encrypt and decrypt functions.
/// </summary>
public interface ICipherService
{
	/// <summary>
	/// Decrypt encrypted <paramref name="str"/>
	/// </summary>
	/// <param name="str"><see langword="string"/> to decrypt</param>
	/// <returns>decrypted <paramref name="str"/></returns>
	public string Decrypt(string str);

	/// <summary>
	/// Encrypt provided <paramref name="str"/>
	/// </summary>
	/// <param name="str"><see langword="string"/> to encrypt</param>
	/// <returns>encrypted <paramref name="str"/></returns>
	public string Encrypt(string str);
}