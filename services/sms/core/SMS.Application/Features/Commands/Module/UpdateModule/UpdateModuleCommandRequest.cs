using MediatR;
using SMS.DtoLayer.Module;

namespace SMS.Application.Features.Commands.Module.UpdateModule;

public class UpdateModuleCommandRequest : IRequest<UpdateModuleCommandResponse>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }

    public bool Status { get; set; }


    // public ModuleUpdateDto ModuleUpdateDto { get; set; }
}