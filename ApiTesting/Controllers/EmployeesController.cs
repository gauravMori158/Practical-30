using ApiTesting.Interface;
using ApiTesting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeesController(IEmployeeRepo repo)
        {
            employeeRepo = repo;
        }

        // GET: api/Employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {

            return employeeRepo.GetEmployees();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public  Employee GetEmployee(int id)
        {

            var employee = employeeRepo.GetEmployees(id);

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public bool PutEmployee(int id, Employee employee)
        {
            if (id == employee.Id)
            {
                employeeRepo.UpdateEmployees(employee);
                return true;
            }


            return false;
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public bool PostEmployee(Employee employee)
        {
           bool result = employeeRepo.CreateEmployee(employee);
            return true;
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public bool DeleteEmployee(int id)
        {

            var employee = employeeRepo.GetEmployees(id);
            

            employeeRepo.DeleteEmployees(id);

            return true;
        }
    }
}
