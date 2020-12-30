using flashcards.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace flashcards.CQRS.Commands.Identity.RegisterUser
{
    public class AddUserToRoleHandler : IRequestHandler<AddUserToRoleCommand, IdentityResult>
    {
        private readonly UserManager<User> _userManager;

        public AddUserToRoleHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
        {
            var userName = request.Username;
            var user = await _userManager.FindByNameAsync(userName);
            return await _userManager.AddToRoleAsync(user, request.Role);
        }
    }
}
