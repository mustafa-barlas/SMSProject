using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.TopicRepository;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Queries.Topic.GetAllTopic;

public class GetAllTopicQueryHandler(ITopicReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetAllTopicQueryRequest, GetAllTopicQueryResponse>
{
    public async Task<GetAllTopicQueryResponse> Handle(GetAllTopicQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = await readRepository.GetAll().Include(x => x.Module)
            .Where(x => x.ModuleId.Equals(request.ModuleId)).ToListAsync(cancellationToken);

        var response = mapper.Map<List<TopicGetByIdDto>>(query);

        return new GetAllTopicQueryResponse
        {
            Topics = response
        };
    }
}