using Payka.Application.Contracts.Services;
using System.Security.Cryptography;

namespace Payka.Application.Services;

public class CryptoService : ICryptoService
{
	private const int SaltSize = 16;
	private const int HashSize = 32;
	private const int Iterations = 100_000;
	public string HashText(string text)
	{
		using var rng = RandomNumberGenerator.Create();
		byte[] salt = new byte[SaltSize];
		rng.GetBytes(salt);

		using var pbkdf2 = new Rfc2898DeriveBytes(text, salt, Iterations, HashAlgorithmName.SHA256);
		byte[] hash = pbkdf2.GetBytes(HashSize);

		return $"{Iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
	}
}