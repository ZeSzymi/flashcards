using flashcards.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace flashcards.CQRS.Commands.Identity
{
    public class RegisterUserCommand : IRequest<IdentityResult>
    {
        public UserDto User { get; }
        public string DisplayName { get; }
        public string Password { get; set; }
        public RegisterUserCommand(UserDto user, string displayName = null)
        {
            User = user;
            DisplayName = displayName ?? user.Username;
        }
    }
}
