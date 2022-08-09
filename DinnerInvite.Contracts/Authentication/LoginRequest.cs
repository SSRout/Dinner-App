using System;

namespace DinnerInvite.Contracts.Authentication
{
    public record LoginRequest
    (
         string Email,
         string  Password
    );
}
