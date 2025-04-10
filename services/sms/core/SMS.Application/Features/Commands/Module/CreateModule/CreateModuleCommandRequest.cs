using MediatR;

namespace SMS.Application.Features.Commands.Module.CreateModule;

public class CreateModuleCommandRequest : IRequest<CreateModuleCommandResponse>
{
    public string? ModuleName { get; set; }
    public string? ImageUrl { get; set; }
    public bool Status { get; set; }
}