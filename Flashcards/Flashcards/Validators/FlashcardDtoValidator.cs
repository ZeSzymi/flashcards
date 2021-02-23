using flashcards.Models.Dtos;
using Flashcards.Consts;
using FluentValidation;

namespace Flashcards.Validators
{
    public class FlashcardDtoValidator : AbstractValidator<FlashcardDto>
    {
        public FlashcardDtoValidator()
        {
            RuleFor(flashcardsDto => flashcardsDto.Answers).NotNull().Must(answer => answer.Count > 0);
            RuleFor(flashcardsDto => flashcardsDto.Question).NotNull().NotEmpty();
        }
    }
}
