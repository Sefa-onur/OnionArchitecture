using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repostories
{
    public interface IWriteRepositories<T>:IRepositories<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        bool Remove(string ID);
        bool Update(T model);
        bool Remove(T model);
        Task<bool> AddRangeAsync(List<T> models);
        bool Remove(List<T> models);
        Task<int> SaveAsync();
    }
}
