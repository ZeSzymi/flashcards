using AutoMapper;
using Flashcards.Models.Db;
using Flashcards.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Commands.Flashcards.AddFlashcard
{
    public class AddFlashcardHandler : IRequestHandler<AddFlashcardCommand, Flashcard>
    {
        private readonly IMapper _mapper;
        private readonly IFlashcardsRepository _flashcardsRepository;

        public AddFlashcardHandler(IMapper mapper, IFlashcardsRepository flashcardsRepository)
        {
            _mapper = mapper;
            _flashcardsRepository = flashcardsRepository;
        }

        public async Task<Flashcard> Handle(AddFlashcardCommand request, CancellationToken cancellationToken)
        {
            var flashcard = _mapper.Map<Flashcard>(request.Flashcard);
            flashcard.UserId = request.UserId;
            await _flashcardsRepository.AddFlashcard(flashcard);
            return flashcard;
        }
    }
}
