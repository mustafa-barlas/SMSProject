using MediatR;
using SMS.Application.Repositories.ModuleRepository;

namespace SMS.Application.Features.Commands.Module.RemoveModule;

public class RemoveModuleCommandHandler(IModuleWriteRepository writeRepository)
    : IRequestHandler<RemoveModuleCommandRequest, RemoveModuleCommandResponse>
{
    public async Task<RemoveModuleCommandResponse> Handle(RemoveModuleCommandRequest request,
        CancellationToken cancellationToken)
    {
        await writeRepository.RemoveByIdAsync(request.Id);
        await writeRepository.SaveAsync();
        return new();
    }
}