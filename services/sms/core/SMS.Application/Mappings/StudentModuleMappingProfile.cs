using AutoMapper;
using SMS.Domain.Entities;
using SMS.DtoLayer.StudentModule;

namespace SMS.Application.Mappings;

public class StudentModuleMappingProfile : Profile
{
    public StudentModuleMappingProfile()
    {
        CreateMap<StudentModule, StudentModuleCreateDto>().ReverseMap();
        CreateMap<StudentModule, StudentModuleGetByIdDto>().ReverseMap();
        CreateMap<StudentModule, StudentModuleUpdateDto>().ReverseMap();
    }
}