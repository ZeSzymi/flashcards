using flashcards.Models.Dtos;
using Flashcards.CQRS.Commands.Flashcards.AddFlashcard;
using Flashcards.CQRS.Queries.Flashcards.GetFlashcards;
using Flashcards.Extensions;
using Flashcards.Models.Enums;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Controllers.Cards
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class FlashcardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlashcardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [Authorize(Policy = Privileges.get_cards)]
        public async Task<IActionResult> Get()
        {
            var query = new GetFlashcardsQuery(HttpContext.GetUserId());
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost()]
        [Authorize(Policy = Privileges.add_cards)]
        public async Task<IActionResult> Post([FromBody] FlashcardDto flashcard)
        {
            var command = new AddFlashcardCommand(flashcard, HttpContext.GetUserId());
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{flashcardId:guid}")]
        [Authorize(Policy = Privileges.delete_cards)]
        public async Task<IActionResult> Delete(Guid flashcardId)
        {
            var query = new GetFlashcardsQuery(flashcardId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
