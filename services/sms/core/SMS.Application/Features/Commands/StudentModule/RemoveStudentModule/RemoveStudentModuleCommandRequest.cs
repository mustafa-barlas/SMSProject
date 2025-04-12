using MediatR;

namespace SMS.Application.Features.Commands.StudentModule.RemoveStudentModule;

public class RemoveStudentModuleCommandRequest : IRequest<RemoveStudentModuleCommandResponse>
{
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }
}