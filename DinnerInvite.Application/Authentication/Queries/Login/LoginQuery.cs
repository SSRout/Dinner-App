using DinnerInvite.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DinnerInvite.Application.Authentication.Queries.Login
{
    public record LoginQuery
    (
        string Email,
        string Password
    ):IRequest<ErrorOr<AuthenticationResult>>;
}