using MediatR;
using SMS.Application.Features.Commands.Student.RemoveStudent;

namespace SMS.Application.Features.Commands.Student.UpdateStudent;

public class UpdateStudentCommandRequest : IRequest<UpdateStudentCommandResponse>
{
    public string StudentId { get; set; }
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? ImageUrl { get; set; }

    public bool Status { get; set; }
}