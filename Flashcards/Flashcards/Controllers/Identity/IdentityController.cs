using System.Threading.Tasks;
using flashcards.CQRS.Commands.Identity;
using flashcards.CQRS.Queries.Identity.LoginUser;
using flashcards.Models.Dtos;
using Flashcards.Models.Enums;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace flashcards.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = Privileges.admin)]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]UserDto userDto)
        {
            var command = new RegisterUserCommand(userDto);
            var result = await _mediator.Send(command);
            var token = string.Empty;
            if (result.Succeeded)
            {
                var roleCommand = new AddUserToRoleCommand("user", userDto.Username);
                await _mediator.Send(roleCommand);
                var query = new LoginUserQuery(userDto);
                token = await _mediator.Send(query);
            }
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            var query = new LoginUserQuery(userDto);
            var token = await _mediator.Send(query);
            return Ok(new { Token = token});
        }
    }
}
