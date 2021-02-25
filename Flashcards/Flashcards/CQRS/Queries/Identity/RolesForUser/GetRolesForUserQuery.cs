using flashcards.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Queries.Identity.RolesForUser
{
    public class GetRolesForUserQuery : IRequest<List<RoleDto>>
    {
        public Guid UserId { get; }
        public GetRolesForUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
