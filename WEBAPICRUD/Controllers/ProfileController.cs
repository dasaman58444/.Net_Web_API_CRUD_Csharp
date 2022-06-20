using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        private static List<Profile> Employees = new List<Profile>
            { new Profile {
                          Id =1,
                          Name = "Aman Das",
                          FirstName ="Aman",
                          LastName = "Das",
                          Place = "Nepal"
            },
            new Profile {
                          Id =2,
                          Name = "Bimal Khan",
                          FirstName ="Bimal",
                          LastName = "Khan",
                          Place = "India"
            }
        };

        [HttpGet]
        public async Task <ActionResult<List<Profile>>> Get()
        {
          
            return Ok(Employees);
        }
        [HttpGet ("{id}")]
        public async Task<ActionResult<Profile>> Get(int id)
        {
            var Employee = Employees.Find(h => h.Id == id);
            if (Employee == null)
                return BadRequest("Employee not found.");
            return Ok(Employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<Profile>>> AddEmployee(Profile Employee )
        {
            Employees.Add(Employee);
            return Ok(Employees);
        }

        [HttpPut]
        public async Task<ActionResult<List<Profile>>> UpdateEmployee(Profile request)
        {
            var Employee = Employees.Find(h => h.Id == request.Id);
            if (Employee == null)
                return BadRequest("Employee not found.");

            Employee.Name = request.Name;
            Employee.FirstName = request.FirstName;
            Employee.LastName = request.LastName;
            Employee.Place = request.Place;

           
            return Ok(Employees);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> Delete(int id)
        {
            var Employee = Employees.Find(h => h.Id == id);
            if (Employee == null)
                return BadRequest("Employee not found.");

            Employees.Remove(Employee);
            return Ok(Employees);
        }
    }
}
