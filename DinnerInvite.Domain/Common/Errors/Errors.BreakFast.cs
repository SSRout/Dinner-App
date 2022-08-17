using System;
using ErrorOr;

namespace DinnerInvite.Domain.Common.Errors{
    public static partial class Errors{

        public static class BreakFast {
            public static Error DuplicateBreakFast=>Error.Conflict(code:"BreakFast.Duplicate BreakFast",description:"BreakFast Already Exists.");
        }   
    }
}