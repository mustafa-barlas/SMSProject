using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.ModuleRepository;
using SMS.DtoLayer.Module;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Queries.Module.GetAllModule;

public class GetAllModuleQueryHandler(IModuleReadRepository readRepository, IMapper mapper) :
    IRequestHandler<GetAllModuleQueryRequest, GetAllModuleQueryResponse>
{
    public async Task<GetAllModuleQueryResponse> Handle(GetAllModuleQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = await readRepository.GetAll()
            .Include(x => x.Topics).ToListAsync(cancellationToken);

        var response = mapper.Map<List<GetAllModuleDto>>(query);

        return new()
        {
            Modules = response
        };
    }
}