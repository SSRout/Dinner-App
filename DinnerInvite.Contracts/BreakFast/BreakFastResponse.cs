using System;
using System.Collections.Generic;

namespace DinnerInvite.Contracts.BreakFast
{
   public record BreakFastResponse
   (
        Guid Id,
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        DateTime LastModifiedDateTime,
        List<string> Savory,
        List<string> Sweet
   );
}