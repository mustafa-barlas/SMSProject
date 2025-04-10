using MediatR;

namespace SMS.Application.Features.Commands.Module.UpdateModule;

public class UpdateModuleCommandRequest : IRequest<UpdateModuleCommandResponse>
{
    public Guid ModuleId { get; set; }
    public string? ModuleName { get; set; }
    public bool Status { get; set; }
    public string? ImageUrl { get; set; }
}