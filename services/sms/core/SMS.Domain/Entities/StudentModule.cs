using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class StudentModule : BaseEntity
{
    public int StudentId { get; set; }
    public int ModuleId { get; set; }
    
    public Student Student { get; set; }
    public Module Module { get; set; }
}