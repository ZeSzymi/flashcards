using System.Threading.Tasks;
using flashcards.Models.Dtos;
using flashcards.Models.Identity;
using flashcards.Repositories.Interfaces;
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
        private readonly RoleManager<Role> _roleManager;
        private readonly IIdentityRepository _identityRepository;

        public RolesController(RoleManager<Role> roleManager, IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
            _roleManager = roleManager;
        }

        [HttpGet("claims/{claimValue}")]
        public async Task<IActionResult> AddClaim(string claimValue)
        {
            await _identityRepository.AddClaim(claimValue);
            return Ok();
        }

        [HttpGet("claims")]
        public async Task<IActionResult> Claims()
        {
            var claims = await _identityRepository.GetClaims();
            return Ok(claims);
        }

        [HttpGet("roles/{roleName}")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            var role = new Role(roleName);
            await _roleManager.CreateAsync(role);
            return Ok();
        }

        [HttpPost("roles/claims")]
        public async Task<IActionResult> AddClaimToRole([FromBody] RoleWithClaimsDto role)
        {
            await _identityRepository.AddClaimsToRole(role);
            return Ok();
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _identityRepository.GetRoles();
            return Ok(roles);
        }
    }
}
