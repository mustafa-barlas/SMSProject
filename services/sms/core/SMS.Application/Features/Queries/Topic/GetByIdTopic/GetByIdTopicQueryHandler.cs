using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.TopicRepository;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Queries.Topic.GetByIdTopic;

public class GetByIdTopicQueryHandler(ITopicReadRepository readRepository) :
    IRequestHandler<GetByIdTopicQueryRequest, GetByIdTopicQueryResponse>
{
    public async Task<GetByIdTopicQueryResponse> Handle(GetByIdTopicQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = await readRepository.GetWhere(x => x.Id.ToString() == request.TopicId)
            .Include(x => x.Module).FirstOrDefaultAsync(cancellationToken);

        var response = new GetByIdTopicQueryResponse()
        {
            Topic = new TopicDto()
            {
                Id = query.Id,
                TopicName = query.Name,
                CreatedDate = query.CreatedDate,
                UpdatedDate = query.UpdatedDate,
                Status = query.Status
            }
        };
        return response;
    }
}