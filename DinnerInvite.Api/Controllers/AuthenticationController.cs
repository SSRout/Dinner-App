using System.Threading.Tasks;
using DinnerInvite.Application.Authentication.Commands.Register;
using DinnerInvite.Application.Authentication.Common;
using DinnerInvite.Application.Authentication.Queries.Login;
using DinnerInvite.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DinnerInvite.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController    
    {
        private readonly IMapper _mapper;
        public AuthenticationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult =await Mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors=>Problem(errors)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query=_mapper.Map<LoginQuery>(request);
            var authResult=await Mediator.Send(query);

            if(authResult.IsError && authResult.FirstError== Domain.Common.Errors.Errors.Authentication.InvalidCredential){
                return Problem(statusCode:StatusCodes.Status401Unauthorized,title:authResult.FirstError.Description);
            }

            return authResult.Match(
                 authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors=>Problem(errors)
            );
        }

    }
}