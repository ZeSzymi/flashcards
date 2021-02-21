using flashcards.Models.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Queries.Identity.Roles.GetRole
{
    public class GetRoleQuery : IRequest<Role>
    {
        public string RoleName { get; }
        public GetRoleQuery(string roleName)
        {
            RoleName = roleName;
        }
    }
}
