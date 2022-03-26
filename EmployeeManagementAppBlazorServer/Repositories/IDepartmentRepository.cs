using EmployeeManagementAppBlazorServer.Models;

namespace EmployeeManagementAppBlazorServer.Repositories
{
    /// <summary>
    /// Interface can be done using generic wrapper like >> IRepository<Entiy> where Entity: BaseType
    /// </summary>
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> GetAsync(int id);
        Task<Department> AddAsync(Department department);
        Task<bool> UpdateAsync(Department department);
        Task<bool> DeleteAsync(int id);
    }
}
