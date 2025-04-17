using AutoMapper;
using SMS.Domain.Entities;
using SMS.DtoLayer.Student;

namespace SMS.WebUI.Mappings;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<Student, StudentDetailDTO>().ReverseMap();
        CreateMap<StudentCreateDto, Student>().ReverseMap();
        CreateMap<StudentUpdateDto, Student>().ReverseMap();

        // ViewModel dönüşümleri
        CreateMap<StudentCreateDto, GetAllStudentDto>().ReverseMap();
        CreateMap<GetAllStudentDto, StudentCreateDto>().ReverseMap();

        CreateMap<StudentDetailDTO, StudentUpdateDto>().ReverseMap();
    }
}