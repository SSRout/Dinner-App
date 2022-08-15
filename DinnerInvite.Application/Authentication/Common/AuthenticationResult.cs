using DinnerInvite.Domain.Entities;

namespace DinnerInvite.Application.Authentication.Common;
public record AuthenticationResult(User user,string Token);