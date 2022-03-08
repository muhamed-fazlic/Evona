using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.Student;
using Evona.Task.Domain;
using Evona.Task.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evona.Task.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<EvonaTaskDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("EvonaTaskConnectionString")));

            services.AddScoped(typeof(IGenericRepository<Student, StudentSearchDto>), typeof(GenericRepository<Student, StudentSearchDto>));
            services.AddScoped(typeof(IGenericRepository<StudentBackup, StudentSearchDto>), typeof(GenericRepository<StudentBackup, StudentSearchDto>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentBackupRepository, StudentBackupRepository>();

            services.AddMemoryCache();

            return services;
        }
    }
}
