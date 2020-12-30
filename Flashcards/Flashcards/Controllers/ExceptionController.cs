using flashcards.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;

namespace flashcards.Controllers
{
    [Route("api/[controller]")]
    public class ExceptionController : ControllerBase
    {
        [Route("[action]")]
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                string path = exceptionFeature.Path;
                Exception exception = exceptionFeature.Error;

                switch(exception) {
                    case ObjectNotFoundException e:
                        return NotFound();
                    case Exception e: 
                        return BadRequest();
                }
            }

            return Ok();
        }
    }
}
