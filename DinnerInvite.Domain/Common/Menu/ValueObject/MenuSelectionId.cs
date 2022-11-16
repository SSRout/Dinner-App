using System;
using System.Collections.Generic;

namespace DinnerInvite.Domain.Common.Menu.ValueObject
{
    public sealed class MenuSelectionId : Models.ValueObject
    {

        public Guid Value{get;}

        private MenuSelectionId(Guid value)
        {
            Value=value;
        }

        public static MenuSelectionId CreateUnique(){
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}