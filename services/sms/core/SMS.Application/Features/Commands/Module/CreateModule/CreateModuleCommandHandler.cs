using MediatR;
using SMS.Application.Repositories.ModuleRepository;

namespace SMS.Application.Features.Commands.Module.CreateModule;

public class CreateModuleCommandHandler(IModuleWriteRepository writeRepository)
    : IRequestHandler<CreateModuleCommandRequest, CreateModuleCommandResponse>
{
    public async Task<CreateModuleCommandResponse> Handle(CreateModuleCommandRequest request,
        CancellationToken cancellationToken)
    {
        await writeRepository.AddAsync(new()
        {
            Name = request.ModuleName,
            ImageUrl = request.ImageUrl,
            Status = request.Status,
        });
        
        await writeRepository.SaveAsync();
        return new();
    }
}