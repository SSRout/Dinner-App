using System.Threading.Tasks;
using DinnerInvite.Application.BreakFast.Command;
using DinnerInvite.Application.BreakFast.Common;
using DinnerInvite.Contracts.BreakFast;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace DinnerInvite.Api.Controllers
{
    [Route("[controller]")]
    public class BreakFastsController:ApiController
    {
         private readonly IMapper _mapper;

        public BreakFastsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBreakFast(BreakFastRequest request){
             var command = _mapper.Map<CreateBreakfastCommand>(request);
            ErrorOr<BreakfastResult> bkFastResult =await Mediator.Send(command);

            return bkFastResult.Match(
                bkFastResult => Ok(_mapper.Map<BreakFastResponse>(bkFastResult)),
                errors=>Problem(errors)
            );
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakFast(){
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakFast(){
            return Ok();
        }

          [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakFast(){
            return NoContent();
        }
        
    }
}