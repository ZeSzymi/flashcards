using flashcards.Models.Dtos;
using flashcards.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Queries.Identity.RolesForUser
{
    public class GetRolesForUserHandler : IRequestHandler<GetRolesForUserQuery, List<RoleDto>>
    {
        private readonly IIdentityRepository _identityRepository;

        public GetRolesForUserHandler(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<List<RoleDto>> Handle(GetRolesForUserQuery request, CancellationToken cancellationToken)
        {
            return await _identityRepository.GetRolesForUser(request.UserId);
        }
    }
}
