using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
