using SMS.Application.Dto.Module;

namespace SMS.Application.Dto.Topic;

public class TopicDto
{
    public string? TopicId { get; set; }
    public string? TopicName { get; set; }
    public bool? Status { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string? ModuleId { get; set; }
    public ModuleDto? ModuleDto { get; set; }
}