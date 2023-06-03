using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EFAboutRepository());

        [AllowAnonymous]
        public IActionResult Index()
        {
			var values = am.GetList();
			return View(values);
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }

    }
}
