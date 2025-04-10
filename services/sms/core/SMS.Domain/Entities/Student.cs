using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class Student : BaseEntity
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public bool? Status { get; set; }
    public List<Module> Modules { get; set; } = new List<Module>();
    public List<HomeWork> HomeWorks { get; set; } = new List<HomeWork>();
}