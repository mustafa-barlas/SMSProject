using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class StudentModule : BaseEntity
{
    public Guid StudentModuleId { get; set; }
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }

    public bool IsActive { get; set; } = true;

    public Student? Student { get; set; }
    public Module? Module { get; set; }
}