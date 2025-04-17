using MediatR;

namespace SMS.Application.Features.Queries.Topic.GetByIdTopic;

public class GetByIdTopicQueryRequest : IRequest<GetByIdTopicQueryResponse>
{
    public int TopicId { get; set; }
}