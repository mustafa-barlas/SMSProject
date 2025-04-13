using MediatR;

namespace SMS.Application.Features.Queries.Module.GetByIdModule;

public class GetByIdModuleQueryRequest : IRequest<GetByIdModuleQueryResponse>
{
    public Guid ModuleId { get; set; }
}