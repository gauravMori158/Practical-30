using ApiTesting.Models;

namespace ApiTesting.Interface
{
    public interface IEmployeeRepo
    {
        List<Employee> GetEmployees();
        Employee GetEmployees(int id);

        void DeleteEmployees(int id);
        void UpdateEmployees(Employee employee);
        bool CreateEmployee(Employee employee);

    }
}
