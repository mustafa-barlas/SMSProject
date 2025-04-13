using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class Topic :  BaseEntity
{
    public string? Name { get; set; }
    public Guid ModuleId { get; set; }
    public Module? Module { get; set; }
}