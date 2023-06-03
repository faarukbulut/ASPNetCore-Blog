using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
    public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {
            Context c = new Context();

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.totalBlogCount = c.Blogs.Count().ToString();
            ViewBag.tatalCategoryCount = c.Categories.Count().ToString();
            ViewBag.writerBlogCount = c.Blogs.Where(x => x.WriterID == writerid).Count();

            return View();
        }
    }
}
