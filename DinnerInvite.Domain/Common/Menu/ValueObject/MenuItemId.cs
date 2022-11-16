using System.Collections.Generic;

namespace DinnerInvite.Domain.Common.Menu.ValueObject
{
    public class MenuItemId : Models.ValueObject
    {
        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }
    }
}