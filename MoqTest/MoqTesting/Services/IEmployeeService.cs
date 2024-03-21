using MoqTesting.Models;

namespace MoqTesting.Services
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(Employee emp);
        Task DeleteEmployeeAsync(Guid id);
        Task<Employee?> GetEmployeeByIdAsync(Guid? id);
        Task<List<Employee>> GetEmployeesAsync();
        Task UpdateEmployeeAsync(Guid id, Employee emp);
    }
}