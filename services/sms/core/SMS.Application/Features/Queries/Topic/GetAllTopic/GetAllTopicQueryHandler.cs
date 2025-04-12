using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Dto.Topic;
using SMS.Application.Repositories.TopicRepository;

namespace SMS.Application.Features.Queries.Topic.GetAllTopic;

public class GetAllTopicQueryHandler(ITopicReadRepository readRepository) :
    IRequestHandler<GetAllTopicQueryRequest, GetAllTopicQueryResponse>
{
    public async Task<GetAllTopicQueryResponse> Handle(GetAllTopicQueryRequest request,
        CancellationToken cancellationToken)
    {
        var topics = await readRepository.GetAll(false)
            .Include(x => x.Module)
            .Select(x => new TopicDto
            {
                TopicId = x.Id,
                TopicName = x.Name,
                Status = x.Status
                
            })
            .ToListAsync(cancellationToken);

        return new GetAllTopicQueryResponse
        {
            Topics = topics
        };
    }
}