using EmployeeManagementAppBlazorServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAppBlazorServer.Data
{
    public class EmployeeManagementDbContext : DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
    }
}
