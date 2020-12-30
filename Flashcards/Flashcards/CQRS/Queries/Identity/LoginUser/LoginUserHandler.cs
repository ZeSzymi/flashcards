using flashcards.Models.Identity;
using flashcards.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace flashcards.CQRS.Queries.Identity.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public LoginUserHandler(IIdentityRepository identityRepository, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _identityRepository = identityRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.User.Username);
            if (user == null)
            {
                return null;
            }

            if (request.HasPassword)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.User.Password, false);

                if (!result.Succeeded)
                {
                    return null;
                }
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>();

            claims.Add(new Claim("displayName", user.DisplayName ?? ""));
            claims.Add(new Claim("email", user.Email ?? ""));
            claims.Add(new Claim("username", user.UserName ?? ""));

            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                claims.AddRange(await _roleManager.GetClaimsAsync(role));
            }

            var token = _identityRepository.CreateToken(claims);
            return token;
        }
    }
}
