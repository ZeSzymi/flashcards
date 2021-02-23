using flashcards.Exceptions;
using Flashcards.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;

namespace flashcards.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                string path = exceptionFeature.Path;
                Exception exception = exceptionFeature.Error;

                switch(exception) {
                    case ObjectNotFoundException e:
                        return NotFound(exception.Message);
                    case InvalidModelException e:
                        return Forbid(exception.Message);
                    case Exception e: 
                        return BadRequest(exception.Message);
                }
            }

            return Ok();
        }
    }
}
