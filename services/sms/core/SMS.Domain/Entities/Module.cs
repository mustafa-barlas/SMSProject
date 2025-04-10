using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class Module : BaseEntity
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; } 
    public bool? Status { get; set; }
    public List<Topic> Topics { get; set; } = new List<Topic>();
}