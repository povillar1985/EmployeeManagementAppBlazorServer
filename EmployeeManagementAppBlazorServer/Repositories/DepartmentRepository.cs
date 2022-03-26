using EmployeeManagementAppBlazorServer.Data;
using EmployeeManagementAppBlazorServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAppBlazorServer.Repositories
{

    /// <summary>
    /// Interface can be done using generic wrapper like >> IRepository<Entiy> where Entity: BaseType
    /// </summary>
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeManagementDbContext _dbContext;
        private readonly ILogger<DepartmentRepository> _logger;
        public DepartmentRepository(EmployeeManagementDbContext appDbContext, ILogger<DepartmentRepository> logger)
        {
            _dbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Department> AddAsync(Department department)
        {
            try
            {
                var result = await _dbContext.AddAsync(department);

                await _dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _dbContext.Departments.FindAsync(id);
            if (department == null)
            {
                return false;
            }

            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Department> GetAsync(int id)
        {
            try
            {
                var result = await _dbContext.Departments.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            try
            {
                return (IEnumerable<Department>)await _dbContext.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Department department)
        {
            try
            {
                if (department == null) return false;

                _dbContext.Entry(department).State = EntityState.Modified;

                var result = await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
