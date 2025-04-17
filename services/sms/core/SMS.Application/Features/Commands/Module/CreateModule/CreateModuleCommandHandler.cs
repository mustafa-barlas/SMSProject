using AutoMapper;
using MediatR;
using SMS.Application.Repositories.ModuleRepository;
using SMS.DtoLayer.Module;

namespace SMS.Application.Features.Commands.Module.CreateModule;

public class CreateModuleCommandHandler(IModuleWriteRepository writeRepository, IMapper mapper)
    : IRequestHandler<CreateModuleCommandRequest, CreateModuleCommandResponse>
{
    public async Task<CreateModuleCommandResponse> Handle(CreateModuleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var module = mapper.Map<Domain.Entities.Module>(request.ModuleCreateDto);
        await writeRepository.AddAsync(module);

        await writeRepository.SaveAsync();
        return new();
    }
}