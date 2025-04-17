using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.TopicRepository;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Queries.Topic.GetByIdTopic;

public class GetByIdTopicQueryHandler(ITopicReadRepository readRepository, IMapper mapper) :
    IRequestHandler<GetByIdTopicQueryRequest, GetByIdTopicQueryResponse>
{
    public async Task<GetByIdTopicQueryResponse> Handle(GetByIdTopicQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = await readRepository.GetWhere(x => x.Id.Equals(request.TopicId))
            .Include(x => x.Module).FirstOrDefaultAsync(cancellationToken);

        var response = mapper.Map<TopicGetByIdDto>(query);

        return new GetByIdTopicQueryResponse() { Topic = response };
    }
}