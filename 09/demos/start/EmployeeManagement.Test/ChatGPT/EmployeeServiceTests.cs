using EmployeeManagement.Business.EventArguments;
using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EmployeeManagement.Test.ChatGPT
{
    public class EmployeeServiceTests
    {
        private readonly EmployeeServiceFixture _employeeServiceFixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public EmployeeServiceTests(EmployeeServiceFixture employeeServiceFixture,
            ITestOutputHelper testOutputHelper)
        {
            _employeeServiceFixture = employeeServiceFixture;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
        {
            // Arrange          
            var obligatoryCourse = _employeeServiceFixture
                .EmployeeManagementTestDataRepository
                .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            // Act
            var internalEmployee = _employeeServiceFixture
                .EmployeeService
                .CreateInternalEmployee("Brooklyn", "Cannon");

            _testOutputHelper.WriteLine($"Employee after Act: " +
                $"{internalEmployee.FirstName} {internalEmployee.LastName}");
            internalEmployee.AttendedCourses
                .ForEach(c => _testOutputHelper.WriteLine($"Attended course: {c.Id} {c.Title}"));

            // Assert
            Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
        }

        // Otros métodos de prueba...

    }
}
