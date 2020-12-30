using flashcards.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace flashcards.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    context.Response.ContentType = "appliaction/json";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    if (exceptionFeature != null)
                    {
                        string path = exceptionFeature.Path;
                        Exception exception = exceptionFeature.Error;
                        logger.LogError(exception.Message);

                        switch (exception)
                        {
                            case ObjectNotFoundException e:
                                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                                break;
                        }
                    }
                });
            });
        }
    }
}
