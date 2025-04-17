using MediatR;

namespace SMS.Application.Features.Commands.Student.RemoveStudent;

public class RemoveStudentCommandRequest : IRequest<RemoveStudentCommandResponse>
{
    public int Id { get; set; }
}