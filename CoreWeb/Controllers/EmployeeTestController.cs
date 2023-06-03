using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreWeb.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7137/api/Default");
            var jsonString = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:7137/api/Default", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7137/api/Default/" + id);

            if(response.IsSuccessStatusCode)
            {
                var jsonEmployee = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("https://localhost:7137/api/Default/", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient(); 
            var response = await httpClient.DeleteAsync("https://localhost:7137/api/Default/" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }




    }




    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
