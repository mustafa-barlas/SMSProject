using MediatR;
using SMS.Application.Repositories.ModuleRepository;

namespace SMS.Application.Features.Commands.Module.ChangeStatusModule;

public class ChangeStatusModuleCommandHandler(IModuleWriteRepository writeRepository)
    : IRequestHandler<ChangeStatusModuleCommandRequest,
        ChangeStatusModuleCommandResponse>
{
    public async Task<ChangeStatusModuleCommandResponse> Handle(ChangeStatusModuleCommandRequest request,
        CancellationToken cancellationToken)
    {
        await writeRepository.ChangeStatusAsync(request.Id,request.Status);
        return new();
    }
}