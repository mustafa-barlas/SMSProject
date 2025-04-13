using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.StudentModule;

public record StudentModuleDto : BaseDTO
{
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }
    public bool IsActive { get; set; }
}