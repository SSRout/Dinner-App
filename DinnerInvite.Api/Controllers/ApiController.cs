using System.Collections.Generic;
using System.Linq;
using DinnerInvite.Api.Common.Http;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerInvite.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private ISender _mediator = null;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        protected IActionResult Problem(List<Error> errors)
        {
            if(errors.Count is 0){
                return Problem();
            }

            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;
   
            return Problem(errors[0]);
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            return Problem(statusCode: statusCode, title: error.Description);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelstateDict = new ModelStateDictionary();

            foreach (var err in errors)
            {
                modelstateDict.AddModelError(err.Code, err.Description);
            }
            return ValidationProblem(modelstateDict);
        }
    }
}