using MediatR;

namespace SMS.Application.Features.Commands.Student.RemoveStudent;

public class RemoveStudentCommandRequest : IRequest<RemoveStudentCommandResponse>
{
    public string StudentId { get; set; }
}