using MediatR;

namespace SMS.Application.Features.Commands.Student.ChangeStatusStudent;

public class ChangeStatusStudentCommandRequest : IRequest<ChangeStatusStudentCommandResponse>
{
    public int Id { get; set; }
    public bool Status { get; set; } // Durum bilgisi
}