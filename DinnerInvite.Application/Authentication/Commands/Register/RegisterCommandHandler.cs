using System.Threading;
using System.Threading.Tasks;
using DinnerInvite.Application.Authentication.Common;
using DinnerInvite.Application.Common.Interfaces.Authentication;
using DinnerInvite.Application.Common.Interfaces.Persistence;
using DinnerInvite.Domain.Common.Errors;
using DinnerInvite.Domain.Entities;
using ErrorOr;
using MediatR;

namespace DinnerInvite.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IjwtTokenGenearator _tokenGen;
        private readonly IUserRepository _userRepo;

        public RegisterCommandHandler(IUserRepository userRepo, IjwtTokenGenearator tokenGen)
        {
            _userRepo = userRepo;
            _tokenGen = tokenGen;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //1.Check user Exists
            if(_userRepo.GetUserByEmail(command.Email) is not null){
                //throw new DuplicateEmailException();
                return Errors.User.DuplicateEmail;
            }
            //2.Create User and save to Db
            var user=new User
            {
                FirstName=command.FirstName,
                LastName=command.LastName,
                Email=command.Email,
                Password=command.Password
            };
            _userRepo.Add(user);
            //3.Gen Token
            var token = _tokenGen.GenToken(user);
            
            return  new AuthenticationResult(user,token);
        }
    }
}