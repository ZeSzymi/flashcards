using flashcards.Models.Dtos;
using flashcards.Models.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Queries.Identity.Roles.GetRoles
{
    public class GetRolesQuery : IRequest<List<RoleDto>>
    {
    }
}
