using Application.Repostories.EmployeeRepository;
using Domain;
using OnionArchitecture.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistance.Repositories.EmployeeRepository
{
    public class EmployeeWriteRepository : WriteRepository<Employee>, IEmployeeWrite
    {
        public EmployeeWriteRepository(DbContextService context) : base(context)
        {
        }
    }
}
