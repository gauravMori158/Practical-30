using ApiTesting.Controllers;
using ApiTesting.Interface;
using ApiTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_ApiTest
{
    public class EmployeeRepoTest_NUnit
    {

        EmployeesController _controller;
        Mock<IEmployeeRepo> _employeeService;
        [SetUp]
        public void SetUp()
        {
            _employeeService = new Mock<IEmployeeRepo>();
            _controller = new EmployeesController(_employeeService.Object);
        }
        [Test]
        public void AddEmployee_ReturnsOkResult()
        {
            var employee = new Employee() { Id = 1, Name = "Gaurav", Description = ".NET", Title= "Mori"};
            var result = _controller.PostEmployee(employee);
            NUnit.Framework.Assert.True(result);
        }

        [Test]
        public void GetEmployeeById_ReturnEmployee()
        {
            int employeeId = 1;
            var expectedEmployee = new Employee { Id = employeeId, Name = "Jay Prajapati", Title = "P" };
            _employeeService.Setup(repo => repo.GetEmployees(employeeId)).Returns(expectedEmployee);
            var result = _controller.GetEmployee(employeeId);

            var okResult = result  ;
            NUnit.Framework.Assert.NotNull(okResult);
            var actualEmployee = okResult.Value as Employee;
            NUnit.Framework.Assert.NotNull(actualEmployee);
            NUnit.Framework.Assert.AreEqual(expectedEmployee, actualEmployee);

        }

        [Test]
        public void AddEmployee_InvalidEmployeepPassed_ReturnsBadRequestResult()
        {
            Employee employee = new Employee() { Description = ".NET" };
            _controller.ModelState.AddModelError(nameof(Employee.Name), "Name is required");

            var result = _controller.PostEmployee(employee);
            NUnit.Framework.Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void DeleteEmployee_NotExistingEmployeeIdPassed_ReturnsNotFoundResult()
        {
            var notExistingId = 8;
            var badResponse = _controller.DeleteEmployee(notExistingId);
            NUnit.Framework.Assert.IsInstanceOf<NotFoundResult>(badResponse);
        }

        [Test]
        public void DeleteEmployee_ExistingEmployeeIdPassed_ReturnsOkResult()
        {
            var employee = new Employee() { Id = 3, Name = "Gaurav", Title="Mori", Description=".Net"};
            _employeeService.Setup(x => x.GetEmployees(3)).Returns(employee);

            _employeeService.Setup(x => x.DeleteEmployees(employee.Id));
            var result = _controller.DeleteEmployee(employee.Id);

            NUnit.Framework.Assert.IsInstanceOf<OkResult>(result);
        }
    }
}
