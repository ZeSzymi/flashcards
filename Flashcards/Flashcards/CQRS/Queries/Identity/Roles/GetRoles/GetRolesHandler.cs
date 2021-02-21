using flashcards.Models.Dtos;
using flashcards.Models.Identity;
using flashcards.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Queries.Identity.Roles.GetRoles
{
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, List<RoleDto>>
    {
        private readonly IIdentityRepository _identityRepository;

        public GetRolesHandler(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public Task<List<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken) => _identityRepository.GetRoles();
    }
}
