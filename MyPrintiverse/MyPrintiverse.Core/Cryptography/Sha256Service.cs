using System.Security.Cryptography;

namespace MyPrintiverse.Core.Cryptography;

/// <inheritdoc />
public class Sha256Service : IHashingService
{
	private readonly Encoding _encoding;

	public Sha256Service(Encoding encoding)
	{
		_encoding = encoding;
	}

	/// <inheritdoc />
	public string ComputeHash(string str)
	{
		byte[] result = {};

		using (var sha256 = SHA256.Create())
		{
			var bytes = _encoding.GetBytes(str);

			result = sha256.ComputeHash(bytes);
		}

		return _encoding.GetString(result);
	}
}