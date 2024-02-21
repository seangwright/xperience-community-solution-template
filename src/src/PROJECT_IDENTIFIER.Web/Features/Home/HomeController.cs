using Microsoft.AspNetCore.Mvc;

namespace PROJECT_IDENTIFIER.Features.Home;

[Route("")]
public class HomeController : Controller
{
    [HttpGet("")]
    public ActionResult Index() => View("~/Features/Home/Home.cshtml");
}
