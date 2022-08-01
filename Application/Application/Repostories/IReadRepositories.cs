using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repostories
{
    public interface IReadRepositories<T>:IRepositories<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        Task<T> GetbyIDAsync(string ID, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T,bool>> method, bool tracking = true);
        IQueryable GetWhere(Expression<Func<T,bool>> method, bool tracking = true);  
        
    }
}
