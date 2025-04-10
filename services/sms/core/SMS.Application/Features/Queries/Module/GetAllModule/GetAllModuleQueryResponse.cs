using SMS.Application.Dto.Module;

namespace SMS.Application.Features.Queries.Module.GetAllModule;

public class GetAllModuleQueryResponse
{
    public List<GetByIdModuleDto> ModuleDtos { get; set; } = new List<GetByIdModuleDto>();
}