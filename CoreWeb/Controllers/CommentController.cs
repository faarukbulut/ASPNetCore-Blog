using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EFCommentRepository());

		public IActionResult Index()
		{
			return View();
		}

		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id);
			return PartialView(values);
		}

		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}

        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
			p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CommentStatus = true;
			p.BlogID = 2;
			cm.CommentAdd(p);

            return PartialView();
        }
    }
}
