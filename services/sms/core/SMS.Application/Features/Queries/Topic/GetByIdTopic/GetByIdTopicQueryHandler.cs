using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Dto.Topic;
using SMS.Application.Repositories.TopicRepository;

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
                TopicId = query.Id.ToString(),
                TopicName = query.Name,
                CreateDate = query.CreatedDate,
                UpdateDate = query.UpdatedDate,
                ModuleId = query.ModuleId.ToString(),
                Status = query.Status
            }
        };
        return response;
    }
}