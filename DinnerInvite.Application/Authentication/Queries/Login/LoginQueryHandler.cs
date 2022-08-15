using System.Threading;
using System.Threading.Tasks;
using DinnerInvite.Application.Authentication.Common;
using DinnerInvite.Application.Common.Interfaces.Authentication;
using DinnerInvite.Application.Common.Interfaces.Persistence;
using DinnerInvite.Domain.Common.Errors;
using DinnerInvite.Domain.Entities;
using ErrorOr;
using MediatR;

namespace DinnerInvite.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
         private readonly IjwtTokenGenearator _tokenGen;
        private readonly IUserRepository _userRepo;
        public LoginQueryHandler(IjwtTokenGenearator tokenGen, IUserRepository userRepo)
        {
            _tokenGen = tokenGen;
            _userRepo = userRepo;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
             //1.Validate User Exists
            if(_userRepo.GetUserByEmail(query.Email) is not User user){
                return Errors.Authentication.InvalidCredential;
            }
            //2.Validate Password
            if(user.Password!=query.Password){
                return new [] {Errors.Authentication.InvalidCredential};
            }
            //3.Create JWT Token
            var token=_tokenGen.GenToken(user);
             return new AuthenticationResult(user,token);
        }
    }
}