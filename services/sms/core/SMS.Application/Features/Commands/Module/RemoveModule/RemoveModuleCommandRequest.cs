using MediatR;

namespace SMS.Application.Features.Commands.Module.RemoveModule;

public class RemoveModuleCommandRequest : IRequest<RemoveModuleCommandResponse>
{
    public int Id { get; set; }
}