using AutoMapper;
using SMS.Application.Features.Commands.StudentModule.CreateStudentModule;
using SMS.Domain.Entities;
using SMS.DtoLayer.StudentModule;
using SMS.DtoLayer.Topic;
using SMS.WebUI.ViewModels.StudentModule;

namespace SMS.Application.Mappings;

public class StudentModuleMappingProfile : Profile
{
    public StudentModuleMappingProfile()
    {
        CreateMap<StudentModule, StudentModuleCreateDto>().ReverseMap();
        CreateMap<StudentModuleCreateViewModel, StudentModuleCreateDto>().ReverseMap();
        CreateMap<CreateStudentModuleCommandRequest, StudentModuleCreateDto>().ReverseMap();
        CreateMap<CreateStudentModuleCommandRequest, StudentModule>().ReverseMap();
        CreateMap<StudentModule, StudentModuleUpdateDto>().ReverseMap();

        CreateMap<StudentModule, StudentModuleGetByIdDto>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Module.Title))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Student.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Student.Surname))
            .ForMember(dest => dest.TopicDtos, opt => opt.MapFrom(src => src.Module.Topics))
            .ReverseMap();

        CreateMap<Topic, TopicGetByIdDto>().ReverseMap();
    }
}