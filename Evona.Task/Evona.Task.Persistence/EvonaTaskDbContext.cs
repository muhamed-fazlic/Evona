using Evona.Task.Domain;
using Microsoft.EntityFrameworkCore;

namespace Evona.Task.Persistence
{
    public class EvonaTaskDbContext : AuditableDbContext
    {
        public EvonaTaskDbContext(DbContextOptions<EvonaTaskDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EvonaTaskDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentBackup> StudentBackups { get; set; }
    }
}
