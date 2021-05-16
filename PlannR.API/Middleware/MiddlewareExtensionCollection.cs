using Microsoft.AspNetCore.Builder;

namespace PlannR.API.Middleware
{
    public static class MiddlewareExtensionCollection
    {
        public static IApplicationBuilder UsePlannrMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlerMiddleware>();

            return builder;
        }
    }
}
