using System.Collections.Generic;
using DinnerInvite.Domain.Common.Menu.ValueObject;
using DinnerInvite.Domain.Common.Models;

namespace DinnerInvite.Domain.Common.Menu.Entities
{
    public sealed class MenuItem :Entity<MenuItemId>
    {
        public string Name {get;}
        public string Description {get;}
    }
}