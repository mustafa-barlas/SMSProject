using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Repositories.ModuleRepository;
using SMS.DtoLayer.Module;
using SMS.DtoLayer.Topic;

namespace SMS.Application.Features.Queries.Module.GetByIdModule;

public class GetByIdModuleQueryHandler(IModuleReadRepository readRepository, IMapper mapper)
    : IRequestHandler<GetByIdModuleQueryRequest, GetByIdModuleQueryResponse>
{
    public async Task<GetByIdModuleQueryResponse> Handle(GetByIdModuleQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = await readRepository.GetAll(false).Include(x => x.Topics).Where(x => x.Id.Equals(request.Id))
            .FirstOrDefaultAsync(cancellationToken);

        var response = mapper.Map<ModuleGetByIdDto>(query);

        return new()
        {
            Module = response
        };
    }
}