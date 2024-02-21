using PROJECT_IDENTIFIER.Web.Resources;
using Vite.AspNetCore.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionMvcExtensions
{
    public static IServiceCollection AddAppMvc(this IServiceCollection services, IWebHostEnvironment env) =>
        services
            .Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
                /*
                 * Must be proper case for token validation
                 * https://github.com/dotnet/aspnetcore/issues/40285#issuecomment-1047694858
                 */
                options.LowercaseQueryStrings = false;
            })
            .AddLocalization()
            .Configure<StaticFileOptions>(o =>
            {
                o.OnPrepareResponse = context =>
                {
                    // Caches static files for 7 days
                    context.Context.Response.Headers.Append("Cache-Control", "public,max-age=604800");
                };
            })
            .AddControllersWithViews(config =>
            {
            })
            .AddViewLocalization()
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider =
                    (type, factory) => factory.Create(typeof(SharedResources));
            })
            .Services
            .AddHttpContextAccessor()
            .AddHttpClient()
            .AddViteServices()
            .AddHealthChecks()
            .Services;
}
