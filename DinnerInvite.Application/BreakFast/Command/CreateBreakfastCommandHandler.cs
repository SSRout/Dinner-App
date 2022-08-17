using System.Threading;
using System.Threading.Tasks;
using DinnerInvite.Application.BreakFast.Common;
using DinnerInvite.Application.Common.Interfaces.Persistence;
using bkFast= DinnerInvite.Domain.Entities;
using ErrorOr;
using MediatR;

namespace DinnerInvite.Application.BreakFast.Command
{
    public class CreateBreakfastCommandHandler : IRequestHandler<CreateBreakfastCommand, ErrorOr<BreakfastResult>>
    {
        private readonly IBreakfastRepository _breakFastRepo;

        public CreateBreakfastCommandHandler(IBreakfastRepository breakFastRepo)
        {
            _breakFastRepo = breakFastRepo;
        }

        public async Task<ErrorOr<BreakfastResult>> Handle(CreateBreakfastCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //1.Check Breakfast exist or not
            if(_breakFastRepo.GetBreakFast(command.Name) is not null){
                    return Domain.Common.Errors.Errors.BreakFast.DuplicateBreakFast;
            }

            //2.Create Breakfast and save to DB
            var breakFast=new bkFast.BreakFast{
                Name=command.Name,
                Description=command.Description,
                StartDateTime=command.StartDateTime,
                EndDateTime=command.EndDateTime,
                Savory=command.Savory,
                Sweet=command.Sweet
            };
            _breakFastRepo.CreateBreakFast(breakFast);
            return new BreakfastResult(breakFast);
        }
    }
}