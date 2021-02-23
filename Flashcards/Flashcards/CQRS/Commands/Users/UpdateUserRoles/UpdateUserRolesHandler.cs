using flashcards.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Commands.Users.UpdateUserRoles
{
    public class UpdateUserRolesHandler : IRequestHandler<UpdateUserRolesCommand, bool>
    {
        private readonly IUsersRepository _usersRepository;

        public UpdateUserRolesHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public  async Task<bool> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            await _usersRepository.UpdateUserRoles(request.UserWithRoles);
            return true;
        }
    }
}
