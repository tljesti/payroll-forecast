using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayrollForecast.Api;
using PayrollForecast.Api.BusinessLogic;
using PayrollForecast.Api.Controllers;
using PayrollForecast.Api.Dtos;
using PayrollForecast.Api.Entities;
using PayrollForecast.Api.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Test.Controllers
{
    [TestClass]
    public class EmployeesControllerTests
    {
        private IEnumerable<Api.Entities.Employee> _testReplEmployees;
        private IEnumerable<Api.Dtos.EmployeeDto> _testDtoEmployees;
        private Mock<IEmployeeRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IEmployeeBusinessLogic> _mockEmployeeBusinessLogic;
        private Mock<IMapper> _mockMapper;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _testReplEmployees = new List<Api.Entities.Employee> {
                new Api.Entities.Employee { Id = 1, FirstName = "Jon", LastName = "Doe" },
                new Api.Entities.Employee { Id = 2, FirstName = "Matt", LastName = "Smith" },
                new Api.Entities.Employee { Id = 3, FirstName = "Anna", LastName = "Jackson" }
            };
            _testDtoEmployees = _testReplEmployees.Select(e => new Api.Dtos.EmployeeDto { Id = e.Id, FirstName = e.FirstName, LastName = e.LastName }).ToList();

            _mockRepository = new Mock<IEmployeeRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockEmployeeBusinessLogic = new Mock<IEmployeeBusinessLogic>();
            _mockMapper = new Mock<IMapper>();
        }

        [TestMethod]
        public async Task Get_ValidRequest_ShouldReturnOk()
        {
            _mockRepository.Setup(e => e.GetAll()).ReturnsAsync(_testReplEmployees);
            _mockUnitOfWork.Setup(e => e.Employees).Returns(_mockRepository.Object);
            _mockMapper.Setup(m => m.Map<IEnumerable<Api.Dtos.EmployeeDto>>(It.IsAny<IEnumerable<Api.Entities.Employee>>())).Returns(_testDtoEmployees);
            var testController = new EmployeesController(_mockUnitOfWork.Object, _mockMapper.Object, _mockEmployeeBusinessLogic.Object);

            var result = await testController.Get();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Result is not Ok");
        }

        [TestMethod]
        public async Task Get_PassUnknownId_ShouldReturnNotFound()
        {
            var id = 34;
            var testReplEmployee = _testReplEmployees.FirstOrDefault(e => e.Id == id);
            var testDtoEmployee = _testDtoEmployees.FirstOrDefault(e => e.Id == id);
            _mockRepository.Setup(e => e.GetById(id)).ReturnsAsync(testReplEmployee);
            _mockUnitOfWork.Setup(e => e.Employees).Returns(_mockRepository.Object);
            var testController = new EmployeesController(_mockUnitOfWork.Object, _mockMapper.Object, _mockEmployeeBusinessLogic.Object);

            var result = await testController.Get(id);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Result didn't return NotFound");
        }

        [TestMethod]
        public async Task Post_ModelPosted_ShouldReturnCreated()
        {
            var employeeDto = new EmployeeDto() { FirstName = "New", LastName = "Guy" };
            var employee = new Employee() { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName };
            var testController = new EmployeesController(_mockUnitOfWork.Object, _mockMapper.Object, _mockEmployeeBusinessLogic.Object);
            _mockMapper.Setup(m => m.Map<Employee>(It.IsAny<EmployeeDto>())).Returns(employee);
            _mockMapper.Setup(m => m.Map<EmployeeDto>(It.IsAny<Employee>())).Returns(employeeDto);
            _mockRepository.Setup(m => m.Add(employee)).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(m => m.Employees).Returns(_mockRepository.Object);
            _mockUnitOfWork.Setup(m => m.Complete()).Returns(Task.FromResult(true));

            var result = await testController.Post(employeeDto);
            
            Assert.IsInstanceOfType(result, typeof(CreatedResult), "Employee was not created");
        }
    }
}
