using DinnerInvite.Application.Authentication.Commands.Register;
using DinnerInvite.Application.Authentication.Common;
using DinnerInvite.Application.Authentication.Queries.Login;
using DinnerInvite.Application.BreakFast.Command;
using DinnerInvite.Application.BreakFast.Common;
using DinnerInvite.Contracts.Authentication;
using DinnerInvite.Contracts.BreakFast;
using Mapster;

namespace DinnerInvite.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest,RegisterCommand>();
            config.NewConfig<LoginRequest,LoginQuery>();
            config.NewConfig<BreakFastRequest,CreateBreakfastCommand>();
            
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                  .Map(dest => dest.Token, src => src.Token)
                  .Map(dest=>dest, src=>src.user);

            config.NewConfig<BreakfastResult,BreakFastResponse>()
                  .Map(dest=>dest,src=>src.breakFast);

        }
    }
}