using Microsoft.AspNetCore.Mvc;
using ExampleApp.Service.DTOs.Users;
using ExampleApp.Service.Interfaces;

namespace ExampleApp.Api.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService authService;
    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserForLoginDto dto)
    {
        var token = await authService.GenerateTokenAsync(dto.Login, dto.Password);

        return Ok(new
        {
            Token = token
        });
    }
}