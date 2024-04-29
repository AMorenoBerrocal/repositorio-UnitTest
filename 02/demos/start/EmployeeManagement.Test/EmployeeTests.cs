using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameIsCompleted()
        {
            // Arrange
            var employee = new InternalEmployee("Ale", "Moreno", 0, 2500, false, 1);

            // Act
            employee.FirstName = "Roberto";
            employee.LastName = "Carlos";

            // Assert: ignoramos los espacios en blanco
            Assert.Equal("Roberto Carlos", employee.FullName, ignoreCase:true);
        }


        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameStartWitFirsttName()
        {
            // Arrange
            var employee = new InternalEmployee("Ale", "Moreno", 0, 2500, false, 1);

            // Act
            employee.FirstName = "Roberto";
            employee.LastName = "Carlos";

            // Assert: ignoramos los espacios en blanco
            Assert.StartsWith(employee.FirstName, employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameEndWithLastName()
        {
            // Arrange
            var employee = new InternalEmployee("Ale", "Moreno", 0, 2500, false, 1);

            // Act
            employee.FirstName = "Roberto";
            employee.LastName = "Carlos";

            // Assert: ignoramos los espacios en blanco
            Assert.EndsWith(employee.LastName, employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameContains()
        {
            // Arrange
            var employee = new InternalEmployee("Ale", "Moreno", 0, 2500, false, 1);

            // Act
            employee.FirstName = "Roberto";
            employee.LastName = "Carlos";

            // Assert: ignoramos los espacios en blanco
            Assert.Contains("to Ca", employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameMatches()
        {
            // Arrange
            var employee = new InternalEmployee("Ale", "Moreno", 0, 2500, false, 1);

            // Act
            employee.FirstName = "Roberto";
            employee.LastName = "Carlos";

            // Assert: ignoramos los espacios en blanco
            Assert.Matches("Rob(e|v|t)rto Car(l|j|m)os", employee.FullName);
        }
    }
}
