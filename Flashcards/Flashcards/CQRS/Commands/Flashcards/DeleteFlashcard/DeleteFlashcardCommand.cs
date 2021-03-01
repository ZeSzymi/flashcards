using MediatR;
using System;

namespace Flashcards.CQRS.Commands.Flashcards.DeleteFlashcard
{
    public class DeleteFlashcardCommand : IRequest<bool>
    {
        public Guid FlashhcardId { get; }
        public DeleteFlashcardCommand(Guid flashhcardId)
        {
            FlashhcardId = flashhcardId;
        }
        
    }
}
