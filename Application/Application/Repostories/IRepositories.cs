using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repostories
{
    public interface IRepositories<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
