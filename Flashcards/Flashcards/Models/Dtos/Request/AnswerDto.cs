using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models.Dtos.Request
{
    public class AnswerDto
    {
        public string Content { get; set; }
        public bool Correct { get; set; }
    }
}
