using Xunit;
using EmployeeManagement.Business;
using System;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test.ChatGPT
{
    public class EmployeeFactoryTests
    {
        private readonly EmployeeFactory _employeeFactory;

        public EmployeeFactoryTests()
        {
            _employeeFactory = new EmployeeFactory();
        }

        [Fact]
        public void CreateEmployee_EmptyFirstName_ThrowsArgumentException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => _employeeFactory.CreateEmployee("", "Jones"));
        }

        [Fact]
        public void CreateEmployee_EmptyLastName_ThrowsArgumentException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => _employeeFactory.CreateEmployee("John", ""));
        }

        [Fact]
        public void CreateEmployee_ExternalWithoutCompany_ThrowsArgumentException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => _employeeFactory.CreateEmployee("John", "Doe", null, true));
        }

        [Fact]
        public void CreateEmployee_Internal_DefaultValues()
        {
            // Arrange

            // Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("John", "Doe");

            // Assert
            Assert.Equal("John", employee.FirstName);
            Assert.Equal("Doe", employee.LastName);
            Assert.Equal(0, employee.YearsInService);
            Assert.Equal(2500, employee.Salary);
            Assert.False(employee.MinimumRaiseGiven);
            Assert.Single(employee.AttendedCourses); // Solo el curso obligatorio
            Assert.Equal(100, employee.SuggestedBonus);
        }

        [Fact]
        public void CreateEmployee_External_DefaultValues()
        {
            // Arrange

            // Act
            var employee = (ExternalEmployee)_employeeFactory.CreateEmployee("John", "Doe", "Company", true);

            // Assert
            Assert.Equal("John", employee.FirstName);
            Assert.Equal("Doe", employee.LastName);
            Assert.Equal("Company", employee.Company);
        }
    }
}
