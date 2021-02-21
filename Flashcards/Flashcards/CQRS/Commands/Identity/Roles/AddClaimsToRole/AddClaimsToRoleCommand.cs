using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Commands.Identity.Roles.AddClaimToRole
{
    public class AddClaimsToRoleCommand : IRequest<bool>
    {
        public Guid RoleId { get; }
        public List<Guid> ClaimIds { get; }
        public AddClaimsToRoleCommand(Guid roleId, List<Guid> claimIds)
        {
            RoleId = roleId;
            ClaimIds = claimIds;
        }
    }
}
