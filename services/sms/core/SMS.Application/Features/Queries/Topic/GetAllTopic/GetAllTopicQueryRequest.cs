using MediatR;

namespace SMS.Application.Features.Queries.Topic.GetAllTopic;

public class GetAllTopicQueryRequest : IRequest<GetAllTopicQueryResponse>
{
    public int ModuleId { get; set; }
}