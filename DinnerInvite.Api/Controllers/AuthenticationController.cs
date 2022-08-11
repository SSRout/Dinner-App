using DinnerInvite.Application.Services.Authentications;
using DinnerInvite.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DinnerInvite.Api.Controllers
{   
    [Route("auth")]
    public class AuthenticationController : ApiController    
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors=>Problem(errors)
            );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult=_authService.Login(request.Email,request.Password);

            if(authResult.IsError && authResult.FirstError== Domain.Common.Errors.Errors.Authentication.InvalidCredential){
                return Problem(statusCode:StatusCodes.Status401Unauthorized,title:authResult.FirstError.Description);
            }

            return authResult.Match(
                 authResult => Ok(MapAuthResult(authResult)),
                errors=>Problem(errors)
            );
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                            authResult.user.id,
                            authResult.user.FirstName,
                            authResult.user.LastName,
                            authResult.user.Email,
                            authResult.token
                        );
        }

    }
}