using flashcards.Repositories.Interfaces;
using MediatR;
using repetitio.Models.Dtos.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace flashcards.CQRS.Queries.Identity.LoginUser
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserResponseDto>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUsersHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<List<UserResponseDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return _usersRepository.GetUsers();
        }
    }
}
