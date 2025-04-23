using AutoMapper;
using MediatR;
using SMS.Application.Repositories.ModuleRepository;

namespace SMS.Application.Features.Commands.Module.UpdateModule;

public class UpdateModuleCommandHandler(
    IModuleWriteRepository writeRepository,
    IModuleReadRepository readRepository,
    IMapper mapper)
    : IRequestHandler<UpdateModuleCommandRequest, UpdateModuleCommandResponse>
{
    public async Task<UpdateModuleCommandResponse> Handle(UpdateModuleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = await readRepository.GetByIdAsync(request.Id);

        mapper.Map(request, response);
        writeRepository.Update(response);
        await writeRepository.SaveAsync();
        return new();
    }
}