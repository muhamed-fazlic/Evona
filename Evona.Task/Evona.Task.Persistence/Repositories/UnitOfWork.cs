using AutoMapper;
using Evona.Task.Application.Constants;
using Evona.Task.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Evona.Task.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EvonaTaskDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IStudentRepository _studentRepository;
        private IStudentBackupRepository _studentBackupRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;
        public UnitOfWork(EvonaTaskDbContext context, IHttpContextAccessor httpContextAccessor, IMemoryCache memoryCache, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }

        public IStudentRepository StudentRepository => _studentRepository ??= new StudentRepository(_context, _memoryCache, _mapper);
        public IStudentBackupRepository StudentBackupRepository => _studentBackupRepository ??= new StudentBackupRepository(_context, _mapper);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async System.Threading.Tasks.Task Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;
            await _context.SaveChangesAsync(username);
        }
    }
}
