using AutoMapper;
using SMS.Application.Features.Commands.Module.CreateModule;
using SMS.Application.Features.Commands.Module.UpdateModule;
using SMS.Domain.Entities;
using SMS.DtoLayer.Module;
using SMS.DtoLayer.Topic;
using SMS.WebUI.ViewModels.Module;

namespace SMS.Application.Mappings;

public class ModuleMappingProfile : Profile
{
    public ModuleMappingProfile()
    {
        CreateMap<Module, ModuleCreateDto>().ReverseMap();
        CreateMap<Module, CreateModuleCommandRequest>().ReverseMap();
        CreateMap<ModuleCreateDto, CreateModuleCommandRequest>().ReverseMap();

        CreateMap<Module, GetAllModuleDto>().ReverseMap();
        CreateMap<ModuleGetByIdDto, ModuleViewModel>().ReverseMap();

        CreateMap<Module, ModuleGetByIdDto>().ReverseMap()
            .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics));

        CreateMap<Module, ModuleGetByIdForUpdateDto>().ReverseMap();
        CreateMap<Module, ModuleUpdateDto>().ReverseMap();
        CreateMap<Module, UpdateModuleCommandRequest>().ReverseMap();
    }
}