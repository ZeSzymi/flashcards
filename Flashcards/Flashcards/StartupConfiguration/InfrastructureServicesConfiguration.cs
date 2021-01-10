using flashcards.Repositories;
using flashcards.Repositories.Interfaces;
using Flashcards.Repositories;
using Flashcards.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace flashcards.StartupConfiguration
{
    public class InfrastructureServicesConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IIdentityRepository, IdentityRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IFlashcardsRepository, FlashcardsRepository>();
        }
    }
}
