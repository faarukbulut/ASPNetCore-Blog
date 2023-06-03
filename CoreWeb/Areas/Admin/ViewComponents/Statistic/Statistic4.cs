using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.Name = c.Admins.Where(x => x.AdminID == 2).Select(y => y.Name).FirstOrDefault();
            ViewBag.Foto = c.Admins.Where(x => x.AdminID == 2).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.ShortDesc = c.Admins.Where(x => x.AdminID == 2).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
