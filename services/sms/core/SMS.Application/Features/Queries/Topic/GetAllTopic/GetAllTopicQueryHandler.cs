using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.TopicRepository;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Queries.Topic.GetAllTopic;

public class GetAllTopicQueryHandler(ITopicReadRepository readRepository)
    : IRequestHandler<GetAllTopicQueryRequest, GetAllTopicQueryResponse>
{
    public async Task<GetAllTopicQueryResponse> Handle(GetAllTopicQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = readRepository.GetAll(false);
        if (request.IncludeModule)
        {
            query = query.Include(x => x.Module);
        }

        var topics = await query
            .Select(x => new TopicDto
            {
                Id = x.Id,
                TopicName = x.Name,
                Status = x.Status,
                ModuleId = x.ModuleId // Eğer modül dahilse
            })
            .ToListAsync(cancellationToken);

        return new GetAllTopicQueryResponse
        {
            Topics = topics
        };
    }
}