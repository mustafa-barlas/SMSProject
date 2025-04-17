using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.StudentModule;

public record StudentModuleUpdateDto : BaseDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int ModuleId { get; set; }
}