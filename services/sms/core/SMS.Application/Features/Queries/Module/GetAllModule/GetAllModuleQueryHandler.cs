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
            .Include(x => x.StudentModules)
            .ThenInclude(x => x.Student)
            .Select(x => new ModuleListDto()
            {
                Id = x.Id,
                ModuleName = x.Name,
                Status = x.Status,
                ImageUrl = x.ImageUrl,
                Topics = x.Topics.Select(t => new TopicDto
                {
                    TopicName = t.Name
                }).ToList()
            }).ToListAsync(cancellationToken);


        return new()
        {
            ModuleDtos = query
        };
    }
}