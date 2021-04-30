using Microsoft.AspNetCore.Builder;

namespace PlannR.API.Middleware
{
    public static class MiddlewareExtensionCollection
    {
        public static IApplicationBuilder UsePlannrExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
