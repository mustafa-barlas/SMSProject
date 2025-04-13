using SMS.DtoLayer.Module;

namespace SMS.Application.Features.Queries.Module.GetAllModule;

public class GetAllModuleQueryResponse
{
    public List<ModuleListDto> ModuleDtos { get; set; } = new List<ModuleListDto>();
}