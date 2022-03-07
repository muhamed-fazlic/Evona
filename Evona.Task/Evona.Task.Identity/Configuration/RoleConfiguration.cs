using Evona.Task.Identity.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evona.Task.Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(

                new IdentityRole<int>
                {
                    Id = 1,
                    Name = UserRoles.UserRole,
                    NormalizedName = UserRoles.UserRole.ToLower()
                },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = UserRoles.AdminRole,
                    NormalizedName = UserRoles.AdminRole.ToLower()
                }
               );
        }
    }
}
