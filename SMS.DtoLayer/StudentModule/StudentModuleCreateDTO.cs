using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.StudentModule;

public record StudentModuleCreateDTO : BaseDTO
{
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }
}