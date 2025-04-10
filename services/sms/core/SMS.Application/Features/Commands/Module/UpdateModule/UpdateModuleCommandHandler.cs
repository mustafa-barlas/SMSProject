using MediatR;
using SMS.Application.Repositories.ModuleRepository;

namespace SMS.Application.Features.Commands.Module.UpdateModule;

public class UpdateModuleCommandHandler(IModuleWriteRepository writeRepository, IModuleReadRepository readRepository)
    : IRequestHandler<UpdateModuleCommandRequest, UpdateModuleCommandResponse>
{
    public async Task<UpdateModuleCommandResponse> Handle(UpdateModuleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = await readRepository.GetByIdAsync(request.ModuleId.ToString());

        response.Status = request.Status;
        response.ImageUrl = request.ImageUrl;
        response.Name = request.ModuleName;
        response.UpdatedDate = DateTime.Now;
        
        await writeRepository.SaveAsync();
        return new();
    }
}