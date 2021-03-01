using Flashcards.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Commands.Flashcards.DeleteFlashcard
{
    public class DeleteFlashcardHandler : IRequestHandler<DeleteFlashcardCommand, bool>
    {
        private readonly IFlashcardsRepository _flashcardsRepository;

        public DeleteFlashcardHandler(IFlashcardsRepository flashcardsRepository)
        {
            _flashcardsRepository = flashcardsRepository;
        }

        public async Task<bool> Handle(DeleteFlashcardCommand request, CancellationToken cancellationToken)
        {
            await _flashcardsRepository.DeleteFlashcard(request.FlashhcardId);
            return true;
        }
    }
}
