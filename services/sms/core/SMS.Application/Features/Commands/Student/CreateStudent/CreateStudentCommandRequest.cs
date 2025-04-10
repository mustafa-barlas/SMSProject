using MediatR;

namespace SMS.Application.Features.Commands.Student.CreateStudent;

public class CreateStudentCommandRequest : IRequest<CreateStudentCommandResponse>
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public bool? Status { get; set; }
}