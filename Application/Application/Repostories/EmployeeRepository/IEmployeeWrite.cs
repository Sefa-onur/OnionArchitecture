﻿using Domain;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repostories.EmployeeRepository
{
    public interface IEmployeeWrite:IWriteRepositories<Employee>
    {
    }
}
