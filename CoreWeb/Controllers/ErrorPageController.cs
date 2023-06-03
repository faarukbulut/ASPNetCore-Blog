using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult Index(int code)
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
