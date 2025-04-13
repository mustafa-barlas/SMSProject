using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.StudentModule;

public record StudentModuleUpdateDTO : BaseDTO
{
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }
    public bool IsActive { get; set; }
}