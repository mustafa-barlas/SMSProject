using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class Module : BaseEntity
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public List<StudentModule> StudentModules { get; set; } = new List<StudentModule>();
    public List<Topic> Topics { get; set; } = new List<Topic>();
}