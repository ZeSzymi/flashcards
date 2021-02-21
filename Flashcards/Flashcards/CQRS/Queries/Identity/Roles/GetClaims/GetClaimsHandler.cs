using flashcards.Models.Db;
using flashcards.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Queries.Identity.Roles.GetClaims
{
    public class GetClaimsHandler : IRequestHandler<GetClaimsQuery, List<ClaimDb>>
    {
        private readonly IIdentityRepository _identityRepository;

        public GetClaimsHandler(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public Task<List<ClaimDb>> Handle(GetClaimsQuery request, CancellationToken cancellationToken) =>
            _identityRepository.GetClaims();
        
    }
}
