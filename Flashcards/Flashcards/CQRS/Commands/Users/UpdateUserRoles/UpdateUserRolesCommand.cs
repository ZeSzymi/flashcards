using Flashcards.Models.Dtos.Request;
using MediatR;

namespace Flashcards.CQRS.Commands.Users.UpdateUserRoles
{
    public class UpdateUserRolesCommand : IRequest<bool>
    {
        public UserWithRolesDto UserWithRoles { get; }
        public UpdateUserRolesCommand(UserWithRolesDto userWithRoles)
        {
            UserWithRoles = userWithRoles;
        }
    }
}
