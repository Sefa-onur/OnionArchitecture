using Domain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistance.Context
{
    public class DbContextService:DbContext
    {
        public DbContextService(DbContextOptions options):base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now
                };
            }
            //foreach (var data in datas)
            //{
            //    if (data.State == EntityState.Added)
            //    {
            //        data.Entity.CreatedDate = DateTime.Now;
            //    }
            //    else if (data.State == EntityState.Modified)
            //    {
            //        data.Entity.UpdatedDate = DateTime.Now;
            //    }
            //}
            return await base.SaveChangesAsync(cancellationToken);
        }
    }

}
