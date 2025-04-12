using MediatR;

namespace SMS.Application.Features.Commands.StudentModule.UpdateStudentModule;

public class UpdateStudentModuleCommandRequest : IRequest<UpdateStudentModuleCommandResponse>
{
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }
    public bool IsActive { get; set; }
}