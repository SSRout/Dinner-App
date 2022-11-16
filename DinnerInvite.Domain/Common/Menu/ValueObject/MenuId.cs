using System;
using System.Collections.Generic;

namespace DinnerInvite.Domain.Common.Menu.ValueObject
{
    public sealed class MenuId : Models.ValueObject
    {

        public Guid Value{get;}

        private MenuId(Guid value)
        {
            Value=value;
        }

        public static MenuId CreateUnique(){
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}