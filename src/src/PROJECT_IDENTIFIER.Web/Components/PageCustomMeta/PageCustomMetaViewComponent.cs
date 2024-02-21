using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PROJECT_IDENTIFIER.Web.Infrastructure;

namespace PROJECT_IDENTIFIER.Web.Components.PageCustomMeta;

public class PageCustomMetaViewComponent(
    IHttpContextAccessor contextAccessor,
    WebPageMetaService metaService) : ViewComponent
{
    private readonly IHttpContextAccessor contextAccessor = contextAccessor;
    private readonly WebPageMetaService metaService = metaService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var meta = await metaService.GetMeta();

        string url = contextAccessor.HttpContext?.Request.GetEncodedUrl() ?? "";

        var vm = new PageCustomMetaViewModel(meta)
        {
            SiteName = "PROJECT_IDENTIFIER",
            URL = url,
            OGImageURL = meta.OGImageURL,
            MetaRobotsContent = meta.Robots
        };

        return View("~/Components/ViewComponents/PageCustomMeta/PageCustomMeta.cshtml", vm);
    }
}

public class PageCustomMetaViewModel
{
    public static PageCustomMetaViewModel Empty { get; } = new PageCustomMetaViewModel();

    public PageCustomMetaViewModel(Meta meta)
    {
        Title = meta.Title;
        Description = meta.Description;
        CanonicalURL = string.IsNullOrWhiteSpace(meta.CanonicalURL)
            ? Maybe<string>.None
            : meta.CanonicalURL;
    }

    private PageCustomMetaViewModel()
    {
        OGImageURL = "";
        Title = "";
        Description = "";
        SiteName = "";
        CaptchaSiteKey = null;
        MetaRobotsContent = null;
    }

    public string URL { get; init; } = "";
    public string? OGImageURL { get; init; } = "";
    public string Title { get; init; } = "";
    public string Description { get; init; } = "";
    public string? CaptchaSiteKey { get; init; } = null;
    public string SiteName { get; init; } = "";
    public string? MetaRobotsContent { get; init; } = null;
    public Maybe<string> CanonicalURL { get; init; }
}
