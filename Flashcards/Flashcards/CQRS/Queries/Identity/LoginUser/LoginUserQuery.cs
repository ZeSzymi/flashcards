using flashcards.Models.Dtos;
using MediatR;

namespace flashcards.CQRS.Queries.Identity.LoginUser
{
    public class LoginUserQuery : IRequest<string>
    {
        public UserDto User { get; }
        public bool HasPassword { get; }
        public LoginUserQuery(UserDto user, bool hasPassword = true)
        {
            User = user;
            HasPassword = hasPassword;
        }
    }
}
