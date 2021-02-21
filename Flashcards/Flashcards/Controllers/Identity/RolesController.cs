using System.Threading.Tasks;
using flashcards.Models.Dtos;
using flashcards.Models.Identity;
using flashcards.Repositories.Interfaces;
using Flashcards.CQRS.Commands.Identity.Roles.AddClaimToRole;
using Flashcards.CQRS.Commands.Identity.Roles.AddRole;
using Flashcards.CQRS.Queries.Identity.Roles.GetRole;
using Flashcards.CQRS.Queries.Identity.Roles.GetRoles;
using Flashcards.Models.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace flashcards.Controllers.Identity
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IMediator _mediator;

        public RolesController(IIdentityRepository identityRepository, IMediator mediator)
        {
            _identityRepository = identityRepository;
            _mediator = mediator;
        }

        [HttpPost("claims")]
        public async Task<IActionResult> AddClaim([FromBody]string claim)
        {
            await _identityRepository.AddClaim(claim);
            return Ok();
        }

        [HttpGet("claims")]
        public async Task<IActionResult> Claims()
        {
            var claims = await _identityRepository.GetClaims();
            return Ok(claims);
        }

        [HttpPost("roles/claims")]
        public async Task<IActionResult> AddClaimToRole([FromBody] RoleIdWithClaimsDto roleIdWithClaims)
        {
            await _identityRepository.AddClaimsToRole(roleIdWithClaims.RoleId, roleIdWithClaims.ClaimIds);
            return Ok();
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var query = new GetRolesQuery();
            var roles = await _mediator.Send(query);
            return Ok(roles);
        }

        [HttpPost("role-with-claims")]
        public async Task<IActionResult> AddRoleWithClaims([FromBody] RoleWithClaimsDto roleWithClaims)
        {
            var command = new AddRoleCommand(roleWithClaims.Name);
            await _mediator.Send(command);
            var roleQuery = new GetRoleQuery(roleWithClaims.Name);
            var role = await _mediator.Send(roleQuery);
            var addClaimsCommand = new AddClaimsToRoleCommand(role.Id, roleWithClaims.ClaimIds);
            await _mediator.Send(addClaimsCommand);
            return Ok();
        }
    }
}
