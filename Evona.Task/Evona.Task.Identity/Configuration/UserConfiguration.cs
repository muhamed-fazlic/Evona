using Evona.Task.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Evona.Task.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = 1,
                    Email = "admin@evona.com",
                    NormalizedEmail = "ADMIN@EVONA.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@evona.com",
                    NormalizedUserName = "ADMIN@EVONA.COM",
                    PasswordHash = hasher.HashPassword(null, "evonaadmin"),
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = 2,
                    Email = "user@evona.com",
                    NormalizedEmail = "USER@EVONA.COM",
                    FirstName = "System",
                    LastName = "User",
                    UserName = "user@evona.com",
                    NormalizedUserName = "USER@EVONA.COM",
                    PasswordHash = hasher.HashPassword(null, "evonauser"),
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );
        }
    }
}
