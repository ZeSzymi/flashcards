using AutoMapper;
using flashcards.Contexts;
using flashcards.Middleware;
using flashcards.StartupConfiguration;
using flashcards.StartupConfiguration.Options;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace flashcards
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                        .AllowAnyOrigin()
                                        .AllowAnyHeader();
                                  });
            });

            services.AddDbContext<FlashcardsContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MySqlConnection")));

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver() { NamingStrategy = new CamelCaseNamingStrategy() };
                options.SerializerSettings.Formatting = Formatting.Indented;
            });

            services.AddMvc()
                .AddFluentValidation(fv => fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<UrlsOptions>(Configuration.GetSection(UrlsOptions.Urls));
            
            MediatRServicesConfiguration.Configure(services, Configuration);
            IdentityServicesConfiguration.Configure(services, Configuration);
            InfrastructureServicesConfiguration.Configure(services, Configuration);
            FluentValidationServicesConfiguration.Configure(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            app.ConfigureExceptionHandler(logger);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseExceptionHandler("/api/exception/Error");
        }
    }
}
