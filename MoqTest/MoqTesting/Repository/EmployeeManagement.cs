using Microsoft.EntityFrameworkCore;
using MoqTesting.Data;
using MoqTesting.Models;
using MoqTesting.Services;

namespace MoqTesting.Repository
{
    public class EmployeeManagement : IEmployeeManagement
    {
        private readonly IEmployeeService context;

        public EmployeeManagement(IEmployeeService context)
        {
            this.context = context;
        }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await context.GetEmployeesAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid? id)
        {
            var employee = await context.GetEmployeeByIdAsync(id);
            return employee;
        }

        public async Task CreateEmployeeAsync(Employee emp)
        {
            await context.CreateEmployeeAsync(emp);
        }

        public async Task UpdateEmployeeAsync(Guid id, Employee emp)
        {
            await context.UpdateEmployeeAsync(id, emp);
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            await context.DeleteEmployeeAsync(id);
        }
    }
}
