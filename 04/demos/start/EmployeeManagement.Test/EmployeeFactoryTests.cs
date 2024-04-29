﻿using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryTests : IDisposable
    {

        private EmployeeFactory _employeeFactory;
        
        public EmployeeFactoryTests()
        {
            _employeeFactory = new EmployeeFactory();
        }

        public void Dispose()
        {
            
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]

        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {

            var employee = (InternalEmployee)_employeeFactory
                .CreateEmployee("Kevin", "Dockx");

            Assert.Equal(2500, employee.Salary);
        }

        [Fact(Skip = "Skipping this one for demo =P")]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]

        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
        {
            // Arrange

            // Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");

            // Assert
            Assert.True(employee.Salary >= 3000 && employee.Salary <= 3500,
                "Salary not in acceptable range.");
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]

        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_Alternative()
        {
            // Arrange

            // Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");

            // Assert
            Assert.True(employee.Salary >= 2500);
            Assert.True(employee.Salary <= 3500);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]

        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWithInRange()
        {
            // Arrange

            // Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");

            // Assert
            Assert.InRange(employee.Salary, 2500, 3500);
        }


        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500_PrecisionExample()
        {
            // Arrange

            // Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");
            employee.Salary = 2500.123m;

            // Assert
            Assert.Equal(2500, employee.Salary, 0);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmplotee_ReturnType")]
        public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
        {
            // Arrange
            var factory = new EmployeeFactory();

            // Act
            var employee = factory.CreateEmployee("Kevin", "Dockx", "Marvin", true);

            // Assert
            Assert.IsType<ExternalEmployee>(employee);
            //Assert.IsAssignableFrom<Employee>(employee);
        }
    }
}
