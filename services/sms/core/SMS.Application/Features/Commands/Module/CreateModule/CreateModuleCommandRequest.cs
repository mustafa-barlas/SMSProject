using MediatR;
using SMS.DtoLayer.Module;

namespace SMS.Application.Features.Commands.Module.CreateModule;

public class CreateModuleCommandRequest : IRequest<CreateModuleCommandResponse>
{
    
    public string Title { get; set; }
    public string ImageUrl { get; set; }

    public bool Status { get; set; }
    // public ModuleCreateDto ModuleCreateDto { get; set; }
}