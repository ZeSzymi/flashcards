using Flashcards.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Repositories.Interfaces
{
    public interface IFlashcardsRepository
    {
        public Task<List<Flashcard>> GetFlashcards(Guid userId);
        public Task<Flashcard> AddFlashcard(Flashcard flashcard);
        public Task<Flashcard> DeleteFlashcard(Guid flashcardId);
    }
}
