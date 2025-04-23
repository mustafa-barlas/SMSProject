using AutoMapper;
using SMS.DtoLayer.Student;
using SMS.WebUI.ViewModels.Student;

namespace SMS.WebUI.Mapping;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<StudentCreateViewModel, StudentCreateDto>().ReverseMap();

    }
}