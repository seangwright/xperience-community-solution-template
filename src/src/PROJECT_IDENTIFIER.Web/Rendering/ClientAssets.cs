using Microsoft.Extensions.Options;
using Vite.AspNetCore;

namespace PROJECT_IDENTIFIER.Web.Rendering;

public class ClientAssets(IWebHostEnvironment env, IViteManifest manifest, IOptions<ViteOptions> options)
{
    private readonly IWebHostEnvironment env = env;
    private readonly IViteManifest manifest = manifest;
    private readonly string basePath = $"/{options.Value.Base?.Trim('/')}";

    /// <summary>
    /// Returns the normalized path to the asset for the Vite.js build system.
    /// </summary>
    /// <param name="assetPath"></param>
    /// <returns></returns>
    public string ViteAssetPath(string assetPath)
    {
        if (env.IsDevelopment())
        {
            return $"{basePath}/{assetPath}";
        }

        if (manifest.ContainsKey(assetPath))
        {
            string file = $"{basePath}/{manifest[assetPath]?.File}";
            return file;
        }

        return "";
    }
}
