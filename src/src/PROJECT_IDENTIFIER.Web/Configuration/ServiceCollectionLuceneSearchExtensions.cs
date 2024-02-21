using PROJECT_IDENTIFIER.Web.Infrastructure.Search;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionLuceneSearchExtensions
{
    public static IServiceCollection AddAppLuceneSearch(this IServiceCollection services, IConfiguration config) =>
        services
            .AddKenticoLucene(builder =>
            {
                // add strategies
            })
            .Configure<CustomLuceneSearchOptions>(config.GetSection("Kentico.Xperience.Lucene.Custom"));
}
