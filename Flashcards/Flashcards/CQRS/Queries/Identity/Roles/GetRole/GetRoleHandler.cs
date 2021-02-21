using flashcards.Models.Identity;
using flashcards.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Queries.Identity.Roles.GetRole
{
    public class GetRoleHandler : IRequestHandler<GetRoleQuery, Role>
    {
        private readonly IIdentityRepository _identityRepository;

        public GetRoleHandler(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public Task<Role> Handle(GetRoleQuery request, CancellationToken cancellationToken) =>
            _identityRepository.GetRole(request.RoleName);
        
    }
}
