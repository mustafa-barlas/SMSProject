using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Topic;

public record TopicDto : BaseDTO
{
    public string? TopicName { get; set; }
}