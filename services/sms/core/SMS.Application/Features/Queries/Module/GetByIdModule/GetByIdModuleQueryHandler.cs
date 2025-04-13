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
            Module = new ModuleDto()
            {
                Id = query.Id,
                ModuleName = query.Name,
                ImageUrl = query.ImageUrl,
                Status = query.Status,
                CreatedDate = query.CreatedDate,
                UpdatedDate = query.UpdatedDate,
                Topics = query.Topics.Select(x => new TopicDto()
                {
                    Id = x.Id,
                    TopicName = x.Name
                }).ToList()
            }
        };
        return response;
    }
}