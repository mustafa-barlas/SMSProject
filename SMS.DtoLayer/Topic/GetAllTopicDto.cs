using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Topic;

public record GetAllTopicDto : BaseDto
{
    public List<TopicGetByIdDto> Topics { get; set; } = new List<TopicGetByIdDto>();
}