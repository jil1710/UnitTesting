using Microsoft.EntityFrameworkCore;
using MoqTesting.Data;
using MoqTesting.Models;

namespace MoqTesting.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MoqContext context;

        public EmployeeService(MoqContext context)
        {
            this.context = context;
        }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await context.Employee.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid? id)
        {
            var employee = await context.Employee.FirstOrDefaultAsync(m => m.Id == id);
            return employee;
        }

        public async Task CreateEmployeeAsync(Employee emp)
        {
            await context.Employee.AddAsync(emp);
            await context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Guid id, Employee emp)
        {
            var employee = await GetEmployeeByIdAsync(id);
            if (employee != null)
            {
                employee.Age = emp.Age;
                employee.AccountNumber = emp.AccountNumber;
                employee.Name = emp.Name;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employee = await GetEmployeeByIdAsync(id);
            if (employee != null)
            {
                context.Employee.Remove(employee);
                await context.SaveChangesAsync();
            }
        }
    }
}
