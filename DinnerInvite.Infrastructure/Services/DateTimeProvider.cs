using System;
using DinnerInvite.Application.Common.Interfaces.Services;

namespace DinnerInvite.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}