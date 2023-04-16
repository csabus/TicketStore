using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace TicketStore.API.Helpers
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //TODO: log exceptions into database
                        //contextFeature.Error...
                        await context.Response.WriteAsync(new ApiError(context.Response.StatusCode, "Internal Server Error")
                            .ToString());
                    }
                });
            });
        }

    }
}
