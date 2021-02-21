using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Commands.Identity.Roles.AddRole
{
    public class AddRoleCommand : IRequest<bool>
    {
        public string RoleName { get; }
        public AddRoleCommand(string roleName)
        {
            RoleName = roleName;
        }
    }
}
