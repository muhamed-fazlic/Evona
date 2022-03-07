using AutoMapper;
using Evona.Task.Application.Contracts.Persistence;
using Evona.Task.Application.DTOs.Student;
using Evona.Task.Domain;
using Evona.Task.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evona.Task.Persistence.Repositories
{
    public class StudentRepository : GenericRepository<Student, StudentSearchDto>, IStudentRepository
    {
        private readonly EvonaTaskDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public StudentRepository(EvonaTaskDbContext dbContext, IMemoryCache memoryCache, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }

        public async Task<bool> GenerateStudents(int NumberOfStudents)
        {
            Random rnd = new();
            List<Student> students = new();

            for (int i = 0; i < NumberOfStudents; i++)
            {
                students.Add(new Student
                {
                    FirstName = "First name " + rnd.Next(200).ToString(),
                    LastName = "Last name " + rnd.Next(200, 400).ToString(),
                    BirthDate = new DateTime(1955, 1, 1).AddDays(rnd.Next(500, 1000)),
                    JMBG = rnd.Next(100000000, 999999999).ToString() + rnd.Next(1000, 9999).ToString()
                });
            }

            await _dbContext.AddRangeAsync(students);

            return true;
        }

        public async override Task<IReadOnlyList<Student>> GetAll(StudentSearchDto search = null)
        {
            //caching 
            List<Student> students;
            if (search.FirstName == null && search.LastName == null && search.JMBG == null) // most common case
            {
                bool AlreadyExist = _memoryCache.TryGetValue("CachedStudents", out students);
                if (!AlreadyExist)
                {
                    students = await _dbContext.Students.ToListAsync();

                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
                    _memoryCache.Set("CachedStudents", students, cacheEntryOptions);
                    return students;
                }
                return students;
            }

            var entity = _dbContext.Students.AsQueryable();

            if (search.FirstName != null)
                entity = entity.Where(x => x.FirstName.Contains(search.FirstName));
            if (search.LastName != null)
                entity = entity.Where(x => x.LastName.Contains(search.LastName));
            if (search.JMBG != null)
                entity = entity.Where(x => x.JMBG.Contains(search.JMBG));

            students = await entity.ToListAsync();
            return students;
        }

        public async void RemoveDeletedRows()
        {
            var students = await _dbContext.StudentBackups.Where(x => x.BackupStatus == BackupStatuses.Deleted).ToListAsync();
            _dbContext.RemoveRange(students);
        }
        public async Task<List<Student>> UpdateAll()
        {
            var st = await _dbContext.StudentBackups.Where(x => x.BackupStatus == BackupStatuses.Deleted).ToListAsync();
            _dbContext.RemoveRange(st);
            var Students = await _dbContext.Students.Where(x => x.BackupStatus == BackupStatuses.Created || x.BackupStatus == BackupStatuses.Updated).ToListAsync();
            var StudentsForUpdate = await _dbContext.StudentBackups.Where(x => Students.Select(x => x.Id).ToList().Contains(x.IdFromStudentTable)).ToListAsync();
            foreach (var item in Students)
            {
                if (item.BackupStatus == BackupStatuses.Created)
                {
                    var newStudent = _mapper.Map<StudentBackup>(item);
                    newStudent.BackupStatus = BackupStatuses.OK;
                    _dbContext.StudentBackups.Add(newStudent);
                }
                else
                {
                    var student = StudentsForUpdate.Find(x => x.IdFromStudentTable == item.Id);
                    student.BackupStatus = BackupStatuses.OK;
                    _mapper.Map(item, student);
                }
            }
            StudentsForUpdate.ForEach(x => x.BackupStatus = BackupStatuses.OK);
            Students.ForEach(x => x.BackupStatus = BackupStatuses.OK);
            var students = await _dbContext.Students.Where(x => x.BackupStatus == BackupStatuses.Created || x.BackupStatus == BackupStatuses.Updated).ToListAsync();
            return students;
        }
    }
}
