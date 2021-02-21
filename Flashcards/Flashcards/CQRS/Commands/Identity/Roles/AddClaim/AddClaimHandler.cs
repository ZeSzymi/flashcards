using flashcards.Models.Db;
using flashcards.Repositories;
using flashcards.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Commands.Identity.Roles.AddClaim
{
    public class AddClaimHandler : IRequestHandler<AddClaimCommand, bool>
    {
        private readonly IIdentityRepository _identityRepository;

        public AddClaimHandler(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }


        public async Task<bool> Handle(AddClaimCommand request, CancellationToken cancellationToken)
        {
           return await _identityRepository.AddClaim(request.ClaimName);
        }
    }
}
