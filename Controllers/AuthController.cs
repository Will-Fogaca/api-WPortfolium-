using Microsoft.AspNetCore.Mvc;
using WillPortfolio_Api.Domain.Dtos;
using WillPortfolio_Api.Services.Interfaces;

namespace WillPortfolio_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult<AuthResponseDto> Login([FromBody] LoginRequestDto loginDto)
    {
        try
        {
            var result = _authService.Authenticate(loginDto);
            return Ok(result);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    } 
}