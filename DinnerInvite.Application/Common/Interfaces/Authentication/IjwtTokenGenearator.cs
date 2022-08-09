using System;
using DinnerInvite.Domain.Entities;

namespace DinnerInvite.Application.Common.Interfaces.Authentication
{
    public interface IjwtTokenGenearator
    {
         string GenToken(User user);
    }
}