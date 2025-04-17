using SMS.DtoLayer.Module;

namespace SMS.Application.Features.Queries.Module.GetAllModule;

public class GetAllModuleQueryResponse
{
    public List<GetAllModuleDto> Modules { get; set; } = new List<GetAllModuleDto>();
}