using Microsoft.AspNetCore.Builder;
using TechSolutions.WebApi.Middlewares;

namespace TechSolutions.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
