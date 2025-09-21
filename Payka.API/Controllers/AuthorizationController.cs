using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using IAuthorizationService = Payka.Application.Contracts.Services.IAuthorizationService;

namespace Payka.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController(IAuthorizationService authorizationService) : ControllerBase
{
	[HttpPost("login")]
	[AllowAnonymous]
	public async Task<IActionResult> Login([FromBody] LoginRequest request)
	{
		var token = await authorizationService.LoginAsync(request.UserName, request.Password);
		if (token is null)
		{
			return Unauthorized("Не правильный логин или пароль");
		}

		return Ok(token);
	}

	[HttpGet("validate")]
	[Authorize]
	public IActionResult ValidateToken()
	{
		return Ok(new
		{
			message = "Token is valid"
		});
	}
}

#region Nested Types
public record LoginRequest([Required] string UserName, [Required] string Password);
#endregion