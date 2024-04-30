using AutoMapper;
using EmployeeManagement.Business;
using EmployeeManagement.Controllers;
using EmployeeManagement.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EmployeeManagement.Test
{
    public class InternalEmployeeControllerTests
    {
        private readonly InternalEmployeesController _internalEmployeesController;
        private readonly InternalEmployee _firstEmployee;



        public InternalEmployeeControllerTests()
        {
            _firstEmployee = new InternalEmployee(
                "Megan", "Jones", 2, 3000, false, 2)
            {
                Id = Guid.Parse("bfdd0acd-d314-48d5-a7ad-0e94dfdd9155"),
                SuggestedBonus = 400
            };

            // Mockup para interacturar con los servicios de empleado
            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock
                .Setup(m => m.FetchInternalEmployeesAsync())
                .ReturnsAsync(new List<InternalEmployee>() {
                    _firstEmployee,
                    new InternalEmployee("Jaimy", "Johnson", 3, 3400, true, 1),
                    new InternalEmployee("Anne", "Adams", 3, 4000, false, 3)
                });

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m =>
                 m.Map<InternalEmployee, Models.InternalEmployeeDto>
                 (It.IsAny<InternalEmployee>()))
                 .Returns(new Models.InternalEmployeeDto());

        }

        [Fact]
        public async Task GetInternalEmployees_GetAction_MustReturnOkObjectResult()
        {
            // Arrange
           
            // Act
            var result = await _internalEmployeesController.GetInternalEmployees();

            // Assert
            var actionResult = Assert
             .IsType<ActionResult<IEnumerable<Models.InternalEmployeeDto>>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }


        [Fact]
        public async Task GetInternalEmployees_GetAction_MustReturnIEnumerableOfInternalEmployeeDtoAsModelType()
        {
            // Arrange

            // Act 
            var result = await _internalEmployeesController.GetInternalEmployees();

            // Assert
            var actionResult = Assert
                .IsType<ActionResult<IEnumerable<Models.InternalEmployeeDto>>>(result);

            Assert.IsAssignableFrom<IEnumerable<Models.InternalEmployeeDto>>(
                ((OkObjectResult)actionResult.Result).Value);
        }

       
    }
}
