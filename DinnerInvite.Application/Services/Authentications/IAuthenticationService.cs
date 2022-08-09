namespace DinnerInvite.Application.Services.Authentications
{
    public interface IAuthenticationService
    {
         AuthenticationResult Register(string fristName,string lastName,string email,string password);
         AuthenticationResult Login(string email,string password);
    }
}