using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagementAppBlazorServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementAppBlazorServer.Data;
using Moq;
using Microsoft.Extensions.Logging;
using EmployeeManagementAppBlazorServer.Models;

namespace EmployeeManagementAppBlazorServer.Repositories.Tests
{
    [TestClass()]
    public class DepartmentRepositoryTests
    {
        private Mock<ILogger<DepartmentRepository>> _mockLogger = new Mock<ILogger<DepartmentRepository>>();

        private EmployeeManagementDbContext _appDbContext;
        private IDepartmentRepository _instance;

        public DepartmentRepositoryTests()
        {
            _mockLogger.SetupAllProperties();

            var options = new DbContextOptionsBuilder<EmployeeManagementDbContext>()
            .UseInMemoryDatabase(databaseName: "EmployeeManagementDbMemory")
            .Options;

            _appDbContext = new EmployeeManagementDbContext(options);

            _instance = new DepartmentRepository(_appDbContext, _mockLogger.Object);
        }

        [TestMethod()]
        public async Task AddAsyncTest()
        {
            //arrange

            //act
            var result = await _instance.AddAsync(new Department { Name = "name", Description = "description" });

            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual("name", result.Name);
            Assert.AreEqual("description", result.Description);
        }

        //More tests
        //We can also make tests for components using bunit (been actively doing this at work)
    }
}