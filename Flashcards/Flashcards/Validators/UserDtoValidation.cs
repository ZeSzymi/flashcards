using flashcards.Models.Dtos;
using Flashcards.Consts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Validators
{
    public class UserDtoValidation : AbstractValidator<UserDto>
    {
        public UserDtoValidation()
        {
            RuleFor(userDto => userDto.Username).Must(username => username?.Length > 0).WithMessage(ExceptionMessages.EmptyLogin);
            RuleFor(userDto => userDto.Password).Must(username => username?.Length > 0).WithMessage(ExceptionMessages.EmptyPasswod);
        }
    }
}
