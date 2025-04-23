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
        var result = await readRepository.GetWhere(x => x.Id == request.Id).Include(x => x.Topics)
            .FirstOrDefaultAsync(cancellationToken);

        var response = mapper.Map<ModuleGetByIdDto>(result);

        return new()
        {
            Module = response
        };
    }
}