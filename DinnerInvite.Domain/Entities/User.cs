using System;

namespace DinnerInvite.Domain.Entities
{
    public class User
    {
         public Guid id { get; set; }=Guid.NewGuid();
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string Email { get; set; }
         public string Password { get; set; }
    }
}
