using System.Threading.Tasks;
using flashcards.CQRS.Commands.Identity;
using flashcards.CQRS.Queries.Identity.LoginUser;
using flashcards.Models.Dtos;
using flashcards.Models.Identity;
using flashcards.StartupConfiguration.Options;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace flashcards.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMediator _mediator;
        private readonly UrlsOptions _options;

        public IdentityController(UserManager<User> userManager, SignInManager<User> signInManager, IMediator mediator, IOptions<UrlsOptions> options)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mediator = mediator;
            _options = options.Value;
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
                var query = new LoginUserQuery(userDto);
                token = await _mediator.Send(query);
            }
            return Ok(token);
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
