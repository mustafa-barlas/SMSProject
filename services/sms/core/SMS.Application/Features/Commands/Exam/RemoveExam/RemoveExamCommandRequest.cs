using MediatR;

namespace SMS.Application.Features.Commands.Exam.RemoveExam;

public class RemoveExamCommandRequest : IRequest<RemoveExamCommandResponse>
{
    public int Id { get; set; }
}