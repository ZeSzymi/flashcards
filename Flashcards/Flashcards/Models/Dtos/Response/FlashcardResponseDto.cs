using Flashcards.Models.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models.Dtos.Response
{
    public class FlashcardResponseDto
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
