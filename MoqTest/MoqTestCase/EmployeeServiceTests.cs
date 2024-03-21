using Microsoft.EntityFrameworkCore;
using Moq;
using MoqTesting.Data;
using MoqTesting.Models;
using MoqTesting.Repository;
using MoqTesting.Services;

namespace MoqTestCase
{
    public class EmployeeServiceTests
    {
        private readonly EmployeeManagement _sut;
        private readonly Mock<IEmployeeService> _employeeMockTest = new Mock<IEmployeeService>();
        public EmployeeServiceTests()
        {
            _sut = new EmployeeManagement(_employeeMockTest.Object);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnEmployee_WhenEmployeeExits()
        {
            var employeeId = Guid.NewGuid();

            var employeeDto = new Employee()
            {
                Name = "Jil Patel",
                Age = 21,
                AccountNumber = "123123123",
                Id = employeeId
            };

            _employeeMockTest.Setup(x => x.GetEmployeeByIdAsync(employeeId)).ReturnsAsync(employeeDto);

            var employee = await _sut.GetEmployeeByIdAsync(employeeId);

            Assert.Equal(employeeId.ToString(), employee?.Id.ToString());
            Assert.Equal(employeeDto.Name, employee?.Name);
        }

        [Fact]  
        public async Task GetByAsync_ShouldReturnAllEmployee_WhenEmployeesExits()
        {
            var employeesDto = new List<Employee>()
            {
                new Employee() 
                {
                    Id = Guid.NewGuid(),
                    Name = "Jil Patel",
                    AccountNumber = "123123123",
                    Age= 21
                },
                new Employee() 
                {
                    Id = Guid.NewGuid(),
                    Name = "Test",
                    AccountNumber = "321123321",
                    Age= 23
                },
            };

            _employeeMockTest.Setup(x => x.GetEmployeesAsync()).ReturnsAsync(employeesDto);

            var employees = await _sut.GetEmployeesAsync();

            Assert.Equal(employeesDto.Count(), employees.Count());
        }
        
        [Fact]  
        public async Task GetByIdAsync_ShouldReturnNothing_WhenEmployeesDoesNotExits()
        { 
            _employeeMockTest.Setup(x => x.GetEmployeeByIdAsync(It.IsAny<Guid>())).ReturnsAsync(() => null);

            var employee = await _sut.GetEmployeeByIdAsync(Guid.NewGuid());

            Assert.Null(employee);
        }
    }
}