using flashcards.CQRS.PipelineBehaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace flashcards.StartupConfiguration
{
    public static class MediatRServicesConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(typeof(Startup));
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        }
    }
}
