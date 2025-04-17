using MediatR;
using SMS.DtoLayer.Module;

namespace SMS.Application.Features.Commands.Module.CreateModule;

public class CreateModuleCommandRequest : IRequest<CreateModuleCommandResponse>
{
    public ModuleCreateDto ModuleCreateDto { get; set; }
}