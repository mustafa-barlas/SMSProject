using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class Topic :  BaseEntity
{
    public string? Name { get; set; }
    public bool? Status { get; set; }
}