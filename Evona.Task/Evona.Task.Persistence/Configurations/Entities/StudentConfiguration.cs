using Evona.Task.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Evona.Task.Persistence.Configurations.Entities
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                   new Student
                   {
                       Id = 1,
                       FirstName = "James",
                       LastName = "Smith",
                       JMBG = "1411955412829",
                       BirthDate = new DateTime(1999, 01, 01)
                   },
                   new Student
                   {
                       Id = 2,
                       FirstName = "Jennifer",
                       LastName = "Williams",
                       JMBG = "1507911427827",
                       BirthDate = new DateTime(2000, 04, 09)
                   }
                );
        }
    }
}
