using MediatR;
using SMS.DtoLayer.Student;

namespace SMS.Application.Features.Commands.Student.CreateStudent;

public class CreateStudentCommandRequest : IRequest<CreateStudentCommandResponse>
{
    public StudentCreateDto StudentCreateDto { get; set; }

}