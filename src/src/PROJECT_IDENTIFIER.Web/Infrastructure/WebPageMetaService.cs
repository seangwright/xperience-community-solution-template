namespace PROJECT_IDENTIFIER.Web.Infrastructure;

public class WebPageMetaService
{
    private Meta meta = new("", "");

    public Task<Meta> GetMeta()
    {
        string titlePattern = "{0}";
        string pageTitle = meta.Title;

        string fullTitle = string.Format(titlePattern, pageTitle).Trim(' ').TrimStart('|').Trim(' ');

        meta = meta with { Title = fullTitle };

        return Task.FromResult(meta);
    }

    public void SetMeta(Meta meta) => this.meta = meta;
}

public record Meta(string Title, string Description)
{
    public Meta(IWebPageMeta meta) : this(meta.WebPageMetaTitle, meta.WebPageMetaDescription) => Robots = meta.WebPageMetaRobots;

    public string? CanonicalURL { get; init; }
    public string? OGImageURL { get; init; }
    public string? Robots { get; set; } = null;
};
