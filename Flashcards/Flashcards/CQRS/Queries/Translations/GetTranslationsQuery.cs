using MediatR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Queries.Translations
{
    public class GetTranslationsQuery : IRequest<JObject>
    {
        public string Language { get; }
        public GetTranslationsQuery(string language)
        {
            Language = language;
        }
    }
}
