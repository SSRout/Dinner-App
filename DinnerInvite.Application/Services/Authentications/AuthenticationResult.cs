using System;
using DinnerInvite.Domain.Entities;

namespace DinnerInvite.Application.Services.Authentications
{
    public record AuthenticationResult
    (
        User user,
        string token
    );
}