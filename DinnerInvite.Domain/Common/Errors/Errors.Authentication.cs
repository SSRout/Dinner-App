using ErrorOr;

namespace DinnerInvite.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication {
             public static Error InvalidCredential=>Error.Validation(code:"Auth.Invalid Credential",description:"Invalid Credentials.");
        }
    }
}