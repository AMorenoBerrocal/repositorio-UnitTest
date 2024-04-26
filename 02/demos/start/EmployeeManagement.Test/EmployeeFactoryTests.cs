using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryTests
    {
        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee) employeeFactory
                .CreateEmployee("Ale", "Moreno");

            // Assert
            Assert.Equal(2500, employee.Salary);

        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMsutBeBetween2500And3500()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Ale", "Moreno");

            // Assert
            Assert.True(employee.Salary >= 2500 && employee.Salary <= 3500, "Salario fuera de rango");
        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMsutBeBetween2500And3500_InRange()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Ale", "Moreno");

            // Assert
            Assert.InRange(employee.Salary, 2500, 3500);
        }
    }
}
