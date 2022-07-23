using System.Security.Cryptography;

namespace MyPrintiverse.Core.Cryptography;

/// <inheritdoc />
public class Sha256Service : IHashingService
{
	/// <inheritdoc />
	public string ComputeHash(string str)
	{
		byte[] result = { };

		using (var sha256 = SHA256.Create())
		{
			var bytes = str.Select(e => (byte)e).ToArray();

			result = sha256.ComputeHash(bytes);
		}

		return new string(result.Select(b => (char)b).ToArray());
	}
}