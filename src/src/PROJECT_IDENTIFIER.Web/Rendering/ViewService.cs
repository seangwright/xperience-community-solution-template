using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace PROJECT_IDENTIFIER.Web.Rendering;

public class ViewService
{
    private readonly IHttpContextAccessor contextAccessor;
    private readonly IWebHostEnvironment env;
    private IRequestCultureFeature cultureFeature = null!;

    public ViewService(
        IHttpContextAccessor contextAccessor,
        IWebHostEnvironment env)
    {
        this.contextAccessor = contextAccessor;
        this.env = env;
    }

    public CultureInfo Culture
    {
        get
        {
            cultureFeature ??= contextAccessor.HttpContext!.Features.Get<IRequestCultureFeature>()!;

            return cultureFeature.RequestCulture.Culture;
        }
    }

    /// <summary>
    /// Determines if View caching is enabled for the current request
    /// </summary>
    /// <returns></returns>
    public bool CacheEnabled =>
        // Disable view caching locally since we are using .NET hot reload
        !env.IsDevelopment();
}
