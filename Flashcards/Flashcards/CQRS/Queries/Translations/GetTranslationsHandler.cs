using MediatR;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Queries.Translations
{
    public class GetTranslationsHandler : IRequestHandler<GetTranslationsQuery, JObject>
    {
        IWebHostEnvironment _environment;
        public GetTranslationsHandler(IWebHostEnvironment env)
        {
            _environment = env;
        }

        public Task<JObject> Handle(GetTranslationsQuery request, CancellationToken cancellationToken)
        {
            var path = _environment.ContentRootPath;
            var translation = File.ReadAllText($"{path}/assets/i18n/{request.Language}.json");
            return Task.FromResult(JObject.Parse(translation));
        }
    }
}
