using SMS.Application.Dto.Topic;

namespace SMS.Application.Dto.Module;

public class ModuleDto
{
    public string ModuleId { get; set; }
    public string? ModuleName { get; set; }
    public List<TopicDto> Topics { get; set; } = new List<TopicDto>();
}