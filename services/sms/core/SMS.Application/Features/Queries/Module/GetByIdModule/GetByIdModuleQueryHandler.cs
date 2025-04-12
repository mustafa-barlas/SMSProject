using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Dto.Module;
using SMS.Application.Dto.Topic;
using SMS.Application.Repositories.ModuleRepository;

namespace SMS.Application.Features.Queries.Module.GetByIdModule;

public class GetByIdModuleQueryHandler(IModuleReadRepository readRepository)
    : IRequestHandler<GetByIdModuleQueryRequest, GetByIdModuleQueryResponse>
{
    public async Task<GetByIdModuleQueryResponse> Handle(GetByIdModuleQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = await readRepository.GetWhere(x => x.Id.Equals(request.ModuleId)).Include(x => x.Topics)
            .FirstOrDefaultAsync(cancellationToken);

        var response = new GetByIdModuleQueryResponse
        {
            Module = new GetByIdModuleDto()
            {
                ModuleId = query.Id.ToString(),
                ModuleName = query.Name,
                Status = query.Status,
                CreateDate = query.CreatedDate,
                UpdateDate = query.UpdatedDate,
                ImageUrl = query.ImageUrl,
                Topics = query.Topics.Select(x => new TopicDto()
                {
                    TopicName = x.Name,
                    TopicId = x.Id
                }).ToList()
            }
        };
        return response;
    }
}