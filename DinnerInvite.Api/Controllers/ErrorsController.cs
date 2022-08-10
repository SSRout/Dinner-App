using System;
using DinnerInvite.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DinnerInvite.Api.Controllers
{
    public class ErrorsController:ControllerBase
    {
        [Route("/error")]
        public IActionResult Error(){
            Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var(statusCode, message) = exception switch{
                IServiceException serviceException  => ((int)serviceException.statusCode,serviceException.errorMessage),
                _=>(StatusCodes.Status500InternalServerError,"An Unexpected Error Occured.")
            };

            return Problem(statusCode:statusCode,title:message);
        }
    }
}