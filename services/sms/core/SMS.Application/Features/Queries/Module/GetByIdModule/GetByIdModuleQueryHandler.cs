using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.ModuleRepository;
using SMS.DtoLayer.Module;
using SMS.DtoLayer.Topic;

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
            Module = new ModuleDetailDto()
            {
                Id = query.Id,
                Name = query.Name,
                Status = query.Status,
                CreatedDate = query.CreatedDate,
                UpdatedDate = query.UpdatedDate,
                ImageUrl = query.ImageUrl,
                Topics = query.Topics.Select(x => new TopicDto()
                {
                    TopicName = x.Name,
                    Id = x.Id
                }).ToList()
            }
        };
        return response;
    }
}