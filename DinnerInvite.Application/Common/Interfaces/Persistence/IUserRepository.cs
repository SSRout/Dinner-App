using DinnerInvite.Domain.Entities;

namespace DinnerInvite.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
         void Add(User user);
         User GetUserByEmail(string email);
    }
}