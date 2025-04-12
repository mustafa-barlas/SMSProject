using SMS.Application.Dto.Topic;

namespace SMS.Application.Dto.StudentModule;

public class StudentModuleDto
{
    public Guid ModuleId { get; set; }
    public Guid StudentId { get; set; }
    public string? ModuleName { get; set; }
    public bool IsActive { get; set; }
    public List<TopicDto> Topics { get; set; } = new List<TopicDto>();
}