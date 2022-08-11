using System;
using DinnerInvite.Application.Common.Errors;
using DinnerInvite.Application.Common.Interfaces.Authentication;
using DinnerInvite.Application.Common.Interfaces.Persistence;
using DinnerInvite.Application.Services.Authentications;
using DinnerInvite.Domain.Common.Errors;
using DinnerInvite.Domain.Entities;
using ErrorOr;

namespace DinnerInvite.Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IjwtTokenGenearator _tokenGen;
        private readonly IUserRepository _userRepo;
        public AuthenticationService(IjwtTokenGenearator tokenGen, IUserRepository userRepo)
        {
            _tokenGen = tokenGen;
            _userRepo = userRepo;
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            //1.Check user Exists
            if(_userRepo.GetUserByEmail(email) is not null){
                //throw new DuplicateEmailException();
                return Errors.User.DuplicateEmail;
            }
            //2.Create User and save to Db
            var user=new User
            {
                FirstName=firstName,
                LastName=lastName,
                Email=email,
                Password=password
            };
            _userRepo.Add(user);
            //3.Gen Token
            var token = _tokenGen.GenToken(user);
            
            return new AuthenticationResult(user,token);
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            //1.Validate User Exists
            if(_userRepo.GetUserByEmail(email) is not User user){
                return Errors.Authentication.InvalidCredential;
            }
            //2.Validate Password
            if(user.Password!=password){
                return new [] {Errors.Authentication.InvalidCredential};
            }
            //3.Create JWT Token
            var token=_tokenGen.GenToken(user);
             return new AuthenticationResult(user,token);
        }
    }
}
