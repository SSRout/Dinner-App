using System.Collections.Generic;
using DinnerInvite.Domain.Common.Menu.Entities;
using DinnerInvite.Domain.Common.Menu.ValueObject;
using DinnerInvite.Domain.Common.Models;

namespace DinnerInvite.Domain.Common.Menu
{
    public sealed class Menu: AggregateRoot<MenuId>
    {
        private readonly List<MenuSelection> _sections=new List<MenuSelection>();
        public string Name { get; }
        public string Description { get; }
        public float AvgRating { get; }
    }
}