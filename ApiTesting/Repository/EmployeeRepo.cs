using ApiTesting.Interface;
using ApiTesting.Models;

namespace ApiTesting.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepo(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public void DeleteEmployees(int id)
        {
            var emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployees(int id)
        {
            var employee = _context.Employees.Find(id);
            return employee;

        }

        public void UpdateEmployees(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();

        }
        public bool CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return true;
        }
    }
}
