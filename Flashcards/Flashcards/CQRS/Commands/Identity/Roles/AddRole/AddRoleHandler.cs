using flashcards.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Commands.Identity.Roles.AddRole
{
    public class AddRoleHandler : IRequestHandler<AddRoleCommand, bool>
    {
        private readonly IIdentityRepository _identityRepository;

        public AddRoleHandler(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public Task<bool> Handle(AddRoleCommand request, CancellationToken cancellationToken) =>
            _identityRepository.AddRole(request.RoleName);
        
    }
}
