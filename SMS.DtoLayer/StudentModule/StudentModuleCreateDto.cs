using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.StudentModule;

public record StudentModuleCreateDto : BaseDto
{
    public int StudentId { get; set; }
    public int ModuleId { get; set; }
}