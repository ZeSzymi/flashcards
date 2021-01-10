using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models.Db
{
    public class Answer
    {
        public Guid Id { get; set; }
        public Guid FlashcardId { get; set; }
        public string Content { get; set; }
        public bool Correct { get; set; }
    }
}
