using SMS.DtoLayer.Module;

namespace SMS.Application.Features.Queries.Module.GetAllModule;

public class GetAllModuleQueryResponse
{
    public List<ModuleDto> Modules { get; set; } = new List<ModuleDto>();
}