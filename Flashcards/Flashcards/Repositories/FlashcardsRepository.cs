using flashcards.Contexts;
using Flashcards.Models.Db;
using Flashcards.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Repositories
{
    public class FlashcardsRepository : IFlashcardsRepository
    {
        private readonly FlashcardsContext _context;

        public FlashcardsRepository(FlashcardsContext context)
        {
            _context = context;
        }

        public Task<List<Flashcard>> GetFlashcards(Guid userId) => _context.Flashcards
            .Include(flashcards => flashcards.Answers)
            .Where(flashcard => flashcard.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
        
        public async Task<Flashcard> AddFlashcard(Flashcard flashcard)
        {
            await _context.AddAsync(flashcard);
            await _context.SaveChangesAsync();
            return flashcard;
        }

        public async Task<Flashcard> DeleteFlashcard(Guid flashcardId) {
            var flashcard = await _context.Flashcards.SingleAsync(flashcard => flashcard.Id == flashcardId);
            _context.Remove(flashcard);
            await _context.SaveChangesAsync();
            return flashcard;
        }
    }
}
