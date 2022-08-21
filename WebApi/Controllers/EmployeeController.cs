using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
            private static List<Employee> employees = new List<Employee>
                {
                new Employee {
                    Id = 1, FName = "myfname1", LName = "mylname1", Position = "Broadcaster1"
                    },
                
                new Employee {
                    Id = 2, FName = "myfname2", LName = "mylname2", Position = "Broadcaster2"
                    }
                };

        
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Employee>>> Get(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
                return BadRequest("Employee not found");
            return Ok(employees);
        }


        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employ)
        {
            employees.Add(employ);
            return Ok(employees);
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee request)
        {
            var employee = employees.Find(e => e.Id == request.Id);
            if (employee == null)
                return BadRequest("Employee not found");
            employee.FName = request.FName;
            employee.LName = request.LName;
            employee.Position = request.Position;

            return Ok(employees);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> Delete(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
                return BadRequest("Employee not found");
            employees.Remove(employee);
            return Ok(employees);
        }

    }
}
