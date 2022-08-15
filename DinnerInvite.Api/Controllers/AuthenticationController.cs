using System.Threading.Tasks;
using DinnerInvite.Application.Authentication.Commands.Register;
using DinnerInvite.Application.Authentication.Common;
using DinnerInvite.Application.Authentication.Queries.Login;
using DinnerInvite.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DinnerInvite.Api.Controllers
{   
    [Route("auth")]
    public class AuthenticationController : ApiController    
    {
        private readonly ISender _mediator;
        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult =await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors=>Problem(errors)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query=new LoginQuery(request.Email,request.Password);
            var authResult=await _mediator.Send(query);

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
                            authResult.Token
                        );
        }

    }
}