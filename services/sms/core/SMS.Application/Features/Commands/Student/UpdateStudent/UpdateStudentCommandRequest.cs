using MediatR;
using SMS.Application.Features.Commands.Student.RemoveStudent;
using SMS.DtoLayer.Student;

namespace SMS.Application.Features.Commands.Student.UpdateStudent;

public class UpdateStudentCommandRequest : IRequest<UpdateStudentCommandResponse>
{
    public StudentUpdateDto StudentUpdateDto { get; set; }
}