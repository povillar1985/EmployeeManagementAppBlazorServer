using EmployeeManagementAppBlazorServer.Models;

namespace EmployeeManagementAppBlazorServer.Repositories
{
    /// <summary>
    /// Interface can be done using generic wrapper like >> IRepository<Entiy> where Entity: BaseType
    /// </summary>
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<IEnumerable<Employee>> GetAllAsync(int departmentId);
        Task<Employee> GetAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int id);
    }
}
