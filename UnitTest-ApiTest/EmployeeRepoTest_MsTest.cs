using ApiTesting.Controllers;
using ApiTesting.Interface;
using ApiTesting.Models;
using Moq;

namespace UnitTest_ApiTest
{
    [TestClass]
    public class EmployeeRepoTest_MsTest
    {
        [TestMethod]
        public void CreateEmployee_EmployeeObject_BoolOutput()
        {
            var moqService = new Mock<IEmployeeRepo>();
            moqService.Setup(s => s.CreateEmployee(It.IsAny<Employee>()));
            var ctrl = new EmployeesController(moqService.Object);
            var employee = new Employee()
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Title = "Test",
            };
            bool result = ctrl.PostEmployee(employee);
            Assert.IsTrue(result);
            moqService.Verify(s=>s.CreateEmployee(employee), Times.Once());

        }
        [TestMethod]
        public void UpdateEmployee_EmployeeObject_BoolOutput()
        {
            var moqService = new Mock<IEmployeeRepo>();
            moqService.Setup(s => s.UpdateEmployees(It.IsAny<Employee>()));
            var ctrl = new EmployeesController(moqService.Object);
            var employee = new Employee()
            {
                Id = 1,
                Name = "TestUpdated",
                Description = "Test Updated",
                Title = "Test Updated",
            };
            bool result = ctrl.PutEmployee(employee.Id,employee);
            Assert.IsTrue(result);
            moqService.Verify(s => s.UpdateEmployees(employee), Times.Once());

        }
        [TestMethod]
        public void DeleteEmployee_EmployeeId_BoolOutput()
        {
            var moqService = new Mock<IEmployeeRepo>();
            moqService.Setup(s => s.DeleteEmployees(It.IsAny<int>()));
            var ctrl = new EmployeesController(moqService.Object);
            var employee = new Employee();
             
            bool result = ctrl.DeleteEmployee(1);
            Assert.IsTrue(result);
            moqService.Verify(s => s.DeleteEmployees(1), Times.Once());

        }
        [TestMethod]
        public void GetEmployeeById_EmployeeId_BoolOutput()
        {
            var moqService = new Mock<IEmployeeRepo>();
            moqService.Setup(s => s.GetEmployees(It.IsAny<int>()));
            var ctrl = new EmployeesController(moqService.Object);
            var employee = new Employee();

            Employee result = ctrl.GetEmployee(1);
            var employee1 = new Employee()
            {
                Id = 1,
                Name = "Gaurav",
                Description = "Mori",
                Title = "SDE",
            };
            var r1 = true;
            if(employee1 != result) 
            {
                r1=false;
            }
            Assert.IsTrue(r1);
            moqService.Verify(s => s.GetEmployees(1), Times.Once());

        }


    }
}