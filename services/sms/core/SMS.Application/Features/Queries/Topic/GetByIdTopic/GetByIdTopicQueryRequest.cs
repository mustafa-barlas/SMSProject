using MediatR;

namespace SMS.Application.Features.Queries.Topic.GetByIdTopic;

public class GetByIdTopicQueryRequest : IRequest<GetByIdTopicQueryResponse>
{
    public string? TopicId { get; set; }
}