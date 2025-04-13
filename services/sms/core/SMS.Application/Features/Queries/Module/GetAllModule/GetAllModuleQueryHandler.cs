using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.ModuleRepository;
using SMS.DtoLayer.Module;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Queries.Module.GetAllModule;

public class GetAllModuleQueryHandler(IModuleReadRepository readRepository) :
    IRequestHandler<GetAllModuleQueryRequest, GetAllModuleQueryResponse>
{
    public async Task<GetAllModuleQueryResponse> Handle(GetAllModuleQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = await readRepository.GetAll()
            .Include(x => x.Topics)
            .Select(x => new ModuleDto()
            {
                Id = x.Id,
                ModuleName = x.Name,
                ImageUrl = x.ImageUrl,
                Status = x.Status,
                Topics = x.Topics.Select(t => new TopicDto()
                {
                    Id = t.Id,
                    TopicName = x.Name,
                }).ToList()
            }).ToListAsync(cancellationToken);


        return new()
        {
            Modules = query
        };
    }
}