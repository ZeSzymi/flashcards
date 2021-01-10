using flashcards.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models.Db
{
    public class Flashcard
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
