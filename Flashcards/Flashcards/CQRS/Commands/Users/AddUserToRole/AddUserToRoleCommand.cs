using MediatR;
using Microsoft.AspNetCore.Identity;

namespace flashcards.CQRS.Commands.Identity
{
    public class AddUserToRoleCommand : IRequest<IdentityResult>
    {
        public string Username { get; }
        public string Role { get; }
        public AddUserToRoleCommand(string role, string username)
        {
            Role = role;
            Username = username;
        }
    }
}
