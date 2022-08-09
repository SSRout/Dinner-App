using System.Collections.Generic;
using System.Linq;
using DinnerInvite.Application.Common.Interfaces.Persistence;
using DinnerInvite.Domain.Entities;

namespace DinnerInvite.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users= new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x=>x.Email==email);
        }
    }
}