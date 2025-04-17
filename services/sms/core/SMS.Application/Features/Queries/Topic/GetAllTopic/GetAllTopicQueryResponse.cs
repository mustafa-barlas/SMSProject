using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Queries.Topic.GetAllTopic;

public class GetAllTopicQueryResponse
{
    public List<GetAllTopicDto> Topics { get; set; } =  new List<GetAllTopicDto>();
}