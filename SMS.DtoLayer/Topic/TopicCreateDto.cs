using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Topic;

public record TopicCreateDto : BaseDto
{
    public string Title { get; set; }
    public int ModuleId { get; set; }
}