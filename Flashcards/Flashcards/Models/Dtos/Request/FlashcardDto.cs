using Flashcards.Models.Dtos.Request;
using System.Collections.Generic;

namespace flashcards.Models.Dtos
{
    public class FlashcardDto
    {
        public string Question { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
