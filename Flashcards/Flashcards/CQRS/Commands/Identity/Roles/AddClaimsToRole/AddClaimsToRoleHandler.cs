using flashcards.Repositories.Interfaces;
using Flashcards.CQRS.Commands.Identity.Roles.AddClaimToRole;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Commands.Identity.Roles.AddClaimsToRole
{
    public class AddClaimsToRoleHandler : IRequestHandler<AddClaimsToRoleCommand, bool>
    {
        private readonly IIdentityRepository _identityRepository;

        public AddClaimsToRoleHandler(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public Task<bool> Handle(AddClaimsToRoleCommand request, CancellationToken cancellationToken) => 
            _identityRepository.AddClaimsToRole(request.RoleId, request.ClaimIds);
        
    }
}
