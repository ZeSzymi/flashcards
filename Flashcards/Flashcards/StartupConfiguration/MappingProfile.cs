using AutoMapper;
using flashcards.Models.Dtos;
using Flashcards.Models.Db;
using Flashcards.Models.Dtos.Request;

namespace flashcards.StartupConfiguration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Flashcard, FlashcardDto>();
            CreateMap<FlashcardDto, Flashcard>();

            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerDto, Answer>();
        }
    }
}
