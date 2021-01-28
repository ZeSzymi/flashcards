using flashcards.Models.Dtos;
using Flashcards.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace flashcards.StartupConfiguration
{
    public static class FluentValidationServicesConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IValidator<FlashcardDto>, FlashcardDtoValidator>();
        }
    }
}
