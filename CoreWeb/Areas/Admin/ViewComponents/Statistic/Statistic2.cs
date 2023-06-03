using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.SonEklenenBlog = c.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            return View();
        }
    }
}
