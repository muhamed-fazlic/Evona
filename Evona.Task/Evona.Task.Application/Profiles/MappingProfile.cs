using AutoMapper;
using Evona.Task.Application.DTOs.Student;
using Evona.Task.Application.DTOs.StudentBackup;
using Evona.Task.Domain;

namespace Evona.Task.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Student Mappings
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            #endregion Student

            #region StudentBackup Mappings
            CreateMap<StudentBackup, StudentBackupDto>().ReverseMap();
            #endregion StudentBackup

            CreateMap<Student, StudentBackup>()
                .ForMember(destination => destination.IdFromStudentTable, source => source.MapFrom(y => y.Id))
                .ForMember(destination => destination.Id, source => source.Ignore())
                .ReverseMap();
        }
    }
}
