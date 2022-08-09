using System;

namespace DinnerInvite.Application.Common.Interfaces.Services
{
    public interface IDateTimeProvider{
         DateTime UtcNow{get;}
    }
}