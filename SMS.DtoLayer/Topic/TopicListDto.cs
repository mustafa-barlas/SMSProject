using SMS.DtoLayer.Base;

namespace SMS.DtoLayer.Topic;

public record TopicListDto : BaseDTO
{
    public List<TopicDto> Topics { get; set; } = new List<TopicDto>();
}