using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Payka.Application.Contracts.Services;
using Payka.Dal;
using Payka.ReadModel.Models.Users;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Payka.Application.Services;

public class AuthorizationService(IConfiguration configuration, WriteDbContext dbContext) : IAuthorizationService
{
	private static readonly JsonWebTokenHandler TokenHandler = new();

	public async Task<string?> LoginAsync(string userName, string password)
	{
		var potentialUser = await dbContext.Set<UserCredentials>()
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.UserName == userName);

		if (potentialUser is null)
		{
			return null;
		}

		if (!VerifyPassword(password, potentialUser.Password))
		{
			return null;
		}

		return GenerateAuthorizationToken(potentialUser.UserId);
	}

	private string GenerateAuthorizationToken(Guid userId)
	{
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
		var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity([
				new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
			]),
			Expires = DateTime.UtcNow.AddHours(12),
			Issuer = configuration["Jwt:Issuer"],
			Audience = configuration["Jwt:Audience"],
			SigningCredentials = credentials
		};

		return TokenHandler.CreateToken(tokenDescriptor);
	}

	private bool VerifyPassword(string password, string hashedPassword)
	{
		var parts = hashedPassword.Split(':');
		if (parts.Length != 3)
		{
			return false;
		}

		if (!int.TryParse(parts[0], out int iterations))
		{
			return false;
		}

		try
		{
			byte[] salt = Convert.FromBase64String(parts[1]);
			byte[] hash = Convert.FromBase64String(parts[2]);

			using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
			byte[] computedHash = pbkdf2.GetBytes(hash.Length);

			return CryptographicOperations.FixedTimeEquals(hash, computedHash);
		}
		catch (FormatException)
		{
			return false;
		}
	}
}