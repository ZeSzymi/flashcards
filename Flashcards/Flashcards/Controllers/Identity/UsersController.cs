using flashcards.CQRS.Commands.Identity;
using flashcards.CQRS.Queries.Identity.LoginUser;
using Flashcards.CQRS.Commands.Users.UpdateUserRoles;
using Flashcards.Models.Dtos.Request;
using Flashcards.Models.Enums;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace flashcards.Controllers.Identity
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = Privileges.admin)]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{role}/{username}")]
        public async Task<IActionResult> UserToRole(string role, string username)
{
            var command = new AddUserToRoleCommand(role, username);
            var result = await _mediator.Send(command);
            if (result.Succeeded)
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
        }

        [HttpGet()]
        public async Task<IActionResult> Users()
        {
            var query = new GetUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpPost("roles")]
        public async Task<IActionResult> UpdateUserRoles([FromBody]UserWithRolesDto userWithRolesDto)
        {
            var command = new UpdateUserRolesCommand(userWithRolesDto);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
 