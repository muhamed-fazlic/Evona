using AutoMapper;
using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.Student;
using Evona.Task.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evona.Task.Persistence.Repositories
{
    public class StudentBackupRepository : GenericRepository<StudentBackup, StudentSearchDto>, IStudentBackupRepository
    {
        private readonly EvonaTaskDbContext _dbContext;
        private readonly IMapper _mapper;
        public StudentBackupRepository(EvonaTaskDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async override Task<IReadOnlyList<StudentBackup>> GetAll(StudentSearchDto search = null)
        {
            var entity = _dbContext.StudentBackups.AsQueryable();

            if (search?.FirstName != null)
                entity = entity.Where(x => x.FirstName.Contains(search.FirstName));
            if (search?.LastName != null)
                entity = entity.Where(x => x.LastName.Contains(search.LastName));
            if (search?.JMBG != null)
                entity = entity.Where(x => x.JMBG.Contains(search.JMBG));

            return await entity.ToListAsync();
        }
    }
}
