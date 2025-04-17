using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class Topic :  BaseEntity
{
    public string Title { get; set; }
    public int ModuleId { get; set; }
    public Module Module { get; set; }
}