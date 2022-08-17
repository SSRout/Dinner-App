using System.Collections.Generic;
using System.Linq;
using DinnerInvite.Application.Common.Interfaces.Persistence;
using DinnerInvite.Domain.Entities;

namespace DinnerInvite.Infrastructure.Persistence
{
    public class BreakFastRepository : IBreakfastRepository
    {
        private static readonly List<BreakFast> _breakFast =new();
        public void CreateBreakFast(BreakFast breakFast)
        {
           _breakFast.Add(breakFast);
        }

        public int DeleteBreakFast(string id)
        {
           var res= _breakFast.SingleOrDefault(x=>x.id==new System.Guid(id));
           if(res is not null)
            {
                _breakFast.Remove(res);
            }
            return 0;
        }

        public BreakFast GetBreakFast(string Name)
        {
            return _breakFast.SingleOrDefault(x=>x.Name==Name);
        }

        public BreakFast UpdateBreakFast(string id, BreakFast breakFast)
        {
            throw new System.NotImplementedException();
        }
    }
}