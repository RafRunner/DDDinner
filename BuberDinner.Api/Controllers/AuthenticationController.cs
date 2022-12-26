using BuberDinner.Contracts.Authentication;
using BuberDinner.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("Auth")]
public class AuthenticationController : ControllerBase
{

    private IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        var response = MapToResponse(result);
        return Ok(response);
    }

    [HttpPost("Login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authService.Login(request.Email, request.Password);
        var response = MapToResponse(result);
        return Ok(response);
    }

    private AuthenticationResponse MapToResponse(AuthenticationResult result) {
        return new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token
        );
    }
}
