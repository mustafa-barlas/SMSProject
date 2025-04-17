using MediatR;
using SMS.DtoLayer.StudentModule;

namespace SMS.Application.Features.Commands.StudentModule.UpdateStudentModule;

public class UpdateStudentModuleCommandRequest : IRequest<UpdateStudentModuleCommandResponse>
{
    public StudentModuleUpdateDto StudentModuleUpdateDto { get; set; }
}