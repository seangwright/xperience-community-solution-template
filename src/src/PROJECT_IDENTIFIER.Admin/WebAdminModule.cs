using CMS;
using PROJECT_IDENTIFIER.Admin;
using Kentico.Xperience.Admin.Base;

[assembly: RegisterModule(typeof(WebAdminModule))]

namespace PROJECT_IDENTIFIER.Admin;

internal class WebAdminModule : AdminModule
{
    public WebAdminModule() : base(nameof(WebAdminModule)) { }

    protected override void OnInit()
    {
        RegisterClientModule("client-name", "web-admin");

        base.OnInit();
    }
}
