using DinnerInvite.Application.Services.Authentications;
using DinnerInvite.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DinnerInvite.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase    
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult=_authService.Register(request.FirstName,request.LastName,request.Email,request.Password);

            var authResponse=new AuthenticationResponse(
                authResult.user.id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.token
            );

            return Ok(authResponse);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult=_authService.Login(request.Email,request.Password);
            
            var authResponse=new AuthenticationResponse(
                authResult.user.id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.token
            );
            return Ok(authResponse);
        }

    }
}