using ApiTesting.Controllers;
using ApiTesting.Interface;
using ApiTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest_ApiTest
{
    public class EmployeeRepoTest_XUnit
    {

        EmployeesController _controller;
        Mock<IEmployeeRepo> _employeeRepository;

        public EmployeeRepoTest_XUnit()
        {
            _employeeRepository = new Mock<IEmployeeRepo>();
            _controller = new EmployeesController(_employeeRepository.Object);
        }

        [Fact]
        public void AddEmployee_ReturnsOkResult()
        {
            Employee employee = new Employee() { Name="Mori",Title="AVADH",Description=".Net" };
            var result = _controller.PostEmployee(employee);
            Xunit.Assert.True(result);
        }

        [Fact]
        public void GetEmployeeById_ReturnEmployeeById()
        {
            var existingId = 1;
            var result = _controller.GetEmployee(existingId);
            Xunit.Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void AddEmployee_InvalidEmployeepPassed_ReturnsBadRequestResult()
        {
            Employee employee = new Employee() { Id = 1, Description = ".NET", Title="AVADH" };
            _controller.ModelState.AddModelError(nameof(Employee.Name), "Name is required");
            var result = _controller.PostEmployee(employee);
            Xunit.Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteEmployee_NotExistingEmployeeIdPassed_ReturnsNotFoundResult()
        {
            var notExistingId = 7;
            var badResponse = _controller.DeleteEmployee(notExistingId);
            Xunit.Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void DeleteEmployee_ExistingEmployeeIdPassed_ReturnsOkResult()
        {
            var existingId = 1;
            var result = _controller.DeleteEmployee(existingId);
            Xunit.Assert.IsType<OkObjectResult>(result);
        }
    }
}
