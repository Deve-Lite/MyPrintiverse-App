
using System.Security.Cryptography;

namespace Develite.Utilities.Cryptography;

/// <inheritdoc />
public class AesService : ICipherService
{
	private readonly byte[] _key;
	private readonly byte[] _IV;

	public AesService()
	{

	}

	/// <inheritdoc />
	public string Decrypt(string encryptedString)
	{
		string plainText;

		using (var aes = Aes.Create())
		{
			aes.Key = _key;
			aes.IV = _IV;

			var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

			using (var msDecrypt = new MemoryStream(encryptedString.Select(e => (byte)e).ToArray()))
			{
				using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
				{
					using (var srDecrypt = new StreamReader(csDecrypt))
					{
						plainText = srDecrypt.ReadToEnd();
					}
				}
			}

		}

		return plainText;
	}

	/// <inheritdoc />
	public string Encrypt(string str)
	{
		byte[] encrypted;

		using (var aes = Aes.Create())
		{
			aes.Key = _key;
			aes.IV = _IV;

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