using MediatR;

namespace SMS.Application.Features.Commands.StudentModule.RemoveStudentModule;

public class RemoveStudentModuleCommandRequest : IRequest<RemoveStudentModuleCommandResponse>
{
    public int StudentId { get; set; }
    public int ModuleId { get; set; }
}