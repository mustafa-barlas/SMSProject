using AutoMapper;
using SMS.Domain.Entities;
using SMS.DtoLayer.Module;

namespace SMS.WebUI.Mappings;

public class ModuleMappingProfile : Profile
{
    public ModuleMappingProfile()
    {
        CreateMap<Module, ModuleCreateDto>().ReverseMap();
        CreateMap<Module, ModuleDetailDto>().ReverseMap();
        CreateMap<Module, ModuleDto>().ReverseMap();
        CreateMap<Module, ModuleListDto>().ReverseMap();
        CreateMap<Module, ModuleUpdateDto>().ReverseMap();
    }
}