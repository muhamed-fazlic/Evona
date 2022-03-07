using Evona.Task.Identity.Configuration;
using Evona.Task.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Evona.Task.Identity
{
    public class EvonaTaskIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public EvonaTaskIdentityDbContext(DbContextOptions<EvonaTaskIdentityDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
