using System;
using System.Collections.Generic;

namespace DinnerInvite.Domain.Entities
{
    public class BreakFast
    {
         public Guid id { get; set; }=Guid.NewGuid();
         public string Name { get; set; }
         public string Description { get; set; }
         public DateTime StartDateTime { get; set; }
         public DateTime EndDateTime { get; set; }
         public DateTime LastModifiedDateTime { get; set; }
         public List<string> Savory { get; set; }
         public List<string> Sweet { get; set; }

    }
}