using System.Collections.Generic;
using DinnerInvite.Api.Common.Http;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerInvite.Api.Controllers
{
     [ApiController]
    public class ApiController:ControllerBase
    {
        private ISender _mediator=null;

        protected ISender Mediator=>_mediator??=HttpContext.RequestServices.GetRequiredService<ISender>();
        protected IActionResult Problem(List<Error> errors){
            HttpContext.Items[HttpContextItemKeys.Errors]=errors;
            var firstError=errors[0];
            var statusCode=firstError.Type switch{
                ErrorType.Conflict=>StatusCodes.Status409Conflict,
                ErrorType.Validation=>StatusCodes.Status400BadRequest,
                ErrorType.NotFound=>StatusCodes.Status404NotFound,
                _=>StatusCodes.Status500InternalServerError
            };
            return Problem(statusCode:statusCode,title:firstError.Description);
        }
    }
}