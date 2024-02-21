using Microsoft.AspNetCore.Mvc;

namespace PROJECT_IDENTIFIER.Web.Components.Navigation;

public class HeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var menuItems = new List<MenuItemViewModel>()
        {
            new()
            {
                Caption = "Home",
                Url = "/",
                Level = 1,
            },
            new()
            {
                Caption = "Services",
                Url = "/services",
                Level = 1,
            },
            new()
            {
                Caption = "About",
                Url = "/about",
                Level = 1,
            }
        }
        .Select(m =>
        {
            m.IsActive = Request.Path.StartsWithSegments(m.Url);
            return m;
        })
        .ToList();

        var model = new HeaderViewModel(menuItems);

        return View("~/Components/Navigation/Header/Header.cshtml", model);
    }
}

public class HeaderViewModel(IReadOnlyList<MenuItemViewModel> navItems)
{
    public IReadOnlyList<MenuItemViewModel> NavItems { get; } = navItems;
}

public class MenuItemViewModel : LinkViewModel
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public int Level { get; set; }
    public int Order { get; set; }
    public bool IsActive { get; set; }
}

public class LinkViewModel
{
    public string Caption { get; set; } = "";
    public string Url { get; set; } = "";
    public bool IsSelected { get; set; }
}
