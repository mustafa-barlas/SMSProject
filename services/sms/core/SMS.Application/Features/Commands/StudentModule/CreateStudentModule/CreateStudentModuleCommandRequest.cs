using MediatR;
using SMS.DtoLayer.StudentModule;

namespace SMS.Application.Features.Commands.StudentModule.CreateStudentModule;

public class CreateStudentModuleCommandRequest : IRequest<CreateStudentModuleCommandResponse>
{
    public int StudentId { get; set; }
    public int ModuleId { get; set; }
}