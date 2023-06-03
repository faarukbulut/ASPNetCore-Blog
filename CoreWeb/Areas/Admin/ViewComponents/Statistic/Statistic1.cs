using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Policy;
using System.Xml.Linq;

namespace CoreWeb.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.ToplamBlogSayisi = bm.GetList().Count();
            ViewBag.YeniMesajSayisi = c.Contacts.Count();
            ViewBag.ToplamYorumSayisi = c.Comments.Count();

            string connection = "https://api.openweathermap.org/data/2.5/weather?lat=37.8550637&lon=27.8277285&mode=xml&lang=tr&units=metric&appid=5b0b2028f0e5faa9e05abbbc9c7f60a2";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(connection);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                XDocument document = XDocument.Parse(responseContent);
                ViewBag.APISicaklik = document.Descendants("temperature").ElementAt(0).Attribute("value").Value + "'C";
            }
            else
            {
                ViewBag.APISicaklik = "API Hata! " + response.StatusCode;
            }

            return View();
        }
    }
}
