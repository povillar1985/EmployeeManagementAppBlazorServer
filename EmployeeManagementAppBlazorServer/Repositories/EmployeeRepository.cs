using EmployeeManagementAppBlazorServer.Data;
using EmployeeManagementAppBlazorServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAppBlazorServer.Repositories
{
    /// <summary>
    /// Interface can be done using generic wrapper like >> IRepository<Entiy> where Entity: BaseType
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementDbContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;
        public EmployeeRepository(EmployeeManagementDbContext appDbContext, ILogger<EmployeeRepository> logger)
        {
            _dbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            try
            {
                var result = await _dbContext.AddAsync(employee);

                await _dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetAsync(int id)
        {
            try
            {
                var result = await _dbContext.Employees.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Employees.Include(x => x.Department).Select(x => new Employee
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DepartmentId = x.DepartmentId,
                    Email = x.Email,
                    Phone = x.Phone,
                    Bio = x.Bio,
                    Salary = x.Salary,
                    PhotoUrl = x.PhotoUrl,
                    Department = new Department { Id = x.DepartmentId, Name = x.Department.Name }
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(int departmentId)
        {
            try
            {
                return await _dbContext.Employees
                    .Where(x => x.DepartmentId == departmentId).Select(x => new Employee
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        DepartmentId = x.DepartmentId,
                        Email = x.Email,
                        Phone = x.Phone,
                        Bio = x.Bio,
                        PhotoUrl = x.PhotoUrl,
                        Department = new Department { Id = x.DepartmentId, Name = x.Department.Name }
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            try
            {
                if (employee == null) return false;

                _dbContext.Entry(employee).State = EntityState.Modified;

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
