using MediatR;
using repetitio.Models.Dtos.Response;
using System.Collections.Generic;

namespace flashcards.CQRS.Queries.Identity.LoginUser
{
    public class GetUsersQuery : IRequest<List<UserResponseDto>>
    {
    }
}
