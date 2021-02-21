using Flashcards.CQRS.Queries.Translations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Controllers
{
    [Route("api/[controller]")]
    public class TranslationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TranslationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{language}")]
        public async Task<IActionResult> Get(string language)
        {
            var query = new GetTranslationsQuery(language);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
