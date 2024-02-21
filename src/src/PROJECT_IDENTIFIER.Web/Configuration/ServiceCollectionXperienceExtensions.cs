using CMS;
using CMS.Base.Configuration;
using CMS.EmailEngine;
using Kentico.Activities.Web.Mvc;
using PROJECT_IDENTIFIER.Web.Infrastructure.Storage;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.CrossSiteTracking.Web.Mvc;
using Kentico.Forms.Web.Mvc;
using Kentico.OnlineMarketing.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using Microsoft.AspNetCore.Localization.Routing;

[assembly: RegisterModule(typeof(StorageInitializationModule))]

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionXperienceExtensions
{
    public static IServiceCollection AddAppXperience(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env) =>
        services
            .AddKentico(features =>
            {
                features.UsePageBuilder(new PageBuilderOptions
                {
                    RegisterDefaultSection = true,
                    ContentTypeNames =
                    [
                        // ... add web page content types
                    ]
                });

                features.UseEmailMarketing();
                features.UseEmailStatisticsLogging();

                features.UseActivityTracking();

                features.UseCrossSiteTracking(new CrossSiteTrackingOptions
                {
                    ConsentSettings = null
                });

                features.UseWebPageRouting();
            })
            .AddKenticoTagManager()
            .AddPreviewComponentOutlines()
            .Configure<EmailQueueOptions>(o =>
            {
                o.ArchiveDuration = 14;
            })
            .IfDevelopment(env, c =>
            {
                _ = c.Configure<SmtpOptions>(config.GetSection("SmtpOptions"))
                    .AddXperienceSmtp();
            })
            .Configure<CookieLevelOptions>(options =>
            {
                // ...
            })
            .Configure<KenticoRequestLocalizationOptions>(options =>
            {
                options.RequestCultureProviders.Add(new RouteDataRequestCultureProvider
                {
                    RouteDataStringKey = "culture",
                    UIRouteDataStringKey = "culture"
                });
            })
            .Configure<FormBuilderBundlesOptions>(options =>
            {
                options.JQueryCustomBundleWebRootPath = "vendor/js/jquery-3.5.1.min.js";
                options.JQueryUnobtrusiveAjaxCustomBundleWebRootPath = "vendor/js/jquery.unobtrusive-ajax.min.js";
            })
            .Configure<FileUploadOptions>(options =>
            {
                // No customization atm
            });
}
