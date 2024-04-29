using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Services.Test;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Test.Fixtures
{
    public class EmployeeServiceWithAspNetCoreDIFixture : IDisposable
    {
        private readonly ServiceProvider _serviceProvider;

        public IEmployeeManagementRepository EmployeeManagementTestDataRepository
        {
            get
            {
#pragma warning disable CS8603 // Referencia nula
                return _serviceProvider.GetService<IEmployeeManagementRepository>();
#pragma warning restore CS8603 // Referencia nula
            }
        }

        public IEmployeeService EmployeeService
        {
            get
            {
#pragma warning disable CS8603 // Referencia nula
                return _serviceProvider.GetService<IEmployeeService>();
#pragma warning restore CS8603 // Referencia nula
            }
        }


        public EmployeeServiceWithAspNetCoreDIFixture()
        {
            var services = new ServiceCollection();
            services.AddScoped<EmployeeFactory>();
            services.AddScoped<IEmployeeManagementRepository,
                EmployeeManagementTestDataRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            // build provider
            _serviceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
            
        }
    }
}
