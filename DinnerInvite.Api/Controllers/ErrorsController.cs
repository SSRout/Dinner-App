using Microsoft.AspNetCore.Mvc;

namespace DinnerInvite.Api.Controllers
{
    public class ErrorsController:ControllerBase
    {
        [Route("/error")]
        public IActionResult Error(){
            return Problem();
        }
    }
}