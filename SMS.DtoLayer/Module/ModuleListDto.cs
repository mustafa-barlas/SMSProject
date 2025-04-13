using SMS.DtoLayer.Base;
using SMS.DtoLayer.Topic;

namespace SMS.DtoLayer.Module;

public record ModuleListDto : BaseDTO
{
    public List<ModuleDto> Modules { get; set; } = new();
}