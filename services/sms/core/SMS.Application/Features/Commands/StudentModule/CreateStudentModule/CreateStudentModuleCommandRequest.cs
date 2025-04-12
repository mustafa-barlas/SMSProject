using MediatR;

namespace SMS.Application.Features.Commands.StudentModule.CreateStudentModule;

public class CreateStudentModuleCommandRequest : IRequest<CreateStudentModuleCommandResponse>
{
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }
}