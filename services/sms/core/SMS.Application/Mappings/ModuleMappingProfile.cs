using AutoMapper;
using SMS.Domain.Entities;
using SMS.DtoLayer.Module;

namespace SMS.Application.Mappings;

public class ModuleMappingProfile : Profile
{
    public ModuleMappingProfile()
    {
        CreateMap<Module, ModuleCreateDto>().ReverseMap();
        CreateMap<Module, GetAllModuleDto>().ReverseMap(); 
        CreateMap<Module, ModuleGetByIdDto>().ReverseMap(); 
        CreateMap<Module, ModuleGetByIdForUpdateDto>().ReverseMap(); 
        CreateMap<Module, ModuleUpdateDto>().ReverseMap(); 
    }
}