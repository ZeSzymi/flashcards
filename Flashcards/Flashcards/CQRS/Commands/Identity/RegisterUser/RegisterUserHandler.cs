using flashcards.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace flashcards.CQRS.Commands.Identity.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.User.Username);
            user.Email = request.User.Email;
            user.NormalizedEmail = request.User.Email.ToUpper();
            user.DisplayName = request.DisplayName;
            return await _userManager.CreateAsync(user, request.User.Password);
        }
    }
}
