using System;
using System.Collections.Generic;

namespace DinnerInvite.Contracts.BreakFast
{
   public record BreakFastRequest
   (
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        List<string> Savory,
        List<string> Sweet
   );
}