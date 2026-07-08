using Microsoft.AspNetCore.Mvc;

namespace CartNest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
