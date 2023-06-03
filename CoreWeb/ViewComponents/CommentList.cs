using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.ViewComponents
{
	public class CommentList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
