using System;
using ErrorOr;

namespace DinnerInvite.Domain.Common.Errors{
    public static partial class Errors{

        public static class User {
            public static Error DuplicateEmail=>Error.Conflict(code:"User.Duplicate Email",description:"Email Already in Use.");
        }   
    }
}