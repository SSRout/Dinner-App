using ErrorOr;

namespace DinnerInvite.Application.Services.Authentications
{
    public interface IAuthenticationService
    {
         ErrorOr<AuthenticationResult> Register(string fristName,string lastName,string email,string password);
         ErrorOr<AuthenticationResult> Login(string email,string password);
    }
}