using MediatR;
using SMS.DtoLayer.Module;

namespace SMS.Application.Features.Commands.Module.UpdateModule;

public class UpdateModuleCommandRequest : IRequest<UpdateModuleCommandResponse>
{
  public ModuleUpdateDto ModuleUpdateDto { get; set; }
}