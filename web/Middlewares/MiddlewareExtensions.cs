using Microsoft.AspNetCore.Builder;

namespace Fiap.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMeuMiddlewareFiap(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuMiddleware>();
        }

    }
}