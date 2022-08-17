using System;
using System.Collections.Generic;
using DinnerInvite.Application.BreakFast.Common;
using ErrorOr;
using MediatR;

namespace DinnerInvite.Application.BreakFast.Command
{
    public record CreateBreakfastCommand
    (
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        List<string> Savory,
        List<string> Sweet
    ):IRequest<ErrorOr<BreakfastResult>>;
}