using AutoMapper;
using SMS.Domain.Entities;
using SMS.DtoLayer.Student;

namespace SMS.Application.Mappings;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<Student, StudentGetByIdDto>().ReverseMap();
        CreateMap<Student, StudentGetByIdForUpdateDto>().ReverseMap();
        CreateMap<Student, StudentUpdateDto>().ReverseMap();
        CreateMap<Student, StudentCreateDto>().ReverseMap();
        CreateMap<Student, GetAllStudentDto>().ReverseMap();
        CreateMap<Student, GetStudentByIdWithAllPropDto>().ReverseMap();

    }
}