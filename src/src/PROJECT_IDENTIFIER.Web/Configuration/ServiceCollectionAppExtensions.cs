using PROJECT_IDENTIFIER.Web.Infrastructure;
using PROJECT_IDENTIFIER.Web.Rendering;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionAppExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services, IConfiguration config) =>
        services
            .AddRendering()
            .AddSEO();

    private static IServiceCollection AddRendering(this IServiceCollection services) =>
        services
            .AddScoped<ViewService>()
            .AddScoped<ClientAssets>();

    private static IServiceCollection AddSEO(this IServiceCollection services) =>
        services
            .AddScoped<WebPageMetaService>();
}
