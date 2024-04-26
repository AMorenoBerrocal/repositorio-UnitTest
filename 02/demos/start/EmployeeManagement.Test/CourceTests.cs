using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    internal class CourceTests
    {
        public void CourseConstructor_ConstructCourse_IsNewMustBeTrue()
        {
            // Arrange
            // nada

            // Act
            var course = new Course("Curso de manejo de errores");

            // Assert
            Assert.True(course.IsNew);
        }
    }
}
