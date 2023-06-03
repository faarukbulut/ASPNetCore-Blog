using CoreWeb.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
    public class WriterController : Controller
    {
        Context c = new Context();
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();

            model.namesurname = values.NameSurname;
            model.mail = values.Email;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;

            if(model.password != null)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            }

            var result = await _userManager.UpdateAsync(values);

            return RedirectToAction("Index", "Dashboard");
        }

    }
}
