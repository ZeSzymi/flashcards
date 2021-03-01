using flashcards.Models.Dtos;
using Flashcards.Models.Db;
using Flashcards.Models.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;

namespace Flashcards.CQRS.Queries.Flashcards.GetFlashcards
{
    public class GetFlashcardsQuery : IRequest<List<FlashcardResponseDto>>
    {
        public Guid UserId { get; }

        public GetFlashcardsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
