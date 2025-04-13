using MediatR;

namespace SMS.Application.Features.Queries.Topic.GetAllTopic;

public class GetAllTopicQueryRequest : IRequest<GetAllTopicQueryResponse>
{
    public bool IncludeModule { get; set; } // Modül dahil edilsin mi?
}