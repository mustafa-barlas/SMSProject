using SMS.DtoLayer.Base;
using SMS.DtoLayer.Topic;

namespace SMS.DtoLayer.StudentModule;

public record StudentModuleWithTopicDto : BaseDTO
{
    public string? ModuleName { get; set; }
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }
    public bool IsActive { get; set; }
    public List<TopicDto> TopicDtos { get; set; } = new List<TopicDto>();
}