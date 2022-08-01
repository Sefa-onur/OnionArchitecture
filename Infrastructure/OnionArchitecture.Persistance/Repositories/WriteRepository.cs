using Application.Repostories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnionArchitecture.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepositories<T> where T : BaseEntity
    {
        private readonly DbContextService _context;

        public WriteRepository(DbContextService context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry =  await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            Table.AddRange(models);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry =  Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Remove(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public bool Remove(string ID)
        {
            T emp = Table.FirstOrDefault(i => i.ID == Guid.Parse(ID));
            EntityEntry<T> entityEntry = Table.Remove(emp);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public Task<int> SaveAsync()
        {
           return _context.SaveChangesAsync();
        }
    }
}
