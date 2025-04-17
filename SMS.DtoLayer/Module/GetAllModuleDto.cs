using SMS.DtoLayer.Base;
using SMS.DtoLayer.Topic;

namespace SMS.DtoLayer.Module;

public record GetAllModuleDto : BaseDto
{
    public List<ModuleGetByIdDto> Modules { get; set; } = new List<ModuleGetByIdDto>();
}