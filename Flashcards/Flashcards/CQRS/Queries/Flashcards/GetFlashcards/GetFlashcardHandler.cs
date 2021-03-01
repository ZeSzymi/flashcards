using AutoMapper;
using flashcards.Models.Dtos;
using Flashcards.Models.Db;
using Flashcards.Models.Dtos.Response;
using Flashcards.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Queries.Flashcards.GetFlashcards
{
    public class GetFlashcardHandler : IRequestHandler<GetFlashcardsQuery, List<FlashcardResponseDto>>
    {
        private readonly IFlashcardsRepository _flashcardsRepository;
        private readonly IMapper _mapper;

        public GetFlashcardHandler(IFlashcardsRepository flashcardsRepository, IMapper mapper)
        {
            _flashcardsRepository = flashcardsRepository;
            _mapper = mapper;
        }

        public async Task<List<FlashcardResponseDto>> Handle(GetFlashcardsQuery request, CancellationToken cancellationToken)
        {
            var flashcards = await _flashcardsRepository.GetFlashcards(request.UserId);
            return flashcards.Select(flashcard => _mapper.Map<FlashcardResponseDto>(flashcard)).ToList();
        }
           
        
    }
}
