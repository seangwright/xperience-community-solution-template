using Microsoft.AspNetCore.Mvc;

namespace PROJECT_IDENTIFIER.Components.Navigation;

public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var vm = new FooterViewModel();

        return View("~/Components/Navigation/Footer/Footer.cshtml", vm);
    }
}

public class FooterViewModel();
