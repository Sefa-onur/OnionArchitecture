using Domain;
using OnionArchitecture.Persistance.Context;
using Application.Repostories.EmployeeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistance.Repositories.EmployeeRepository
{
    public class EmployeeReadRepository : ReadRepository<Employee>, IEmployeeRead
    {
        public EmployeeReadRepository(DbContextService context) : base(context)
        {
        }

    }
}
