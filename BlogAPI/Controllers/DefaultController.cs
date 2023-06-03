using BlogAPI.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        Context c = new Context();

        [HttpGet]
        public IActionResult EmployeeList()
        {
            var values = c.Employees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            var value = c.Employees.Find(id);
            if(value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            var value = c.Employees.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee e)
        {
            var value = c.Find<Employee>(e.ID);
            if(value == null)
            {
                return NotFound();
            }
            else
            {
                value.Name = e.Name;
                c.Update(value);
                c.SaveChanges();
                return Ok();
            }
        }

    }
}
