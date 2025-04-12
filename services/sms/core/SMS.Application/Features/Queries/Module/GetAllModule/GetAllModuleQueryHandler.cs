using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Dto.Module;
using SMS.Application.Dto.Topic;
using SMS.Application.Repositories.ModuleRepository;

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
            .Select(x => new GetByIdModuleDto()
            {
                ModuleId = x.Id.ToString(),
                ModuleName = x.Name,
                Status = x.Status,
                ImageUrl = x.ImageUrl,
                CreateDate = x.CreatedDate,
                UpdateDate = x.UpdatedDate,
                Topics = x.Topics.Select(t => new TopicDto
                {
                    TopicId = t.Id,
                    TopicName = t.Name
                }).ToList()
            }).ToListAsync(cancellationToken);


        return new()
        {
            ModuleDtos = query
        };
    }
}