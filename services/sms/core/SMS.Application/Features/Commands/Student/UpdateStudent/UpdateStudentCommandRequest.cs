using MediatR;
using SMS.Application.Features.Commands.Student.RemoveStudent;

namespace SMS.Application.Features.Commands.Student.UpdateStudent;

public class UpdateStudentCommandRequest : IRequest<UpdateStudentCommandResponse>
{
    public string StudentId { get; set; }
    public string? Name { get; set; }
    public int? Age { get; set; }
    public bool Status { get; set; }
}