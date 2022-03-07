using Evona.Task.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Evona.Task.Persistence
{
    public class AuditableDbContext : DbContext
    {
        public AuditableDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
        {
            foreach (var item in base.ChangeTracker.Entries<BaseDomainEntity>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                item.Entity.LastModifiedDate = DateTime.Now;
                item.Entity.LastModifiedBy = username;
                if (item.State == EntityState.Added)
                {
                    item.Entity.DateCreated = DateTime.Now;
                    item.Entity.CreatedBy = username;
                }
            }
            var result = await base.SaveChangesAsync();
            return result;
        }
    }
}
