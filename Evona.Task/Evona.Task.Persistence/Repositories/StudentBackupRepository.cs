using AutoMapper;
using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Domain;

namespace Evona.Task.Persistence.Repositories
{
    public class StudentBackupRepository : GenericRepository<StudentBackup, object>, IStudentBackupRepository
    {
        private readonly EvonaTaskDbContext _dbContext;
        private readonly IMapper _mapper;
        public StudentBackupRepository(EvonaTaskDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
