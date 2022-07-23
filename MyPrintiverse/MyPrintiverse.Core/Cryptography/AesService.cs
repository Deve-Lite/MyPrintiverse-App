
using System.Security.Cryptography;

namespace MyPrintiverse.Core.Cryptography;

/// <inheritdoc />
/// <inheritdoc />
public sealed class AesService : ICipherService
{
	private const string _key = @"fUjWnZr4u7x!A%D*G-KaPdSgVkYp2s5v";
	private const string _IV = @"5u8x/A?D(G+KaPdS";

	/// <inheritdoc />
	public string Decrypt(string encryptedString)
	{
		string plaintext;

		using (var aes = Aes.Create())
		{
			aes.Key = _key.Select(e => (byte)e).ToArray();
			aes.IV = _IV.Select(e => (byte)e).ToArray();

			var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

			using (var msDecrypt = new MemoryStream(encryptedString.Select(e => (byte)e).ToArray()))
			{
				using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
				{
					using (var srDecrypt = new StreamReader(csDecrypt))
					{

						plaintext = srDecrypt.ReadToEnd();
					}
				}
			}

		}

		return plaintext;
	}

	/// <inheritdoc />
	public string Encrypt(string str)
	{
		byte[] encrypted;

		using (var aes = Aes.Create())
		{
			aes.Key = _key.Select(e => (byte)e).ToArray();
			aes.IV = _IV.Select(e => (byte)e).ToArray();

			var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

			using (var msEncrypt = new MemoryStream())
			{
				using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
				{
					using (var swEncrypt = new StreamWriter(csEncrypt))
					{
						swEncrypt.Write(str);
					}
					encrypted = msEncrypt.ToArray();
				}
			}
		}

		return new string(encrypted.Select(b => (char)b).ToArray());
	}
}