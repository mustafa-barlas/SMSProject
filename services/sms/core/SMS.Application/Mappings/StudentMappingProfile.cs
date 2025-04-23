using AutoMapper;
using SMS.Application.Features.Commands.Student.CreateStudent;
using SMS.Application.Features.Commands.Student.UpdateStudent;
using SMS.Domain.Entities;
using SMS.DtoLayer.Student;

namespace SMS.Application.Mappings;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        // CRUD için
        CreateMap<Student, StudentCreateDto>().ReverseMap();
        CreateMap<Student, StudentUpdateDto>().ReverseMap();
        CreateMap<Student, StudentGetByIdForUpdateDto>().ReverseMap();
        CreateMap<UpdateStudentCommandRequest, Student>().ReverseMap();
        CreateMap<UpdateStudentCommandRequest, StudentUpdateDto>().ReverseMap();
        CreateMap<CreateStudentCommandRequest, StudentCreateDto>().ReverseMap();
        CreateMap<CreateStudentCommandRequest, Student>().ReverseMap();


        // Listeleme ve detay
        CreateMap<Student, GetAllStudentDto>().ReverseMap();
        CreateMap<Student, StudentGetByIdDto>().ReverseMap();
        CreateMap<Student, GetStudentByIdWithAllPropDto>().ReverseMap();

        CreateMap<Student, StudentGetByIdDto>()
            .ForMember(dest => dest.StudentModules, opt => opt.MapFrom(src => src.StudentModules))
            .ForMember(dest => dest.HomeWorks, opt => opt.MapFrom(src => src.HomeWorks));
    }
}