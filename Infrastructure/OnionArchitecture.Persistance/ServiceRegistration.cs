using Application.Repostories.EmployeeRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Persistance.Context;
using OnionArchitecture.Persistance.Repositories.EmployeeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<DbContextService>(options => options.UseSqlServer("Data Source=DESKTOP-MMAVGD3;Initial Catalog=Employee;User ID=sa;Password=3394320"),ServiceLifetime.Singleton);
            services.AddScoped<IEmployeeRead, EmployeeReadRepository>();
            services.AddScoped<IEmployeeWrite, EmployeeWriteRepository>();
        }
    }
}
