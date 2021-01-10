using flashcards.Models.Dtos;
using Flashcards.Models.Db;
using MediatR;
using System;

namespace Flashcards.CQRS.Commands.Flashcards.AddFlashcard
{
    public class AddFlashcardCommand : IRequest<Flashcard>
    {
        public FlashcardDto Flashcard { get; }
        public Guid UserId { get; }

        public AddFlashcardCommand(FlashcardDto flashcard, Guid userId)
        {
            Flashcard = flashcard;
            UserId = userId;
        }
    }
}
